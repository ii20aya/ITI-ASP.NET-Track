using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class Triangle
    {
        #region Data
        Point p1;
        Point p2;
        Point p3;
        #endregion

        #region Ctors
        public Triangle()
        {
            Console.WriteLine("Tri def ctor");
        }

        public Triangle(Point _p1, Point _p2, Point _p3)
        {
            p1 = _p1;
            p2 = _p2;
            p3 = _p3;
            Console.WriteLine("Tri 3p ctor");
        }
        #endregion

        #region Methods
        public void SetP1(Point _p1) { p1 = _p1; }
        public void SetP2(Point _p2) { p2 = _p2; }
        public void SetP3(Point _p3) { p3 = _p3; }

        public string PrintTri()
        {
            return $"Tri p1={p1.PrintPoint()}, p2={p2.PrintPoint()}, p3={p3.PrintPoint()}";
        }
        #endregion
    }
}