
namespace DiStorm
{
  public class DecodedResult {
    public DecodedResult(int maxInstructions) 
    {
      mMaxInstructions = maxInstructions;
      mInstructions = null;
    }

    public DecodedInst[] mInstructions;
    private int mMaxInstructions;
  }
}