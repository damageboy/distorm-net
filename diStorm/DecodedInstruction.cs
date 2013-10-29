using System;

namespace diStorm
{
  public class DecodedInstruction {

    internal DecodedInstruction() { }

    public string Mnemonic { get; internal set; }

    public string Operands { get; internal set; }

    public string Hex { get; internal set; }

    public uint Size { get; internal set; }

    public IntPtr Offset { get; internal set; }

    internal static unsafe DecodedInstruction FromUnsafe(DecodedInstructionStruct* inst)
    {
      return new DecodedInstruction
      {
        Mnemonic = new String(inst->Mnemonic.p),
        Operands = new String(inst->Operands.p),
        Hex = new string(inst->InstructionHex.p),
        Size = inst->Size,
        Offset = inst->Address
      };
    }

  }
}