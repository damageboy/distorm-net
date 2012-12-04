
namespace DiStorm
{

  public enum OperandType
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
    private int mType;
    private int mIndex;
    private int mSize;

    public OperandType getType()
    {
      return (OperandType) mType;
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