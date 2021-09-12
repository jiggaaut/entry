using System;

namespace Laba1
{
    public class Circle: IHaveSquare
    {
        public decimal Sq { get; }

        private decimal _r;

        public Circle(decimal r)
        {
            if (r <= 0) throw new ArgumentOutOfRangeException();

            _r = r;
            Sq = (decimal)(Math.PI * Math.Pow((double)_r, 2));
        }
    }
}
