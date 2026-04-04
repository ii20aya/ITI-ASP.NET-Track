using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class BSTNode
    {
        public Employee Data; 
        public BSTNode Left;  
        public BSTNode Right; 

   
        public BSTNode(Employee data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }
    }
}
