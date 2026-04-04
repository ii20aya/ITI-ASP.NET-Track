using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace day02
{
    class SortedDoubleLinkedList
    {
         Node head;
         Node tail;
       

        public SortedDoubleLinkedList()
        {
            head = null;
            tail = null;
           
        }

        public void Insert(Employee data)
        {
            Node newNode = new Node(data);

           
            if (head == null)
            {
                head = tail = newNode;
                return;
            }

           
            if (data.CompareTo(head.Data) < 0)
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                return;
            }

            Node current = head;

          

            //
            while (current.Next != null && current.Next.Data.CompareTo(data) < 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                tail = newNode;

            current.Next = newNode;
        }

        public void Display()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
