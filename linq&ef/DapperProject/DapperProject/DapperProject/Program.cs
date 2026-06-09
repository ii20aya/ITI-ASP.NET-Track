using DapperProject.Services.implementation;

namespace DapperProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Server=localhost\\SQLEXPRESS;Database=northwind;Trusted_Connection=True;";
            var dapperService = new ProductDapperService(connectionString);


            Console.WriteLine("\n***************All****************\n");

            var dapperProducts = dapperService.GetAll();
            foreach (var p in dapperProducts)
                Console.WriteLine($"{p.ProductName} - {p.CategoryName}");

            Console.WriteLine("\nDONE");


            Console.WriteLine("\n***************filtered****************\n");
            var dapperProductsFiltered = dapperService.FilterByCategory("Beverages");
            foreach (var p in dapperProductsFiltered)
                Console.WriteLine($"{p.ProductName} - {p.CategoryName}");

            Console.WriteLine("\nDONE");




            Console.WriteLine("\n***************filtered****************\n");
            var dapperProductsSorted = dapperService.GetAllSorted(5);
            foreach (var p in dapperProductsSorted)
                Console.WriteLine($"{p.ProductName} - {p.CategoryName}");

            Console.WriteLine("\nDONE");

        }
    }
}
