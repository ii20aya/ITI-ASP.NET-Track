
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace day05
{
    class Complex
    {
        int real;
        int img;

        public Complex(int r, int i)
        {
            real = r;
            img = i;
        }

        public void Print()
        {
            Console.WriteLine($"{real}+{img}i");
        }

        // c1 + c2
        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex(
                left.real + right.real,
                left.img + right.img
            );
        }

        // c1 + 10
        public static Complex operator +(Complex left, int num)
        {
            return new Complex(left.real + num, left.img);
        }

        // 10 + c1
        public static Complex operator +(int num, Complex right)
        {
            return new Complex(right.real + num, right.img);
        }

        // c1++
        public static Complex operator ++(Complex c)
        {
            return new Complex(c.real + 1, c.img + 1);
        }

        public static bool operator >(Complex a, Complex b)
        {
            return a.real > b.real && a.img > b.img;
        }

        public static bool operator <(Complex a, Complex b)
        {
            return a.real < b.real && a.img < b.img;
        }

        public static explicit operator int(Complex c)
        {
            return c.real;
        }
    }
}
