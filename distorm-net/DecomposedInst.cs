using DiStorm;

public class DecomposedInst {
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

  public long mAddr;
  public int mSize;
  public int mFlags;
  public int mSegment;
  public int mBase, mScale;
  public int mOpcode;
	public Operand[] mOperands;
	public DispVariant mDisp;
	public ImmVariant mImm;
  public int mUnusedPrefixesMask;
  public int mMeta;
  public int mRegistersMask;
  public int mModifiedFlagsMask;
  public int mTestedFlagsMask;
  public int mUndefinedFlagsMask;

	public long getAddress() {
		return mAddr;
	}
	public int getSize() {
		return mSize;
	}
	public Opcode getOpcode() {
		return (Opcode) mOpcode;
	}
	public int getSegment() {
		return mSegment & 0x7f;
	}
	public bool isSegmentDefault() {
		return (mSegment & 0x80) == 0x80;
	}
	public int getBase() {
		return mBase;
	}
	public int getScale() {
		return mScale;
	}
	public int getUnusedPrefixesMask() {
		return mUnusedPrefixesMask;
	}
	public int getMeta() {
		return mMeta;
	}
	public int getRegistersMask() {
		return mRegistersMask;
	}
	public int getModifiedFlagsMask() {
		return mModifiedFlagsMask;
	}
	public int getTestedFlagsMask() {
		return mTestedFlagsMask;
	}
	public int getUndefinedFlagsMask() {
		return mUndefinedFlagsMask;
	}
}