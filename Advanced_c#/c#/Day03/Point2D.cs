using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    using System;

    namespace Day5Lab
    {

        internal class Point2D : IComparable<Point2D>
        {

            public int X { get; set; }


            public int Y { get; set; }


            public Point2D(int x, int y)
            {
                X = x;
                Y = y;
            }

            /// <summary>
            /// Compares the current point with another point for sorting.
            /// Priority: X-axis, then Y-axis if X is equal.
            /// </summary>
            /// <param name="other">The point to compare with.</param>
            /// <returns>A value indicating the relative order.</returns>
            public int CompareTo(Point2D? other)
            {
                if (other == null) return 1;


                if (this.X != other.X)
                    return this.X.CompareTo(other.X);


                return this.Y.CompareTo(other.Y);
            }

            /// <summary>
            /// Returns a string representation of the point.
            /// </summary>
            public override string ToString() => $"({X}, {Y})";
        }
    }
}