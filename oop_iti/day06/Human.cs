using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    class Human
    {
        protected string name;

        public virtual void SayName()
        {
            Console.WriteLine("NO Name");
        }
    }
}
