using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    class Utility
    {

        public static double SumOfAreas(Rect[] rarr, Square[] sarr, Tri[] tarr, Circle[] carr)
        {
            double sum = 0;

            for (int i = 0; i < rarr.Length; i++)
                sum += rarr[i].Area();

            for (int i = 0; i < sarr.Length; i++)
                sum += sarr[i].Area();

            for (int i = 0; i < tarr.Length; i++)
                sum += tarr[i].Area();

            for (int i = 0; i < carr.Length; i++)
                sum += carr[i].Area();

            return sum;
        }



        public static double SumOfAreasV2(Geoshape[] shapes)
        {
            double sum = 0;

            for (int i = 0; i < shapes.Length; i++)
            {
                sum += shapes[i].Area();
            }

            return sum;
        }
    }
}
