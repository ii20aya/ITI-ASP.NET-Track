using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class Point
    {
        #region Data
        int x, y;
        #endregion

        #region Ctors
        public Point()
        {
            x = y = 0;
            Console.WriteLine("Point def ctor");
        }

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
            Console.WriteLine("Point 2p ctor");
        }
        #endregion

        #region Methods
        public void SetX(int _x) { x = _x; }
        public void SetY(int _y) { y = _y; }
        public int GetX() { return x; }
        public int GetY() { return y; }

        public string PrintPoint()
        {
            return $"({x},{y})";
        }
        #endregion
    }
}