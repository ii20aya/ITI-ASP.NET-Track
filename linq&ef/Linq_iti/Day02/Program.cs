namespace Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Set Operators



            //1.a

            var categoryNames = ProductsData.Products.Select(p => p.Category).Distinct();


            Console.WriteLine("Unique Categories name:");
            foreach (var cat in categoryNames)
            {
                Console.WriteLine(cat);
            }

            Console.WriteLine("========================================================");



            //1.b

            var productFirstLetters = ProductsData.Products.Select(p => p.ProductName[0]).Distinct();


            var customerFirstLetters = CustomersData.Customers.Select(c => c.CustomerName[0]).Distinct();


            var resultLetters = productFirstLetters.Except(customerFirstLetters);

            Console.WriteLine("\nLetters in Products but NOT in Customers:");
            foreach (var letter in resultLetters)
            {
                Console.WriteLine(letter);
            }

            Console.WriteLine("========================================================");


            #endregion



            #region Aggregate & Grouping operators

            /// 2.a

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };


            int oddCount = Arr.Count(n => n % 2 != 0);

            Console.WriteLine($"Number of odd numbers: {oddCount}");

            Console.WriteLine("========================================================");


            // 2.b

            var customerOrdersInfo = CustomersData.Customers.Select(c => new
            {
                Name = c.CustomerName,

                OrderCount = OrdersData.Orders.Count(o => o.CustomerID == c.CustomerID)
            });

            Console.WriteLine("\nCustomers and their order counts:");
            foreach (var info in customerOrdersInfo)
            {
                Console.WriteLine($"{info.Name}: {info.OrderCount} orders");
            }



            Console.WriteLine("========================================================");


            // 2.c

            var categoryStock = ProductsData.Products
    .GroupBy(p => p.Category)
    .Select(group => new
    {
        Category = group.Key,
        TotalInStock = group.Sum(p => p.UnitsInStock)
    });

            Console.WriteLine("\nTotal stock per category:");
            foreach (var item in categoryStock)
            {
                Console.WriteLine($"{item.Category}: {item.TotalInStock}");
            }




            Console.WriteLine("========================================================");

            //2.d

            var cheapestPerCategory = from p in ProductsData.Products
                                      group p by p.Category into g
                                      let minPrice = g.Min(prod => prod.UnitPrice)
                                      select new
                                      {
                                          Category = g.Key,
                                          CheapestProducts = g.Where(prod => prod.UnitPrice == minPrice)
                                      };

            Console.WriteLine("\nCheapest products in each category:");
            foreach (var group in cheapestPerCategory)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.CheapestProducts)
                {
                    Console.WriteLine($" - {product.ProductName} ({product.UnitPrice})");
                }
            }




            Console.WriteLine("========================================================");

            //2.e


            var maxPricePerCategory = ProductsData.Products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    MaxPrice = g.Max(p => p.UnitPrice)
                });

            Console.WriteLine("\nMost expensive price per category:");
            foreach (var item in maxPricePerCategory)
            {
                Console.WriteLine($"{item.Category}: {item.MaxPrice}");
            }



            Console.WriteLine("========================================================");


            //2.f   


            var mostExpensiveProducts = from p in ProductsData.Products
                                        group p by p.Category into g
                                        let maxPrice = g.Max(prod => prod.UnitPrice)
                                        select new
                                        {
                                            Category = g.Key,
                                            Products = g.Where(prod => prod.UnitPrice == maxPrice)
                                        };

            Console.WriteLine("\nProducts with the most expensive price in each category:");
            foreach (var group in mostExpensiveProducts)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var p in group.Products)
                {
                    Console.WriteLine($" - {p.ProductName} (Price: {p.UnitPrice})");
                }
            }



            Console.WriteLine("========================================================");

            //2.g


            var averagePricePerCategory = ProductsData.Products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    AveragePrice = g.Average(p => p.UnitPrice)
                });

            Console.WriteLine("\nAverage price per category:");
            foreach (var item in averagePricePerCategory)
            {
                Console.WriteLine($"{item.Category}: {item.AveragePrice:C}");
            }

            #endregion





            #region Quantifiers


            //3.a

            var outOfStockCategories = ProductsData.Products
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => new { CategoryName = g.Key, Products = g });

            Console.WriteLine("Categories with at least one out-of-stock product:");
            foreach (var item in outOfStockCategories)
            {
                Console.WriteLine($"--- {item.CategoryName} ---");
                foreach (var p in item.Products)
                {
                    Console.WriteLine($"Product: {p.ProductName}, Stock: {p.UnitsInStock}");
                }
            }



            Console.WriteLine("========================================================");



            var allInStockCategories = ProductsData.Products
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => new { CategoryName = g.Key, Products = g });

            Console.WriteLine("\nCategories where ALL products are in stock:");
            foreach (var item in allInStockCategories)
            {
                Console.WriteLine($"--- {item.CategoryName} ---");
                foreach (var p in item.Products)
                {
                    Console.WriteLine($"Product: {p.ProductName}, Stock: {p.UnitsInStock}");
                }
            }
            #endregion



            #region Join


            var ordersWithCustomers = OrdersData.Orders.Join(
                CustomersData.Customers,
                order => order.CustomerID,
                customer => customer.CustomerID,
                (order, customer) => new
                {
                    order.OrderID,
                    customer.CustomerName,
                    order.TotalAmount
                });

            Console.WriteLine("\nOrders with Customer Details:");
            foreach (var item in ordersWithCustomers)
            {
                Console.WriteLine($"Order #{item.OrderID} by {item.CustomerName} - Total: {item.TotalAmount}");
            }

            Console.WriteLine("========================================================");


            #endregion

        }
    }
}
