using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class Complex
    {
        #region Static Counter
        private static int counter = 0;

        public static int GetCounter()
        {
            return counter;
        }
        #endregion

        #region Data
        int real;
        int img;
        #endregion

        #region Ctors
        public Complex()
        {
            counter++;
            real = 3;
            img = 4;
        }

        public Complex(int _real, int _img)
        {
            counter++;
            real = _real;
            img = _img;
        }

        public Complex(int _num)
        {
            counter++;
            real = img = _num;
        }
        #endregion

        #region Methods
        public string Print()
        {
            return $"{real}+{img}i";
        }

        public Complex Add(Complex right)
        {
            Complex result = new Complex();
            result.real = real + right.real;
            result.img = img + right.img;
            return result;
        }
        #endregion
    }
}