using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace diStorm.Tests {

  public class diStormTests {

    private byte[] code = {0xc3, 0x33, 0xc0, 0xc3};

    [Test]
    public unsafe void TestDecodeByteArray()
    {
      var ci = new CodeInfo(0x1000, code, DecodeType.Decode32Bits);

      using (var decoded = DiStorm3.Decode(ci, 10)) {
        TestInstructionsUnmanaged(decoded.InstructionsPointer);
        TestInstructionsManaged(decoded.Instructions);
      }
    }

    [Test]
    public unsafe void TestDecodeBytePointer()
    {
      var gch = GCHandle.Alloc(code, GCHandleType.Pinned);

      var ci = new CodeInfo(0x1000, (byte*) gch.AddrOfPinnedObject().ToPointer(), code.Length, DecodeType.Decode32Bits);
      using (var decoded = DiStorm3.Decode(ci, 10)) {
        TestInstructionsUnmanaged(decoded.InstructionsPointer);
        TestInstructionsManaged(decoded.Instructions);
      }

      gch.Free();
    }

    [Test]
    public unsafe void TestDecomposeByteArray()
    {
      var ci = new CodeInfo(0x1000, code, DecodeType.Decode32Bits);

      using (var decomposed = DiStorm3.Decompose(ci, 10)) {
        TestInstructionsUnmanaged(decomposed.InstructionsPointer);
        //TestInstructionsManaged(decoded.Instructions);
      }
    }

    [Test]
    public unsafe void TestDecomposeBytePointer()
    {
      var gch = GCHandle.Alloc(code, GCHandleType.Pinned);

      var ci = new CodeInfo(0x1000, (byte*) gch.AddrOfPinnedObject().ToPointer(), code.Length, DecodeType.Decode32Bits);
      using (var decomposed = DiStorm3.Decompose(ci, 10)) {
        TestInstructionsUnmanaged(decomposed.InstructionsPointer);
        //TestInstructionsManaged(decoded.Instructions);
      }

      gch.Free();
    }

    private static void TestInstructionsManaged(DecodedInstruction[] insts)
    {
      Assert.That(insts, Has.Length.EqualTo(3));
      Assert.That(insts[0].Offset.ToInt32(), Is.EqualTo(0x1000));
      Assert.That(insts[0].Mnemonic, Is.EqualTo("RET"));
      Assert.That(insts[1].Offset.ToInt32(), Is.EqualTo(0x1001));
      Assert.That(insts[1].Mnemonic, Is.EqualTo("XOR"));
      Assert.That(insts[2].Offset.ToInt32(), Is.EqualTo(0x1003));
      Assert.That(insts[2].Mnemonic, Is.EqualTo("RET"));
    }

    private static unsafe void TestInstructionsUnmanaged(DecodedInstructionStruct *insts)
    {
      Assert.That(insts[0].Address.ToInt32(), Is.EqualTo(0x1000));
      Assert.That(new String(insts[0].Mnemonic.p), Is.EqualTo("RET"));
      Assert.That(insts[1].Address.ToInt32(), Is.EqualTo(0x1001));
      Assert.That(new String(insts[1].Mnemonic.p), Is.EqualTo("XOR"));
      Assert.That(insts[2].Address.ToInt32(), Is.EqualTo(0x1003));
      Assert.That(new String(insts[2].Mnemonic.p), Is.EqualTo("RET"));
    }

    private static unsafe void TestInstructionsUnmanaged(DecomposedInstructionStruct *insts)
    {
      Assert.That(insts[0].Address.ToInt32(), Is.EqualTo(0x1000));
      Assert.That(insts[0].Opcode, Is.EqualTo(Opcode.RET));
      Assert.That(insts[0].Size, Is.EqualTo(1));
      Assert.That(insts[1].Address.ToInt32(), Is.EqualTo(0x1001));
      Assert.That(insts[1].Opcode, Is.EqualTo(Opcode.XOR));
      Assert.That(insts[1].ops[0].Type, Is.EqualTo(OperandType.Reg));
      Assert.That(insts[1].ops[0].Register, Is.EqualTo(Register.R_EAX));
      Assert.That(insts[1].ops[0].Size, Is.EqualTo(32));
      Assert.That(insts[1].ops[1].Type, Is.EqualTo(OperandType.Reg));
      Assert.That(insts[1].ops[1].Register, Is.EqualTo(Register.R_EAX));
      Assert.That(insts[1].ops[1].Size, Is.EqualTo(32));
      Assert.That(insts[1].Size, Is.EqualTo(2));
      Assert.That(insts[2].Address.ToInt32(), Is.EqualTo(0x1003));
      Assert.That(insts[2].Opcode, Is.EqualTo(Opcode.RET));
      Assert.That(insts[2].Size, Is.EqualTo(1));
    }

  }
}