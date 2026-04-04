using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day05
{
    class Queue
    {
        int[] arr;
        int front;
        int rear;
        int size;
        int count;

        public Queue(int _size)
        {
            size = _size;
            arr = new int[size];
            front = 0;
            rear = 0;
            count = 0;
        }

        public void Enqueue(int value)
        {
            if (count == size)
            {
                Console.WriteLine("Queue Full");
                return;
            }

            arr[rear] = value;

            rear++;
            if (rear == size)
                rear = 0;

            count++;
        }

        public int Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("Queue Empty");
                return -1;
            }

            int result = arr[front];

            front++;
            if (front == size)
                front = 0;

            count--;

            return result;
        }
    }
}