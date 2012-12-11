

using System;

namespace DiStorm
{
  public class DecodedInst
  {
    internal DecodedInst()
    {
    }

    internal String mMnemonic;
    internal String mOperands;
    internal String mHex;
    internal uint mSize;
    internal IntPtr mOffset;

    public String getMnemonic()
    {
      return mMnemonic;
    }

    public String getOperands()
    {
      return mOperands;
    }

    public String getHex()
    {
      return mHex;
    }

    public uint getSize()
    {
      return mSize;
    }

    public IntPtr getOffset()
    {
      return mOffset;
    }
  }
}