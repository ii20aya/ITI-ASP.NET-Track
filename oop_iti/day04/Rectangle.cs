using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class Rectangle
    {
        #region Data
        Point upperLeft;
        Point lowerRight;
        #endregion

        #region Ctors
        public Rectangle()
        {
            upperLeft = new Point();
            lowerRight = new Point();
            Console.WriteLine("Rect def ctor");
        }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            upperLeft = new Point(x1, y1);
            lowerRight = new Point(x2, y2);
            Console.WriteLine("Rect 4p ctor");
        }
        #endregion

        #region Methods
        public string PrintRect()
        {
            return $"Rectangle UL={upperLeft.PrintPoint()}, LR={lowerRight.PrintPoint()}";
        }
        #endregion
    }
}