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

    
    public struct _WString
    {
      public const int MAX_TEXT_SIZE = 48;
      public uint length;
      public unsafe fixed sbyte p[MAX_TEXT_SIZE]; /* p is a null terminated string. */
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct _DecodedInst 
    {
	    public _WString mnemonic; /* Mnemonic of decoded instruction, prefixed if required by REP, LOCK etc. */
	    public _WString operands; /* Operands of the decoded instruction, up to 3 operands, comma-seperated. */
	    public _WString instructionHex; /* Hex dump - little endian, including prefixes. */
	    public uint size; /* Size of decoded instruction. */
	    public IntPtr offset; /* Start offset of the decoded instruction. */
    };


    /* Used by O_PTR: */

    public struct PtrStruct
    {
      private ushort seg;
      /* Can be 16 or 32 bits, size is in ops[n].size. */
      private uint off;
    };

    /* Used by O_IMM1 (i1) and O_IMM2 (i2). ENTER instruction only. */

    public struct ExStruct
    {
      private uint i1;
      private uint i2;
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
      public OperandType type; /* _OperandType */

      /* Index of:
		    O_REG: holds global register index
		    O_SMEM: holds the 'base' register. E.G: [ECX], [EBX+0x1234] are both in operand.index.
		    O_MEM: holds the 'index' register. E.G: [EAX*4] is in operand.index.
	    */
      public byte index;

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
      public ushort size;
    };

    public struct _DInst
    {
      public const int OPERANDS_NO = 4;
      private const int OPERANDS_SIZE = 4*OPERANDS_NO;

      /* Used by ops[n].type == O_IMM/O_IMM1&O_IMM2/O_PTR/O_PC. Its size is ops[n].size. */
      internal _Value imm;
      /* Used by ops[n].type == O_SMEM/O_MEM/O_DISP. Its size is dispSize. */
      internal ulong disp;
      /* Virtual address of first byte of instruction. */
      internal IntPtr addr;
      /* General flags of instruction, holds prefixes and more, if FLAG_NOT_DECODABLE, instruction is invalid. */
      internal ushort flags;
      /* Unused prefixes mask, for each bit that is set that prefix is not used (LSB is byte [addr + 0]). */
      internal ushort unusedPrefixesMask;
      /* Mask of registers that were used in the operands, only used for quick look up, in order to know *some* operand uses that register class. */
      internal ushort usedRegistersMask;
      /* ID of opcode in the global opcode table. Use for mnemonic look up. */
      internal ushort opcode;
      /* Up to four operands per instruction, ignored if ops[n].type == O_NONE. */
      private unsafe fixed byte ops_storage[OPERANDS_SIZE];
      internal unsafe _Operand* ops
      {
        get
        {
          fixed (byte* p = ops_storage)
          {
            return (_Operand*) p;
          }
        }
      }
      /* Size of the whole instruction. */
      internal byte size;
      /* Segment information of memory indirection, default segment, or overridden one, can be -1. Use SEGMENT macros. */
      internal byte segment;
      /* Used by ops[n].type == O_MEM. Base global register index (might be R_NONE), scale size (2/4/8), ignored for 0 or 1. */
      internal byte ibase, scale;
      internal byte dispSize;
      /* Meta defines the instruction set class, and the flow control flags. Use META macros. */
      internal byte meta;
      /* The CPU flags that the instruction operates upon. */
      internal byte modifiedFlagsMask, testedFlagsMask, undefinedFlagsMask;
    };

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

    private static unsafe _CodeInfo* AcquireCodeInfoStruct(CodeInfo nci)
    {
      var ci = (_CodeInfo*) Malloc(sizeof (_CodeInfo));
      if (ci == null)
        throw new OutOfMemoryException();

      Memset(ci, 0, sizeof (_CodeInfo));
      //memset(ci, 0, sizeof(_CodeInfo));

      ci->codeOffset = new IntPtr(nci.mCodeOffset);
      var gch = GCHandle.Alloc(nci.mCode, GCHandleType.Pinned);

      ci->code = (byte*) gch.AddrOfPinnedObject().ToPointer();
      ci->codeLen = nci.mCode.Length;
      ci->dt = nci.mDecodeType;
      ci->features = nci.mFeatures;
      return ci;
    }

    private static unsafe DecodedInst CreateDecodedInstObj(_DecodedInst* inst)
    {
      return new DecodedInst {
        mMnemonic = new String(inst->mnemonic.p),
        mOperands = new String(inst->operands.p),
        mHex = new string(inst->instructionHex.p),
        mSize = inst->size,
        mOffset = inst->offset
      };
    }

    private static unsafe void Memset(void *p, int v, int sz)
    {      
    }


    public static unsafe void Decompose(CodeInfo nci, DecomposedResult ndr)
    {	    
	    _CodeInfo* ci = null;
      _DInst* insts = null;
	    int maxInstructions = 0;
	    int usedInstructionsCount = 0, i = 0, j = 0, operandsNo = 0;
	    int success = 0;



	    ci = AcquireCodeInfoStruct(nci);
	    if (ci == null) {
	      throw new OutOfMemoryException();
	    }

      maxInstructions = ndr.mMaxInstructions;

	    insts = (_DInst*)Malloc(maxInstructions * sizeof(_DInst));

	    distorm_decompose64(ci, insts, maxInstructions, &usedInstructionsCount);

	    var dinsts = new DecomposedInst[usedInstructionsCount];

      for (i = 0; i < usedInstructionsCount; i++) {
	      var di = new DecomposedInst {
          mAddr = (long) insts[i].addr,
          mFlags = insts[i].flags,
          mSize = insts[i].size,
          mSegment = insts[i].segment,
          mBase = insts[i].ibase,
          mScale = insts[i].scale,
          mOpcode = insts[i].opcode,
          mUnusedPrefixesMask = insts[i].unusedPrefixesMask,
          mMeta = insts[i].meta,
          mRegistersMask = insts[i].usedRegistersMask,
          mModifiedFlagsMask = insts[i].modifiedFlagsMask,
          mTestedFlagsMask = insts[i].testedFlagsMask,
          mUndefinedFlagsMask = insts[i].undefinedFlagsMask
        };

		    /* Simple fields: */

        /* Immediate variant. */
	      var immVariant = new DecomposedInst.ImmVariant();
        immVariant.mValue = insts[i].imm.qword;
		    /* The size of the immediate is in one of the operands, if at all. Look for it below. Zero by default. */
        immVariant.mSize = 0;		

		    /* Count operands. */
		    for (operandsNo = 0; operandsNo < _DInst.OPERANDS_NO; operandsNo++) {
			    if (insts[i].ops[operandsNo].type == OperandType.None) 
            break;
		    }

	      var ops = new Operand[operandsNo];

		    for (j = 0; j < operandsNo; j++) {
			    if (insts[i].ops[j].type == OperandType.Imm) {
				    /* Set the size of the immediate operand. */
			      immVariant.mSize = insts[i].ops[j].size;				    
			    }

		      var op = new Operand();

		      op.mType = insts[i].ops[j].type;
			    op.mIndex = insts[i].ops[j].index;
			    op.mSize = insts[i].ops[j].size;
		      ops[j] = op;			    
		    }
	      di.mOperands = ops;		    

		    /* Attach the immediate variant. */
	      di.mImm = immVariant;

		    /* Displacement variant. */
	      var disp = new DecomposedInst.DispVariant();

	      disp.mDisplacement = insts[i].disp;
	      disp.mSize = insts[i].dispSize;
	      di.mDisp = disp;
        dinsts[i] = di;
	    }

	    ndr.mInstructions = dinsts;
    }

    public static unsafe void Decode(CodeInfo nci, DecodedResult dr)
    {
      _CodeInfo* ci = null;
      _DecodedInst* insts = null;
      var maxInstructions = 0;
      uint usedInstructionsCount = 0, i = 0;


      ci = AcquireCodeInfoStruct(nci);
      if (ci == null)
        throw new OutOfMemoryException();

      maxInstructions = dr.mMaxInstructions;

      insts = (_DecodedInst*) Malloc(maxInstructions*sizeof (_DecodedInst));
      if (insts == null)
        goto cleanup;

      distorm_decode64(ci->codeOffset, ci->code, ci->codeLen, ci->dt, insts, (uint) maxInstructions,
                       &usedInstructionsCount);

      var dinsts = new DecodedInst[usedInstructionsCount];
      if (dinsts == null)
        goto cleanup;

      for (i = 0; i < usedInstructionsCount; i++) {
        if ((dinsts[i] = CreateDecodedInstObj(&insts[i])) == null)
          goto cleanup;
      }
      dr.mInstructions = dinsts;

      cleanup:
      /* In case of an error, jInsts will get cleaned automatically. */
      Free(ci);
      if (insts != null)
        Free(insts);
    }

    private static unsafe void Free(void *insts)
    {      
    }

    public static unsafe DecodedInst Format(CodeInfo nci, DecomposedInst ndi)
    {    	
      _DInst input = new _DInst();
    	_DecodedInst output;
    	
      int i, opsCount;
    
    
    	var ci = AcquireCodeInfoStruct(nci);
    	if (ci == null)
    		throw new OutOfMemoryException();
    
    	input.addr    = (IntPtr) ndi.mAddr;
      input.flags   = (ushort) ndi.mFlags;
    	input.size    = (byte) ndi.mSize;
    	input.segment = (byte) ndi.mSegment;
    	input.ibase   = (byte) ndi.mBase;
    	input.scale   = (byte) ndi.mScale;
    	input.opcode  = (ushort) ndi.mOpcode;
    	/* unusedPrefixesMask is unused indeed, lol. */
    	input.meta =    (byte) ndi.mMeta;
    	/* Nor usedRegistersMask. */

      opsCount = ndi.mOperands.Length;
    	for (i = 0; i < opsCount; i++) {
    	  var op = ndi.mOperands[i];
    	  if (op == null) continue;
    	  input.ops[i].index = (byte) op.mIndex;
    	  input.ops[i].type = op.mType;
    	  input.ops[i].size = (ushort) op.mSize;
    	}

    	if (ndi.mImm != null)
    		input.imm.qword = ndi.mImm.mValue;
        	
    	if (ndi.mDisp != null) {
    		input.disp = ndi.mDisp.mDisplacement;
    		input.dispSize = (byte) ndi.mDisp.mSize;
    	}
    
    	distorm_format64(ci, &input, &output);
    
    	var ret = CreateDecodedInstObj(&output);
    
      Free(ci);
    	return ret;         
    }
  }
}
