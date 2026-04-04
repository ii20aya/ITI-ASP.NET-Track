using Day4;

namespace day04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BST Test ===");

            BSTree bst = new BSTree();

            Employee e1 = new Employee("Ahmed", "marketing", 5000);
            Employee e2 = new Employee("reem", "ceo", 3000);
            Employee e3 = new Employee("aya", "dev", 7000);
            Employee e4 = new Employee("Mona", "IT", 4000);

            bst.Insert(e1);
            bst.Insert(e2);
            bst.Insert(e3);
            bst.Insert(e4);

            Console.WriteLine("\nBefore Delete:");
            bst.InOrderTraversal();

            bst.Delete(5000);

            Console.WriteLine("\nAfter Delete:");
            bst.InOrderTraversal();

            Console.WriteLine("\n=== Heap Test ===");

            MaxHeap<int> heap = new MaxHeap<int>();

            heap.Enqueue(5);
            heap.Enqueue(10);
            heap.Enqueue(3);
            heap.Enqueue(8);

            while (!heap.IsEmpty())
                Console.WriteLine(heap.Dequeue());
        }
    }
}

