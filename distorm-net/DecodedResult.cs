using System.Runtime.InteropServices;

namespace DiStorm
{
  public class DecodedResult
  {
    public unsafe DecodedResult(int maxInstructionCount)
    {
      MaxInstructionCount = maxInstructionCount;
      _instMem = new byte[maxInstructionCount*sizeof (DiStorm3._DecodedInst)];
      _gch = GCHandle.Alloc(_instMem, GCHandleType.Pinned);
      _instMemPtr = (DiStorm3._DecodedInst*) _gch.AddrOfPinnedObject();
    }

    internal byte[] _instMem;
    internal GCHandle _gch;
    internal unsafe DiStorm3._DecodedInst *_instMemPtr;

    public DecodedInst[] Instructions
    {
      get
      {
        var dinsts = new DecodedInst[UsedInstructionCount];

        for (var i = 0; i < UsedInstructionCount; i++)
          dinsts[i] = CreateDecodedInstObj(&_instMemPtr[i]);
        dr.Instructions = dinsts;

      }
    }

    private static unsafe DecodedInst CreateDecodedInstObj(DiStorm3._DecodedInst* inst)
    {
      return new DecodedInst {
        Mnemonic = new String(inst->mnemonic.p),
        Operands = new String(inst->operands.p),
        Hex = new string(inst->instructionHex.p),
        Size = inst->size,
        Offset = inst->offset
      };
    }

    public int MaxInstructionCount { get; internal set; }

    public int UsedInstructionCount { get; internal set; }
  }
}