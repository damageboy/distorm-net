
namespace DiStorm
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
    public OperandType mType;
    public int mIndex;
    public int mSize;

    public OperandType getType()
    {
      return mType;
    }

    public int getIndex()
    {
      return mIndex;
    }

    public int getSize()
    {
      return mSize;
    }
  }
}