using Day02.E_commerce;
using Day02.Static_genaric;

namespace Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------------------
          
            Console.WriteLine("=== Part 1: Company & Employees ===");

            Company<Employee> myCompany = new Company<Employee>();

            Employee emp1 = new Employee { Name = "Aya", BaseSalary = 12000 };
            Employee emp2 = new Employee { Name = "reem", BaseSalary = 8000 };
            Employee emp3 = new Employee { Name = "shiema", BaseSalary = 15000 };

            myCompany.AddEmployee(emp1);
            myCompany.AddEmployee(emp2);
            myCompany.AddEmployee(emp3);

            Console.WriteLine("Before Sorting:");
            foreach (var emp in myCompany.Employees) Console.WriteLine($"- {emp.Name}: {emp.BaseSalary}");

            myCompany.SortEmployees(); 

            Console.WriteLine("\nAfter Sorting (By Salary):");
            foreach (var emp in myCompany.Employees) Console.WriteLine($"- {emp.Name}: {emp.BaseSalary}");


            // ---------------------------------------------------------
      
            Console.WriteLine("\n=== Part 2: Bank Account & Exceptions ===");

            BankAccount myAccount = new BankAccount { AccountNumber = "1010", Balance = 2000 };

            try
            {
                Console.WriteLine($"Current Balance: {myAccount.Balance}");
                Console.WriteLine("Trying to withdraw 5000...");
                myAccount.Withdraw(5000);
            }
            catch (InsufficientBalanceException ex)
            {
              
                Console.WriteLine($"Caught Exception: {ex.Message}");
            }


            // ---------------------------------------------------------

            Console.WriteLine("\n=== Part 3: Generic Compare Objects ===");

            Person p1 = new Person { Name = "Aya", NationalId = "123" };
            Person p2 = new Person { Name = "Aya Abdulaziz", NationalId = "123" };

          
           // Helper compareResult = new Helper();
             //  Result = Person.CompareObjects(p1, p2); 
            Console.WriteLine($"Comparison Result:  {Person.CompareObjects(p1, p2)}" );


            // E-Comme
           
            Console.WriteLine("\n=== Part 4: E-Commerce System ===");

            ProductCatalog<IProduct> catalog = new ProductCatalog<IProduct>();

            catalog.AddProduct(new PhysicalProduct { Name = "book", Price = 10000 });
            catalog.AddProduct(new DigitalProduct { Name = "phone", Price = 200 });
            catalog.AddProduct(new PhysicalProduct { Name = "pen", Price = 1500 });

            catalog.DisplayCatalog();

          
            var expensive = ProductTools.FindMostExpensiveProduct(new List<IProduct> {
        new PhysicalProduct { Name = "Laptop", Price = 30000 },
        new DigitalProduct { Name = "Software", Price = 5000 }
    });
            Console.WriteLine($"\nMost Expensive Item: {expensive.Name} with price {expensive.Price}");

            try
            {
                Console.WriteLine("\nTry removing 'lap'??");
                catalog.RemoveProduct("lap"); 
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine($"Caught Exception: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
