using System;
using System.Runtime.InteropServices;

namespace diStorm
{
  public enum DecodeType
  {
    Decode16Bits,
    Decode32Bits,
    Decode64Bits
  }

  public class DiStorm3
  {
    /* Used by O_PTR: */

    /* Used by O_IMM1 (i1) and O_IMM2 (i2). ENTER instruction only. */

    [DllImport("distorm3")]
    private static extern unsafe void distorm_decompose64(void* codeInfo, void* dinsts, int maxInstructions, int* usedInstructions);

    [DllImport("distorm3")]
    private static extern unsafe void distorm_decode64(IntPtr codeOffset, byte* code, int codeLen, DecodeType dt, void *result, uint maxInstructions, uint* usedInstructionsCount);

    [DllImport("distorm3")]
    private static extern unsafe void distorm_format64(void* codeInfo, void* dinst, void* output);

    public static unsafe void* Malloc(int sz)
    {
      return Marshal.AllocHGlobal(new IntPtr(sz)).ToPointer();
    }

    private static unsafe void Free(void* mem)
    {
      Marshal.FreeHGlobal(new IntPtr(mem));
    }

    private static unsafe CodeInfoStruct* AcquireCodeInfoStruct(CodeInfo nci, out GCHandle gch)
    {
      var ci = (CodeInfoStruct*) Malloc(sizeof (CodeInfoStruct));
      if (ci == null)
        throw new OutOfMemoryException();

      Memset(ci, 0, sizeof (CodeInfoStruct));

      ci->codeOffset = new IntPtr(nci._codeOffset);

      if (nci._code == null && nci._codePtr != null && nci._codeLength > 0) {
        ci->code = nci._codePtr;
        ci->codeLen = nci._codeLength;
        gch = new GCHandle();
      }
      else {
        gch = GCHandle.Alloc(nci._code, GCHandleType.Pinned);
        ci->code = (byte*) gch.AddrOfPinnedObject().ToPointer();
        ci->codeLen = nci._code.Length;
      }
      ci->dt = nci._decodeType;
      ci->features = nci._features;
      return ci;
    }

    private static unsafe void Memset(void *p, int v, int sz)
    {
    }

    public static unsafe DecomposedResult Decompose(CodeInfo nci, int maxInstructions)
    {
	    CodeInfoStruct* ci = null;
      DecomposedInstructionStruct* insts = null;
      var gch = new GCHandle();
      var usedInstructionsCount = 0;

      try {
        if ((ci = AcquireCodeInfoStruct(nci, out gch)) == null)
          throw new OutOfMemoryException();

        var dr = new DecomposedResult(maxInstructions);

        distorm_decompose64(ci, dr.InstructionsPointer, maxInstructions, &usedInstructionsCount);
        dr.UsedInstructions = usedInstructionsCount;
        return dr;
      }
      finally
      {
        if (gch.IsAllocated)
          gch.Free();
        if (ci != null)
          Free(ci);
      }
    }

    public static unsafe DecodedResult Decode(CodeInfo nci, int maxInstructions)
    {
      var gch = new GCHandle();
      uint usedInstructionsCount = 0;
      CodeInfoStruct* ci = null;
      try {

        ci = AcquireCodeInfoStruct(nci, out gch);
        var dr = new DecodedResult(maxInstructions);

        distorm_decode64(ci->codeOffset, ci->code, ci->codeLen, ci->dt, dr.InstructionsPointer, (uint) maxInstructions, &usedInstructionsCount);

        dr.UsedInstructionCount = (int) usedInstructionsCount;
        return dr;
      }
      finally {
        if (gch.IsAllocated)
          gch.Free();
        if (ci != null)
          Free(ci);
      }
    }

    public static unsafe DecodedInstruction Format(CodeInfo nci, DecomposedInstruction ndi)
    {
      var input = new DecomposedInstructionStruct();
      CodeInfoStruct *ci = null;
      var gch = new GCHandle();
      DecodedInstruction di;

      try
      {
        ci = AcquireCodeInfoStruct(nci, out gch);
        if (ci == null)
          throw new OutOfMemoryException();

        input.Address = ndi.Address;
        input.flags = ndi.Flags;
        input.Size = (byte) ndi.Size;
        input.segment = (byte) ndi._segment;
        input.ibase = (byte) ndi.Base;
        input.scale = (byte) ndi.Scale;
        input.Opcode = ndi.Opcode;
        /* unusedPrefixesMask is unused indeed, lol. */
        input.meta = (byte) ndi.Meta;
        /* Nor usedRegistersMask. */

        int opsCount = ndi.Operands.Length;
        for (var i = 0; i < opsCount; i++) {
          var op = ndi.Operands[i];
          if (op == null) continue;
          input.ops[i].index = (byte) op.Index;
          input.ops[i].Type = op.Type;
          input.ops[i].Size = (ushort) op.Size;
        }

        if (ndi.Imm != null)
          input.imm.qword = ndi.Imm.Imm;

        if (ndi.Disp != null)
        {
          input.disp = ndi.Disp.Displacement;
          input.dispSize = (byte) ndi.Disp.Size;
        }

        DecodedInstructionStruct output;
        distorm_format64(ci, &input, &output);

        di = DecodedInstruction.FromUnsafe(&output);
      }
      finally
      {
        if (gch.IsAllocated)
          gch.Free();
        if (ci != null)
          Free(ci);
      }
      return di;
    }
  }

  public struct DecomposedInstructionStruct
  {
    internal const int OPERANDS_NO = 4;
    private const int OPERANDS_SIZE = 4*OPERANDS_NO;

