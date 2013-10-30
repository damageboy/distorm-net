using System;
using System.Runtime.InteropServices;

namespace diStorm
{
  public class DecodedResult : IDisposable
  {
    public unsafe DecodedResult(int maxInstructionCount)
    {
      MaxInstructionCount = maxInstructionCount;
      _instMem = new byte[maxInstructionCount*sizeof (DecodedInstructionStruct)];
      _gch = GCHandle.Alloc(_instMem, GCHandleType.Pinned);
      _instructionsPointer = (DecodedInstructionStruct*) _gch.AddrOfPinnedObject();
    }

    internal byte[] _instMem;
    private GCHandle _gch;
    private readonly unsafe DecodedInstructionStruct *_instructionsPointer;
    private DecodedInstruction[] _instructions;
    internal bool _isDisposed;

    public unsafe DecodedInstruction[] Instructions
    {
      get {
        if (_instructions != null)
          return _instructions;

        var dinsts = new DecodedInstruction[UsedInstructionCount];
        for (var i = 0; i < UsedInstructionCount; i++)
          dinsts[i] = DecodedInstruction.FromUnsafe(&_instructionsPointer[i]);
        _instructions = dinsts;
        return _instructions;
      }
    }

    public int MaxInstructionCount { get; internal set; }

    public int UsedInstructionCount { get; internal set; }

    public unsafe DecodedInstructionStruct* InstructionsPointer { get { return _instructionsPointer; } }

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

    ~DecodedResult() { Dispose(); }
  }
}