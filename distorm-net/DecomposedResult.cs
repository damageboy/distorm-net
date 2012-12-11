namespace DiStorm
{
  public class DecomposedResult
  {
    public DecomposedResult(int maxInstructions)
    {
      mMaxInstructions = maxInstructions;
      mInstructions = null;
    }

    public DecomposedInst[] mInstructions;
    public int mMaxInstructions;
  }
}