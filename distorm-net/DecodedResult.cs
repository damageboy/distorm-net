using System;
using System.Runtime.InteropServices;

namespace DiStorm
{
  public class DecodedResult
  {
    public unsafe DecodedResult(int maxInstructionCount)
    {
      MaxInstructionCount = maxInstructionCount;
      _instMem = new byte[maxInstructionCount*sizeof (DecodedInstructionStruct)];
      _gch = GCHandle.Alloc(_instMem, GCHandleType.Pinned);
      _instMemPtr = (DecodedInstructionStruct*) _gch.AddrOfPinnedObject();
    }

    internal byte[] _instMem;
    internal GCHandle _gch;
    private unsafe DecodedInstructionStruct *_instMemPtr;
    private DecodedInstruction[] _instructions;

    public unsafe DecodedInstruction[] Instructions
    {
      get {
        if (_instructions != null)
          return _instructions;
        
        var dinsts = new DecodedInstruction[UsedInstructionCount];
        for (var i = 0; i < UsedInstructionCount; i++)
          dinsts[i] = DecodedInstruction.FromUnsafe(&_instMemPtr[i]);
        _instructions = dinsts;
        return _instructions;
      }
    }

    public int MaxInstructionCount { get; internal set; }
    public int UsedInstructionCount { get; internal set; }
    public unsafe DecodedInstructionStruct* InstructionsPointer { get { return _instMemPtr; } }
  }
}