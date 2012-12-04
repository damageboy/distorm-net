﻿using System;
using System.Reflection;
using System.Reflection.Emit;
using DiStorm;

namespace TestDiStorm
{
  public class Program
  {
    private static IntPtr LeakNativeMethodPtr(MethodInfo x)
    {

      if ((x.MethodImplementationFlags & MethodImplAttributes.InternalCall) != 0)
        Console.WriteLine("{0} is an InternalCall method. These methods always point to the same address.", x.Name);
      var domain = AppDomain.CurrentDomain;
      var dynAsm = new AssemblyName("MethodLeakAssembly");
      var asmBuilder = domain.DefineDynamicAssembly(dynAsm, AssemblyBuilderAccess.Run);
      var moduleBuilder = asmBuilder.DefineDynamicModule("MethodLeakModule");
      var typeBuilder = moduleBuilder.DefineType("MethodLeaker", TypeAttributes.Public);
      var p = new Type[0];
      var methodBuilder = typeBuilder.DefineMethod("LeakNativeMethodPtr", MethodAttributes.Public | MethodAttributes.Static, typeof(IntPtr), null);
      var generator = methodBuilder.GetILGenerator();

      // Push unmanaged pointer to MethodInfo onto the evaluation stack      
      generator.Emit(OpCodes.Ldftn, x);
      // Convert the pointer to type - unsigned int64
      //generator.Emit(OpCodes.Conv_Ovf_U);
      generator.Emit(OpCodes.Ret);

      // Assemble everything
      var type = typeBuilder.CreateType();

      var method = type.GetMethod("LeakNativeMethodPtr");

      try {
        // Call the method and return its JITed address
        var address = (IntPtr) method.Invoke(null, new object[0]);

        Console.WriteLine("0x{0}", address.ToString(string.Format("X{0})", IntPtr.Size * 2)));
        return address;
      }
      catch (Exception e) {
        Console.WriteLine("{0} cannot return an unmanaged address.");
      }
      return IntPtr.Zero;
    }


    private static unsafe void Main(string[] args)
    {
      Console.WriteLine("sizeof(native int)={0}", IntPtr.Size);
      Console.WriteLine("sizeof(DiStorm3._DInst)={0}", sizeof(DiStorm3._DInst));
      Console.WriteLine("sizeof(DiStorm3._CodeInfo)={0}", sizeof(DiStorm3._CodeInfo));
      Console.WriteLine("sizeof(DiStorm3._Value)={0}", sizeof(DiStorm3._Value));
      Console.WriteLine("sizeof(DiStorm3._Operand)={0}", sizeof(DiStorm3._Operand));
      var buf = new byte[4];
      buf[0] = (byte) 0xc3;
      buf[1] = (byte) 0x33;
      buf[2] = (byte) 0xc0;
      buf[3] = (byte) 0xc3;
      var ci = new CodeInfo((long) 0x1000, buf, DecodeType.Decode32Bits, 0);
      var dr = new DecodedResult(10);
      DiStorm3.Decode(ci, dr);

      foreach (var x in dr.mInstructions) {
        var s = String.Format("{0:X} {1} {2}", x.getOffset(), x.getMnemonic(), x.getOperands());
        Console.WriteLine(s);
      }

      var dr2 = new DecomposedResult(10);
      DiStorm3.Decompose(ci, dr2);

      foreach (var y in dr2.mInstructions) {
        if (y.getOpcode() != Opcode.RET)
        {
          //var x = DiStorm3.Format(ci, y);
          //var s = String.Format("{0:X} {1} {2}", x.getOffset(), x.getMnemonic(), x.getOperands());
          //Console.WriteLine(s);
        }
      }

    }
  }
}
