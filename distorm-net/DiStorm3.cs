using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DiStorm
{
  public enum DecodeType
  {
    Decode16Bits,
    Decode32Bits,
    Decode64Bits
  }

  public class DiStorm3
  {
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public unsafe struct _CodeInfo
    {
      internal IntPtr codeOffset; /* nextOffset is OUT only. */
      internal IntPtr nextOffset; /* nextOffset is OUT only. */
      internal byte* code;
      internal int codeLen; /* Using signed integer makes it easier to detect an underflow. */
      internal DecodeType dt;
      internal int features;
    };


    /* Used by O_PTR: */

    private struct PtrStruct
    {
      private ushort seg;
      /* Can be 16 or 32 bits, size is in ops[n].size. */
      private uint off;
    };

    /* Used by O_IMM1 (i1) and O_IMM2 (i2). ENTER instruction only. */

    private struct ExStruct
    {
      private uint i1;
      private uint i2;
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct _Value
    {
      /* Used by O_IMM: */
      [FieldOffset(0)] private sbyte sbyt;
      [FieldOffset(0)] private byte byt;
      [FieldOffset(0)] private short sword;
      [FieldOffset(0)] private ushort word;
      [FieldOffset(0)] private int sdword;
      [FieldOffset(0)] private uint dword;
      [FieldOffset(0)] private long sqword; /* All immediates are SIGN-EXTENDED to 64 bits! */
      [FieldOffset(0)] private ulong qword;
      /* Used by O_PC: (Use GET_TARGET_ADDR).*/
      [FieldOffset(0)] private IntPtr addr; /* It's a relative offset as for now. */
      [FieldOffset(0)] private PtrStruct ptr;
      [FieldOffset(0)] private ExStruct ex;
    };

    public struct _Operand
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
      private byte type; /* _OperandType */

      /* Index of:
		    O_REG: holds global register index
		    O_SMEM: holds the 'base' register. E.G: [ECX], [EBX+0x1234] are both in operand.index.
		    O_MEM: holds the 'index' register. E.G: [EAX*4] is in operand.index.
	    */
      private byte index;

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
      private ushort size;
    };

    public struct _DInst
    {
      private const int OPERANDS_NO = 4;
      private const int OPERANDS_SIZE = 4*OPERANDS_NO;

      /* Used by ops[n].type == O_IMM/O_IMM1&O_IMM2/O_PTR/O_PC. Its size is ops[n].size. */
      private _Value imm;
      /* Used by ops[n].type == O_SMEM/O_MEM/O_DISP. Its size is dispSize. */
      private ulong disp;
      /* Virtual address of first byte of instruction. */
      private IntPtr addr;
      /* General flags of instruction, holds prefixes and more, if FLAG_NOT_DECODABLE, instruction is invalid. */
      private ushort flags;
      /* Unused prefixes mask, for each bit that is set that prefix is not used (LSB is byte [addr + 0]). */
      private ushort unusedPrefixesMask;
      /* Mask of registers that were used in the operands, only used for quick look up, in order to know *some* operand uses that register class. */
      private ushort usedRegistersMask;
      /* ID of opcode in the global opcode table. Use for mnemonic look up. */
      private ushort opcode;
      /* Up to four operands per instruction, ignored if ops[n].type == O_NONE. */
      private unsafe fixed byte ops [OPERANDS_SIZE];
      /* Size of the whole instruction. */
      private byte size;
      /* Segment information of memory indirection, default segment, or overriden one, can be -1. Use SEGMENT macros. */
      private byte segment;
      /* Used by ops[n].type == O_MEM. Base global register index (might be R_NONE), scale size (2/4/8), ignored for 0 or 1. */
      private byte ibase, scale;
      private byte dispSize;
      /* Meta defines the instruction set class, and the flow control flags. Use META macros. */
      private byte meta;
      /* The CPU flags that the instruction operates upon. */
      private byte modifiedFlagsMask, testedFlagsMask, undefinedFlagsMask;
    };

    [DllImport("distorm")]
    private static extern unsafe void distrom_decompose(_CodeInfo* codeInfo, _DInst* dinsts, int maxInstructions,
                                                        [Out] int usedInstructions);

    [DllImport("distorm")]
    private static extern unsafe void distrom_decode(_CodeInfo* codeInfo, _DInst* dinsts, int maxInstructions,
                                                     [Out] int usedInstructions);

    [DllImport("distorm")]
    private static extern unsafe void distrom_format(_CodeInfo* codeInfo, _DInst* dinsts, int maxInstructions,
                                                     [Out] int usedInstructions);

    public static unsafe void* Malloc(int sz)
    {
      return Marshal.AllocHGlobal(new IntPtr(sz)).ToPointer();
    }

    private static unsafe _CodeInfo* AcquireCodeInfoStruct(CodeInfo nci)
    {
      _CodeInfo* ci = (_CodeInfo*) Malloc(sizeof (_CodeInfo));
      if (ci == null)
        throw new OutOfMemoryException();

      //memset(ci, 0, sizeof(_CodeInfo));

      ci->codeOffset = new IntPtr(nci.mCodeOffset);
      //ci->code = nci.mCode;
      ci->codeLen = nci.mCode.Length;
      ci->dt = nci.mDecodeType;
      ci->features = nci.mFeatures;

      return ci;
    }


    public static unsafe void Decompose(CodeInfo nci, DecomposedResult ndr)
    {
      var ci = AcquireCodeInfoStruct(nci);

    }

    public static void Decode(CodeInfo ci, DecodedResult dr)
    {

    }

    public static DecodedInst Format(CodeInfo ci, DecomposedInst di)
    {}
}
}
