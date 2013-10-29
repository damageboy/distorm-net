
using System;

namespace diStorm
{

  public enum OperandType : byte
  {
    None,
    Reg,
    Imm,
    Imm1,
    Imm2,
    Disp,
    Smem,
    Mem,
    Pc,
    Ptr
  }

  public class Operand
  {
    public OperandType Type { get; internal set; }
    public Register Register { 
      get {
        if (Type != OperandType.Reg)
          throw new ArgumentException("Operand is not a register");
        return (Register) Index;
      }
    }
    public int Index { get; internal set; }
    public int Size { get; internal set; }
  }
}