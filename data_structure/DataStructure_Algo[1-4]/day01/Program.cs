namespace day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== DOUBLE LINKED LIST TEST =====");

            DoubleLinkedList list = new DoubleLinkedList();

            // AddLast
            list.AddLast(new Employee(1, 25, 5000, "developer"));
            list.AddLast(new Employee(2, 30, 7000, "developer"));
            list.AddLast(new Employee(3, 28, 6000, "Sales"));

            Console.WriteLine("\nAfter AddLast (3 employees):");
            list.Display();

            // AddFirst
            list.AddFirst(new Employee(4, 35, 9000, "team learder"));
            Console.WriteLine("\nAfter AddFirst (Employee 4 added at beginning):");
            list.Display();

            // Count
            Console.WriteLine("\nCount = " + list.Count());

            // Search
            Console.WriteLine("\nSearch for ID = 2:");
            Employee found = list.Search(2);
            if (found != null)
                Console.WriteLine("Found: " + found);
            else
                Console.WriteLine("Not Found");

            // GetDataByIndex
            Console.WriteLine("\nGetDataByIndex(1):");
            Employee byIndex = list.GetDataByIndex(1);
            if (byIndex != null)
                Console.WriteLine(byIndex);
            else
                Console.WriteLine("Invalid Index");

            // RemoveFirst
            list.RemoveFirst();
            Console.WriteLine("\nAfter RemoveFirst:");
            list.Display();

            // RemoveLast
            list.RemoveLast();
            Console.WriteLine("\nAfter RemoveLast:");
            list.Display();

            // Delete by ID
            list.Delete(2);
            Console.WriteLine("\nAfter Delete ID = 2:");
            list.Display();

            Console.WriteLine("\n===== STACK TEST =====");

            MyStack stack = new MyStack();

            stack.Push(new Employee(10, 22, 4000, "QA"));
            stack.Push(new Employee(11, 27, 4500, "Dev"));
            stack.Push(new Employee(12, 29, 4800, "Support"));

            Console.WriteLine("\nStack Peek:");
            Console.WriteLine(stack.Peek());

            Console.WriteLine("\nStack Pop:");
            Console.WriteLine(stack.Pop());

            Console.WriteLine("\nStack Peek After Pop:");
            Console.WriteLine(stack.Peek());

            Console.WriteLine("\nIs Stack Empty? " + stack.IsEmpty());

            Console.WriteLine("\n===== QUEUE TEST =====");

            MyQueue queue = new MyQueue();

            queue.Enqueue(new Employee(20, 31, 8000, "HR"));
            queue.Enqueue(new Employee(21, 33, 8500, "IT"));
            queue.Enqueue(new Employee(22, 29, 8200, "Marketing"));

            Console.WriteLine("\nQueue Peek:");
            Console.WriteLine(queue.Peek());

            Console.WriteLine("\nQueue Dequeue:");
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine("\nQueue Peek After Dequeue:");
            Console.WriteLine(queue.Peek());

            Console.WriteLine("\nIs Queue Empty? " + queue.IsEmpty());

            Console.WriteLine("\n===== BUILT-IN LinkedList TEST =====");

            LinkedList<Employee> builtInList = new LinkedList<Employee>();
            

            builtInList.AddFirst(new Employee(100, 40, 15000, "Management"));
            builtInList.AddLast(new Employee(101, 38, 14000, "Admin"));

            Console.WriteLine("\nBuilt-in LinkedList contents:");
            foreach (var emp in builtInList)
            {
                Console.WriteLine(emp);
            }
           


            Console.ReadKey();
        }
    }
}
