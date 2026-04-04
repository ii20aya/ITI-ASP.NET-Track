using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    abstract class Geoshape
    {
        protected double dim1;
        protected double dim2;

        public Geoshape()
        {
            dim1 = dim2 = 0;
        }

        public Geoshape(double _d1, double _d2)
        {
            dim1 = _d1;
            dim2 = _d2;
        }

        public Geoshape(double _d)
        {
            dim1 = dim2 = _d;
        }

        public abstract double Area();
    }
}
