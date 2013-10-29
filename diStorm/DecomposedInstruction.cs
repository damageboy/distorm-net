using System;

namespace diStorm
{
  public class DecomposedInstruction
  {
    public class ImmVariant
    {
      public ulong Imm { get; internal set; }

      public int Size { get; internal set; }
    }

    public class DispVariant
    {
      public ulong Displacement { get; internal set; }

      public int Size { get; internal set; }
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

    public static unsafe DecomposedInstruction FromUnsafe(DecomposedInstructionStruct* srcInst)
    {
      var di = new DecomposedInstruction {
        Address = srcInst->Address,
        Flags = srcInst->flags,
        Size = srcInst->Size,
        _segment = srcInst->segment,
        Base = srcInst->ibase,
        Scale = srcInst->scale,
        Opcode = srcInst->Opcode,
        UnusedPrefixesMask = srcInst->unusedPrefixesMask,
        Meta = srcInst->meta,
        RegistersMask = srcInst->usedRegistersMask,
        ModifiedFlagsMask = srcInst->modifiedFlagsMask,
        TestedFlagsMask = srcInst->testedFlagsMask,
        UndefinedFlagsMask = srcInst->undefinedFlagsMask
      };

      /* Simple fields: */

      /* Immediate variant. */
      var immVariant = new DecomposedInstruction.ImmVariant
      {
        Imm = srcInst->imm.qword,
        Size = 0
      };
      /* The size of the immediate is in one of the operands, if at all. Look for it below. Zero by default. */

      /* Count operands. */
      var operandsNo = 0;
      for (operandsNo = 0; operandsNo < DecomposedInstructionStruct.OPERANDS_NO; operandsNo++)
      {
        if (srcInst->ops[operandsNo].Type == OperandType.None)
          break;
      }

      var ops = new Operand[operandsNo];

      for (var j = 0; j < operandsNo; j++)
      {
        var srcOp = srcInst->ops[j];
        if (srcOp.Type == OperandType.Imm)
        {
          /* Set the size of the immediate operand. */
          immVariant.Size = srcInst->ops[j].Size;
        }

        var op = new Operand
        {
          Type = srcOp.Type,
          Index = srcOp.index,
          Size = srcOp.Size
        };

        ops[j] = op;
      }
      di.Operands = ops;

      /* Attach the immediate variant. */
      di.Imm = immVariant;

      /* Displacement variant. */
      var disp = new DecomposedInstruction.DispVariant
      {
        Displacement = srcInst->disp,
        Size = srcInst->dispSize
      };

      di.Disp = disp;
      return di;
    }
  }
}