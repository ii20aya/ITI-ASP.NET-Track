using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private List<T> heap = new List<T>();

        public int Count()
        {
            return heap.Count;
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap is empty");

            return heap[0];
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap is empty");

            T root = heap[0];

            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            HeapifyDown(0);

            return root;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;

                if (heap[index].CompareTo(heap[parent]) <= 0)
                    break;

                (heap[index], heap[parent]) = (heap[parent], heap[index]);

                index = parent;
            }
        }

        private void HeapifyDown(int index)
        {
            int last = heap.Count - 1;

            while (true)
            {
                int left = index * 2 + 1;
                int right = index * 2 + 2;
                int largest = index;

                if (left <= last && heap[left].CompareTo(heap[largest]) > 0)
                    largest = left;

                if (right <= last && heap[right].CompareTo(heap[largest]) > 0)
                    largest = right;

                if (largest == index)
                    break;

                (heap[index], heap[largest]) = (heap[largest], heap[index]);

                index = largest;
            }
        }
    }
}
