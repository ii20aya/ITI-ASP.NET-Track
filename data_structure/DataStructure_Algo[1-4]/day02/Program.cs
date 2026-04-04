namespace day02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Create Employees Array

            Employee[] employees =
            {
                new Employee("Ahmed", new DateTime(2023,5,1),5000),
                new Employee("Sara", new DateTime(2021,3,1),6000),
                new Employee("Omar", new DateTime(2022,7,1),4500),
                new Employee("Mona", new DateTime(2020,1,1),7000),
                new Employee("Ali", new DateTime(2024,2,10),5500)
            };

            #endregion


            #region Print Original Array

            Console.WriteLine("=== Original Employees ===");

            foreach (var e in employees)
                Console.WriteLine(e);

            Console.WriteLine();

            #endregion


            #region Selection Sort Test

            Console.WriteLine("=== Selection Sort ===");

            SortingAlgorithms.SelectionSort(employees);

            foreach (var e in employees)
                Console.WriteLine(e);

            Console.WriteLine();

            #endregion


            #region Bubble Sort Test

            Console.WriteLine("=== Bubble Sort ===");

            SortingAlgorithms.BubbleSort(employees);

            foreach (var e in employees)
                Console.WriteLine(e);

            Console.WriteLine();

            #endregion


            #region Merge Sort Test

            Console.WriteLine("=== Merge Sort ===");

            SortingAlgorithms.MergeSort(employees);

            foreach (var e in employees)
                Console.WriteLine(e);

            Console.WriteLine();

            #endregion


            #region Binary Search Iterative

            Console.WriteLine("=== Binary Search Iterative ===");

            DateTime target = new DateTime(2022, 7, 1);

            int index = BinarySearch.BinarySearchIterative(employees, target);

            if (index != -1)
                Console.WriteLine("Employee Found: " + employees[index]);
            else
                Console.WriteLine("Employee Not Found");

            Console.WriteLine();

            #endregion


            #region Binary Search Recursive

            Console.WriteLine("=== Binary Search Recursive ===");

            int index2 = BinarySearch.BinarySearchRecursive
            (
                employees,
                new DateTime(2023, 5, 1),
                0,
                employees.Length - 1
            );

            if (index2 != -1)
                Console.WriteLine("Employee Found: " + employees[index2]);
            else
                Console.WriteLine("Employee Not Found");

            Console.WriteLine();

            #endregion


            #region Sorted LinkedList Test

            Console.WriteLine("=== Sorted Linked List ===");

            SortedDoubleLinkedList list = new SortedDoubleLinkedList();

            list.Insert(new Employee("Ahmed", new DateTime(2023, 5, 1), 5000));
            list.Insert(new Employee("Sara", new DateTime(2021, 3, 1), 6000));
            list.Insert(new Employee("Omar", new DateTime(2022, 7, 1), 4500));
            list.Insert(new Employee("Mona", new DateTime(2020, 1, 1), 7000));
            list.Insert(new Employee("Ali", new DateTime(2024, 2, 10), 5500));

            list.Display();

            Console.WriteLine();

            #endregion


            

        }
    }
}
