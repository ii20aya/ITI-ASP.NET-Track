using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class Line
    {
        #region Data
        Point start = new Point();
        Point end = new Point();
        #endregion

        #region Ctors
        public Line()
        {
            Console.WriteLine("Line def ctor");
        }

        public Line(int x1, int y1, int x2, int y2)
        {
            start.SetX(x1);
            start.SetY(y1);
            end.SetX(x2);
            end.SetY(y2);

            Console.WriteLine("Line 4p ctor");
        }
        #endregion

        #region Methods
        public string PrintLine()
        {
            return $"Line start={start.PrintPoint()}, end={end.PrintPoint()}";
        }
        #endregion
    }
}