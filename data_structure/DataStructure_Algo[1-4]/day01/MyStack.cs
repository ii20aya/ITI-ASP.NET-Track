using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    class MyStack : DoubleLinkedList
    {
        // Push = AddLast
        public void Push(Employee data)
        {
            AddLast(data);
        }

        // Pop = RemoveLast
        public Employee Pop()
        {
            if (tail == null)
                return null;

            Employee data = tail.Data;
            RemoveLast();
            return data;
        }

        // Peek = آخر عنصر
        public Employee Peek()
        {
            if (tail == null)
                return null;

            return tail.Data;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }
    }
}
