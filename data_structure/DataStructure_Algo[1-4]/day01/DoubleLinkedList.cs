using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    class DoubleLinkedList
    {
        protected Node head;
        protected Node tail;
        protected int count;

        public DoubleLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // Add First
        public void AddFirst(Employee data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }

            count++;
        }

        // Add Last
        public void AddLast(Employee data)
        {
            Node newNode = new Node(data);

            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }

            count++;
        }

        // Remove First
        public void RemoveFirst()
        {
            if (head == null)
                return;

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }

            count--;
        }

        // Remove Last
        public void RemoveLast()
        {
            if (tail == null)
                return;

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }

            count--;
        }

        // Search by ID
        public Employee Search(int id)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.ID == id)
                    return current.Data;

                current = current.Next;
            }

            return null;
        }

        // Delete by ID
        public void Delete(int id)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.ID == id)
                {
                    if (current == head)
                        RemoveFirst();
                    else if (current == tail)
                        RemoveLast();
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                        count--;
                    }

                    return;
                }

                current = current.Next;
            }
        }

        // Get Data By Index
        public Employee GetDataByIndex(int index)
        {
            if (index < 0 || index >= count)
                return null;

            Node current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        // Count
        public int Count()
        {
            return count;
        }

        // Display
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
