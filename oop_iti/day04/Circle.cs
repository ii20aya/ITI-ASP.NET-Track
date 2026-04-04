using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class Circle
    {
        #region Data
        Point center;
        int radius;
        #endregion

        #region Methods
        public void SetCenter(Point _center)
        {
            center = _center;
        }

        public void SetRadius(int _radius)
        {
            radius = _radius;
        }

        public string PrintCircle()
        {
            return $"Circle center={center.PrintPoint()}, radius={radius}";
        }
        #endregion
    }
}