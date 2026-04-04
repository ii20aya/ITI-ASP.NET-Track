using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day03
{
     class Complex
    {
        private int real;
        private int img;


        public void SetReal(int r)
        {
            real = r;
        }

        public int GetReal()
        {
            return real;
        }

        public void SetImg(int i)
        {
            img = i;
        }

        public int GetImg()
        {
            return img;
        }




        public string Print()
        {
            if (real == 0 && img == 0)
                return "0";

            if (real == 0)
            {
                if (img == 1)
                    return "i";
                if (img == -1)
                    return "-i";
                return $"{img}i";
            }

            if (img == 0)
                return $"{real}";

            if (img > 0)
            {
                if (img == 1)
                    return $"{real}+i";
                return $"{real}+{img}i";
            }
            else
            {
                if (img == -1)
                    return $"{real}-i";
                return $"{real}{img}i";
            }
        }
    }
}
