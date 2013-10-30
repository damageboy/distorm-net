using System;
using System.Runtime.InteropServices;

namespace diStorm
{
  public class DecomposedResult : IDisposable
  {
    public unsafe DecomposedResult(int maxInstructions)
    {
      MaxInstructions = maxInstructions;
      _instMem = new byte[maxInstructions * sizeof(DecomposedInstructionStruct)];
      _gch = GCHandle.Alloc(_instMem, GCHandleType.Pinned);
      _instructionsPointer = (DecomposedInstructionStruct *)_gch.AddrOfPinnedObject();
    }

    private byte[] _instMem;
    private GCHandle _gch;
    private readonly unsafe DecomposedInstructionStruct* _instructionsPointer;
    private DecomposedInstruction[] _instructions;
    internal bool _isDisposed;

    public unsafe DecomposedInstruction[] Instructions
    {
      get {
        if (_instructions != null)
          return _instructions;

        _instructions = new DecomposedInstruction[UsedInstructions];
        for (var i = 0; i < UsedInstructions; i++)
          _instructions[i] = DecomposedInstruction.FromUnsafe(InstructionsPointer + i);
        return _instructions;

      }
    }

    public int MaxInstructions { get; private set; }

    public int UsedInstructions { get; internal set; }

    public unsafe DecomposedInstructionStruct* InstructionsPointer { get { return _instructionsPointer; } }

    #region Implementation of IDisposable

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      if (_isDisposed)
        return;
      _gch.Free();
      _isDisposed = true;
    }
    #endregion Implementation of IDisposable

    ~DecomposedResult() { Dispose(); }
  }
}