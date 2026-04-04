using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace day05
{
    class DynamicStack
    {
        int[] arr;
        int tos;
        int size;

        public DynamicStack(int _size)
        {
            size = _size;
            arr = new int[size];
            tos = 0;
        }

        public void Push(int value)
        {
            if (tos == size)
            {
                Console.WriteLine("Stack Full");
                return;
            }

            arr[tos] = value;
            tos++;
        }

        public int Pop()
        {
            if (tos == 0)
            {
                Console.WriteLine("Stack Empty");
                return -1;
            }

            tos--;
            return arr[tos];
        }
    }
}