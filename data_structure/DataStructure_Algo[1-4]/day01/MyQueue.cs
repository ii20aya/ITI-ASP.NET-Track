using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    class MyQueue : DoubleLinkedList
    {
        // Enqueue = AddLast
        public void Enqueue(Employee data)
        {
            AddLast(data);
        }

        // Dequeue = RemoveFirst
        public Employee Dequeue()
        {
            if (head == null)
                return null;

            Employee data = head.Data;
            RemoveFirst();
            return data;
        }

        // Peek = أول عنصر
        public Employee Peek()
        {
            if (head == null)
                return null;

            return head.Data;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }
    }
}
