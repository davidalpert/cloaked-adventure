using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using PowerAssert;

namespace TestHarness
{
    public class Class1
    {
        [Fact]
        public void something()
        {
            int x = 11;
            int y = 6;
            DateTime d = new DateTime(2010, 3, 1);
            PAssert.IsTrue(() => x + 5 == d.Month * y);
        }

        [Fact]
        public void something_else()
        {
            Func<int, double, int, double, double> nc = (y1, p, y2, a) =>
                y1 * Math.Log(p) + y2 * Math.Log(a);

            int x = 11;
            int y = 3;
            double c = 12.39;
            double d = 11.213;

            PAssert.IsTrue(() => nc(x, c, y, d) == 3.43);
        }
 }
}
