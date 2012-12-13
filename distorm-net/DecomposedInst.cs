using System;
using DiStorm;

public class DecomposedInst 
{
  public class ImmVariant {
    public ulong mValue;
    public int mSize;

    public ulong getImm() {
			return mValue;
		}

		public int getSize() {
			return mSize;
		}
	}
  public class DispVariant {
    public ulong mDisplacement;
    public int mSize;

    public ulong getDisplacement() {
			return mDisplacement;
		}

		public int getSize() {
			return mSize;
		}
	}
  internal int _segment;
  public IntPtr Address { get; internal set; }
  public ushort Flags { get; internal set; }
  public int Size { get; internal set; }
  public Opcode Opcode { get; internal set; }
  public int Segment { get { return _segment & 0x7f; } }
  public bool IsSegmentDefault { get { return (_segment & 0x80) == 0x80; } }
  public int Base { get; internal set; }
  public int Scale { get; internal set; }
  public int UnusedPrefixesMask { get; internal set; }
  public int Meta { get; internal set; }
  public int RegistersMask { get; internal set; }
  public int ModifiedFlagsMask { get; internal set; }
  public int TestedFlagsMask { get; internal set; }
  public int UndefinedFlagsMask { get; internal set; }
  public ImmVariant Imm { get; internal set; }
  public DispVariant Disp { get; internal set; }
  public Operand[] Operands { get; internal set; }
}