using System;

namespace DiStorm
{
  public class CodeInfo
  {
    public CodeInfo(long codeOffset, byte[] rawCode, DecodeType dt, int features)
    {
      _code = new byte[rawCode.Length];
      Array.Copy(rawCode, _code, _code.Length);

      _codeOffset = codeOffset;
      _decodeType = dt;
      _features = features;
    }

    internal long _codeOffset;
    internal long _nextOffset;
    internal byte[] _code;
    internal DecodeType _decodeType;
    internal int _features;
  }

  public class UnsafeCodeInfo
  {
    public unsafe UnsafeCodeInfo(long codeOffset, byte *rawCode, int rawCodeLength, DecodeType dt, int features)
    {
      _codeOffset = codeOffset;
      _decodeType = dt;
      _features = features;
      _code = rawCode;
      _codeLength = rawCodeLength;
    }

    internal long _codeOffset;
    internal long _nextOffset;
    internal unsafe byte *_code;
    internal int _codeLength;
    internal DecodeType _decodeType;
    internal int _features;
  }
}
