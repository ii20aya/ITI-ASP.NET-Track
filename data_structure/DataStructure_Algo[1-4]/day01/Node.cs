using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    class Node
    {
        public Employee Data;
        public Node Next;
        public Node Prev;

        public Node(Employee data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
