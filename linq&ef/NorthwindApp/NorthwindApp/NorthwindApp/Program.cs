using Microsoft.EntityFrameworkCore;
using NorthwindApp.Models;
using NorthwindApp.Services.Implementations;

namespace NorthwindApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=northwind;Trusted_Connection=True;TrustServerCertificate=True";

            var options = new DbContextOptionsBuilder<northwindContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new northwindContext(options);
            var efService = new ProductService(context);

            Console.WriteLine("\n---Get All Products ---");
            var efProducts = efService.GetAllProducts();
            foreach (var p in efProducts.Take(5))
                Console.WriteLine(p.ProductName);
        }
    }
}
