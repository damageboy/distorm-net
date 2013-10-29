using System;
using System.Runtime.InteropServices;

namespace DiStorm
{
  public class DecomposedResult
  {
    public unsafe DecomposedResult(int maxInstructions)
    {
      MaxInstructions = maxInstructions;

      _instMem = new byte[maxInstructions * sizeof(DecomposedInstructionStruct)];
      _gch = GCHandle.Alloc(_instMem, GCHandleType.Pinned);
      _instMemPtr = (DecomposedInstructionStruct *)_gch.AddrOfPinnedObject();
    }

    internal byte[] _instMem;
    internal GCHandle _gch;
    public unsafe DecomposedInstructionStruct* _instMemPtr;
    private DecomposedInstruction[] _instructions;

    public unsafe DecomposedInstruction[] Instructions
    {
      get {
        if (_instructions != null)
          return _instructions;

        _instructions = new DecomposedInstruction[UsedInstructions];
        for (var i = 0; i < UsedInstructions; i++)
          _instructions[i] = DecomposedInstruction.FromUnsafe(_instMemPtr + i);
        return _instructions;

      }
    }

    public int MaxInstructions { get; private set; }
    public int UsedInstructions { get; internal set; }
  }
}