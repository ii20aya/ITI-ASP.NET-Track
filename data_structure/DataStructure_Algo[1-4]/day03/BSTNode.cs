using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day03
{
    class BSTNode
    {
        public Employee data; 
        public BSTNode left;  
        public BSTNode right; 

   
        public BSTNode(Employee data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
