using System;

namespace diStorm
{
  /// <summary>
  /// Described the type of operand stored in the <see cref="Operand"/> class
  /// </summary>
  public enum OperandType : byte
  {
    /// <summary>
    /// No operand, operand is to be ignored.
    /// </summary>
    None,

    /// <summary>
    /// Register operand, value should be retrieved from the <see cref="DecodedInstruction.Operands"/>
    /// using the <see cref="Operand.Register"/> property
    /// </summary>
    Register,

    /// <summary>
    /// Immediate operand, value should be retrieved using <see cref="DecomposedInstruction.ImmediateValue"/>
    /// </summary>
    Immediate,

    /// <summary>
    /// Immediate operand, value should be retrieved using <see cref="DecomposedInstruction.ImmediateValue"/>/
    /// <see cref="ImmediateValue.Extra"/>/<see cref="ExtraStruct.I1"/>
    /// </summary>
    Immediate1,

    /// <summary>
    /// Immediate operand, value should be retrieved using <see cref="DecomposedInstruction.ImmediateValue"/>/<see cref="ImmediateValue.Extra"/>/<see cref="ExtraStruct.I2"/>
    /// </summary>
    Immediate2,

    /// <summary>
    /// Memory reference with displacement, value can be retrieved using <see cref="DecomposedInstruction.Displacement"/>
    /// </summary>
    Displacement,

    /// <summary>
    /// Simple memory displacement with optional displacement (For example, a single register memory dereference)
    /// </summary>
    SimpleMemory,

    /// <summary>
    /// Complex memory dereference (Optional <see cref="DecomposedInstruction.Scale"/>, <see cref="Operand.Index"/>,
    /// <see cref="DecomposedInstruction.Base"/>, <see cref="DecomposedInstruction.Displacement"/>
    /// </summary>
    ComplexMemory,

    /// <summary>
    /// Relative to ProgramCounter (EIP in x86/x64), for branching instructions. value should be retrieved
    /// using <see cref="DecomposedInstruction.ImmediateValue"/>/<see cref="ImmediateValue.RelativeAddress"/>/<see cref="ExtraStruct.I1"/>
    /// </summary>
    ProgramCounter,

    /// <summary>
    /// Absolute far target address for a branching instruction. value should be retrieved
    /// using <see cref="DecomposedInstruction.ImmediateValue"/>.<see cref="ImmediateValue.Pointer"/>.
    /// <see cref="ImmediatePointerStruct.Segment"/>|<see cref="ImmediatePointerStruct.Offset"/>
    /// </summary>
    Pointer
  }

  public class Operand
  {
    /// <summary>
    /// The different operand types "instruct" how to retrieve the actual operand value, therefore this member is
    /// normally accessed before anything else in the <see cref="Operand"/> class
    /// </summary>
    public OperandType Type { get; internal set; }

    public Register Register {
      get {
        switch (Type) {
          case OperandType.Register:
            break;
          case OperandType.SimpleMemory:
            break;
          case OperandType.ComplexMemory:
            break;
          default:
            throw new ArgumentException("Operand is not a register");
        }
        return (Register) Index;
      }
    }

    /// <summary>
    /// 	<para>Index, used according to the Type:</para>
    /// 	<para></para>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<term>Type</term>
    /// 			<description>Value Means</description>
    /// 		</listheader>
    /// 		<item>
    /// 			<term><see cref="OperandType.Register"/></term>
    /// 			<description>Hold the register used, can be accessed directly using <see cref="Register"/></description>
    /// 		</item>
    /// 		<item>
    /// 			<term><see cref="OperandType.SimpleMemory"/></term>
    /// 			<description>Hold the 'Base' register, e.g.: [ECX], [EBX+0x1234]</description>
    /// 		</item>
    /// 		<item>
    /// 			<term><see cref="OperandType.ComplexMemory"/></term>
    /// 			<description>Holds the 'index' register. e.g.: [EAX*4] is in operand.index.</description>
    /// 		</item>
    /// 	</list>
    /// 	<para></para>
    /// </summary>
    public int Index { get; internal set; }

    /// <summary>
    /// The size of the operand in bits
    /// </summary>
    public int Size { get; internal set; }
  }
}