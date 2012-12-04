using System;

namespace DiStorm
{
  public class CodeInfo
  {
    public CodeInfo(long codeOffset, byte[] rawCode, DecodeType dt, int features)
    {
      mCode = new byte[rawCode.Length];
      Array.Copy(rawCode, mCode, mCode.Length);

      mCodeOffset = codeOffset;
      mDecodeType = dt;
      mFeatures = features;
    }

    internal long mCodeOffset;
    internal long mNextOffset;
    internal byte[] mCode;
    internal DecodeType mDecodeType;
    internal int mFeatures;
  }
}
