using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    class Rect : Geoshape
    {
        public Rect(double _d1, double _d2) : base(_d1, _d2)
        {
        }

        public override double Area()
        {
            return dim1 * dim2;
        }
    }





    class Square : Geoshape
    {
        public Square(double _d) : base(_d)
        {
        }

        public override double Area()
        {
            return dim1 * dim2;
        }
    }









    class Circle : Geoshape
    {
        public Circle(double _radius) : base(_radius)
        {
        }

        public override double Area()
        {
            return Math.PI * dim1 * dim2;
        }
    }








    sealed class Tri : Geoshape
    {
        public Tri(double _base, double _height) : base(_base, _height)
        {
        }

        public override double Area()
        {
            return 0.5 * dim1 * dim2;
        }
    }

}
