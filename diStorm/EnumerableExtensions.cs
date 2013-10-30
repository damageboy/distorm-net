// /////////////////////////////////////////////////////////////////
// //
// //
// //    SharpTrader.NET - Trading Software & Framework
// //
//
// //    (C)opyright 2006, Damage INC. Industries
// //    All rights reserved.
// //    Authored by: Dan Shechter, 2013-10-30
// //
// /////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace diStorm {

  public static class EnumerableExtensions
  {
    public static IEnumerable<T> DisposeAfter<T>(this IEnumerable<T> enumerable) where T : IDisposable
    {
      foreach (var x in enumerable) {
        try {
          yield return x;
        }
        finally {
          x.Dispose();
        }
      }
    }
  }
}