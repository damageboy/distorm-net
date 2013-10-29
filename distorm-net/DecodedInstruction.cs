using System;

namespace DiStorm
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
        Mnemonic = new String(inst->mnemonic.p),
        Operands = new String(inst->operands.p),
        Hex = new string(inst->instructionHex.p),
        Size = inst->size,
        Offset = inst->offset
      };
    }

  }
}