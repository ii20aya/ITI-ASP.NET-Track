namespace day03
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
        

            // Create 
            BSTree bst = new BSTree();

            bst.Insert(new Employee("Ahmed", "IT", 5000));
            bst.Insert(new Employee("Sara", "HR", 3000));

            bst.InsertIterative(new Employee("Omar", "Finance", 7000));
            bst.InsertIterative(new Employee("Mona", "IT", 4000));



            Console.WriteLine("\n");

            //  Traversal 
            Console.WriteLine("=== BST In-Order Traversal (Sorted by Salary) ===\n");
            bst.InOrderTraversal();

            Console.WriteLine("\n");

            //  Search
            Console.WriteLine("=== Search for Salary 4000 ===");
            BSTNode searchNode = bst.Search(4000);
            if (searchNode != null)
                Console.WriteLine($"Found: {searchNode.data}");
            else
                Console.WriteLine("Employee with Salary 4000 not found");

            Console.WriteLine("\n");

            // Max/Min 
            Employee maxEmp = bst.GetMaxSalary();
            Employee minEmp = bst.GetMinSalary();

            Console.WriteLine("=== Max Salary Employee ===");
            Console.WriteLine(maxEmp);

            Console.WriteLine("\n=== Min Salary Employee ===");
            Console.WriteLine(minEmp);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

