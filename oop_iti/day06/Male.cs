using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    class Male : Human
    {
        public Male(string _name)
        {
            name = _name;
        }

        public override void SayName()
        {
            Console.WriteLine($"My name is {name}");
        }
    }
}
