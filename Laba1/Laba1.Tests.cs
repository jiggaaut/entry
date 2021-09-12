using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Laba1
{
    internal class Laba1
    {
        [Test]
        [TestCaseSource(nameof(GetCases))]
        public void Check(ValueTuple<int, int, int> src)
        {
            var (a, b, c) = src;
            if (a <= 0 ||
                b <= 0 ||
                c <= 0 ||
                c <= a + b ||
                b <= a + c ||
                a <= b + c)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => { new Triangle(a, b, c); });
            }
            else
            {
                var p = (a + b + c) / 2;
                var sq = (decimal)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Assert.AreEqual(sq, new Triangle(a, b, c).Sq);
            }
        }

        [Test]
        [TestCaseSource(nameof(GetCircleCases))]
        public void CheckCircle(decimal r)
        {
            if (r <= 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => { new Circle(r); });
            }
            else
            {
                var sq = (decimal)Math.PI * r * r;
                Assert.AreEqual(Math.Round(sq, 3) , Math.Round(new Circle(r).Sq, 3) );
            }
        }

        public static IEnumerable<(int q1, int q2, int q3)> GetCases()
        {
            var src = Enumerable.Range(0, 10);
            var enumerable = src as int[] ?? src.ToArray();
            return from q1 in enumerable
                   from q2 in enumerable
                   from q3 in enumerable
                   select (q1, q2, q3);
        }

        public static IEnumerable<decimal> GetCircleCases()
        {
            var rnd = new Random();
            return from a in Enumerable.Range(-10, 40)
                   from b in new[] { (decimal)rnd.NextDouble(), (decimal)rnd.NextDouble(), (decimal)rnd.NextDouble(), (decimal)rnd.NextDouble(), (decimal)rnd.NextDouble() }
                   select (decimal)a / 10 + b / 10;

        }
    }
}
