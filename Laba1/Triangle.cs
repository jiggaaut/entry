using System;
using System.Linq;

namespace Laba1
{
    public class Triangle : IHaveSquare
    {
        public decimal Sq => IsRight ? _a * _b / 2 : F((_a, _b, _c));

        public bool IsRight { get; }

        private readonly decimal _a;

        private readonly decimal _b;

        private readonly decimal _c;

        public Triangle(decimal a, decimal b, decimal c)
        {
            
            if (a <= 0 ||
                b <= 0 ||
                c <= 0 ||
                c <= a + b ||
                b <= a + c ||
                a <= b + c) throw new ArgumentOutOfRangeException();

            var q = new[] { a, b, c };
            _c = q.Max();
            var x = q.Except(new[] { _c});
            _a = x.First();
            _b = x.Last();

            IsRight = _c * _c == _a * _a + _b * _b;

        }

        private static readonly Func<ValueTuple<decimal, decimal, decimal>, decimal> F = a =>
        {
            var (item1, item2, item3) = a;
            var p = (item1 + item2 + item3) / 2;
            var sq = (decimal)Math.Sqrt((double)(p * (p - item1) * (p - item2) * (p - item3)));
            return sq;
        };


    }
}
