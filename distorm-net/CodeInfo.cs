using System;

namespace diStorm
{
  public class CodeInfo
  {
    public unsafe CodeInfo(long codeOffset, byte[] rawCode, DecodeType dt, int features = 0)
    {
      _code = rawCode;
      _codePtr = null;
      _codeOffset = codeOffset;
      _decodeType = dt;
      _features = features;
    }

    public unsafe CodeInfo(long codeOffset, byte *code, int codeLength, DecodeType dt, int features = 0)
    {
      _code = null;
      _codePtr = code;
      _codeLength = codeLength;
      _codeOffset = codeOffset;
      _decodeType = dt;
      _features = features;
    }

    internal long _codeOffset;
    internal long _nextOffset;
    internal byte[] _code;
    internal unsafe byte* _codePtr;
    internal int _codeLength;
    internal DecodeType _decodeType;
    internal int _features;
  }
}