    /* Used by ops[n].type == O_IMM/O_IMM1&O_IMM2/O_PTR/O_PC. Its size is ops[n].size. */
    public _Value imm;
    /* Used by ops[n].type == O_SMEM/O_MEM/O_DISP. Its size is dispSize. */
    public ulong disp;
    /* Virtual address of first byte of instruction. */
    public IntPtr Address;
    /* General flags of instruction, holds prefixes and more, if FLAG_NOT_DECODABLE, instruction is invalid. */
    public ushort flags;
    /* Unused prefixes mask, for each bit that is set that prefix is not used (LSB is byte [addr + 0]). */
    public ushort unusedPrefixesMask;
    /* Mask of registers that were used in the operands, only used for quick look up, in order to know *some* operand uses that register class. */
    public ushort usedRegistersMask;
    /* ID of opcode in the global opcode table. Use for mnemonic look up. */
    public Opcode Opcode;
    /* Up to four operands per instruction, ignored if ops[n].type == O_NONE. */
    private unsafe fixed byte ops_storage[OPERANDS_SIZE];

    public unsafe OperandStruct* ops
    {
      get
      {
        fixed (byte* p = ops_storage)
        {
          return (OperandStruct*) p;
        }
      }
    }
    /* Size of the whole instruction. */
    public byte Size;
    /* Segment information of memory indirection, default segment, or overridden one, can be -1. Use SEGMENT macros. */
    public byte segment;
    /* Used by ops[n].type == O_MEM. Base global register index (might be R_NONE), scale size (2/4/8), ignored for 0 or 1. */
    public byte ibase, scale;
    public byte dispSize;
    /* Meta defines the instruction set class, and the flow control flags. Use META macros. */
    public byte meta;
    /* The CPU flags that the instruction operates upon. */
    public byte modifiedFlagsMask, testedFlagsMask, undefinedFlagsMask;
  };

  [StructLayout(LayoutKind.Sequential)]
  public struct OperandStruct
  {
    /* Type of operand:
		    O_NONE: operand is to be ignored.
		    O_REG: index holds global register index.
		    O_IMM: instruction.imm.
		    O_IMM1: instruction.imm.ex.i1.
		    O_IMM2: instruction.imm.ex.i2.
		    O_DISP: memory dereference with displacement only, instruction.disp.
		    O_SMEM: simple memory dereference with optional displacement (a single register memory dereference).
		    O_MEM: complex memory dereference (optional fields: s/i/b/disp).
		    O_PC: the relative address of a branch instruction (instruction.imm.addr).
		    O_PTR: the absolute target address of a far branch instruction (instruction.imm.ptr.seg/off).
	    */
    public OperandType Type; /* _OperandType */

    /* Index of:
		    O_REG: holds global register index
		    O_SMEM: holds the 'base' register. E.G: [ECX], [EBX+0x1234] are both in operand.index.
		    O_MEM: holds the 'index' register. E.G: [EAX*4] is in operand.index.
	    */
    public byte index;

    public Register Register { get { return (Register) index; } }

    /* Size of:
		    O_REG: register
		    O_IMM: instruction.imm
		    O_IMM1: instruction.imm.ex.i1
		    O_IMM2: instruction.imm.ex.i2
		    O_DISP: instruction.disp
		    O_SMEM: size of indirection.
		    O_MEM: size of indirection.
		    O_PC: size of the relative offset
		    O_PTR: size of instruction.imm.ptr.off (16 or 32)
	    */
    public ushort Size;
  };

  [StructLayout(LayoutKind.Explicit)]
  public struct _Value
  {
    /* Used by O_IMM: */
    [FieldOffset(0)] public sbyte sbyt;
    [FieldOffset(0)] public byte byt;
    [FieldOffset(0)] public short sword;
    [FieldOffset(0)] public ushort word;
    [FieldOffset(0)] public int sdword;
    [FieldOffset(0)] public uint dword;
    [FieldOffset(0)] public long sqword; /* All immediates are SIGN-EXTENDED to 64 bits! */
    [FieldOffset(0)] public ulong qword;
    /* Used by O_PC: (Use GET_TARGET_ADDR).*/
    [FieldOffset(0)] public IntPtr addr; /* It's a relative offset as for now. */
    [FieldOffset(0)] public PtrStruct ptr;
    [FieldOffset(0)] public ExStruct ex;
  };

  [StructLayout(LayoutKind.Sequential)]
  public struct ExStruct
  {
    private uint i1;
    private uint i2;
  };

  [StructLayout(LayoutKind.Sequential)]
  public struct PtrStruct
  {
    private ushort seg;
    /* Can be 16 or 32 bits, size is in ops[n].size. */
    private uint off;
  };

  public struct WStringStruct
  {
    public const int MAX_TEXT_SIZE = 48;
    public uint length;
    public unsafe fixed sbyte p[MAX_TEXT_SIZE]; /* p is a null terminated string. */
  }

  [StructLayout(LayoutKind.Sequential, Pack = 8)]
  public struct DecodedInstructionStruct
  {
    public WStringStruct Mnemonic; /* Mnemonic of decoded instruction, prefixed if required by REP, LOCK etc. */
    public WStringStruct Operands; /* Operands of the decoded instruction, up to 3 operands, comma-seperated. */
    public WStringStruct InstructionHex; /* Hex dump - little endian, including prefixes. */
    public uint Size; /* Size of decoded instruction. */
    public IntPtr Address; /* Start offset of the decoded instruction. */
  };

  [StructLayout(LayoutKind.Sequential, Pack = 8)]
  internal unsafe struct CodeInfoStruct
  {
    internal IntPtr codeOffset; /* nextOffset is OUT only. */
    internal IntPtr nextOffset; /* nextOffset is OUT only. */
    internal byte* code;
    internal int codeLen; /* Using signed integer makes it easier to detect an underflow. */
    internal DecodeType dt;
    internal int features;
  };
}