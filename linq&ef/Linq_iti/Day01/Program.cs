using Linq;

namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)

        {

            #region Restriction Operators
            ////1

            //var result = ProductsData.Products.Where(p => p.UnitsInStock == 0);


            //Console.WriteLine("Products Out of Stock:");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("\n-----------------------------\n");

            ////1.b

            //var result2 = ProductsData.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);


            //Console.WriteLine("\nProducts In Stock and Price > 3.00:");
            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine("\n-----------------------------\n");

            ////1.c
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


            //var result3 = Arr.Where((name, index) => name.Length < index);


            //Console.WriteLine("\nDigits whose name is shorter than their value:");
            //foreach (var digit in result3)
            //{
            //    Console.WriteLine(digit);
            //}


            // var result3 = Arr.Filter(name => name.Length < Array.IndexOf(Arr, name));
            #endregion


            #region Ordering Operators

            //2.a
            var sortedProducts = ProductsData.Products.OrderBy(p => p.ProductName);


            Console.WriteLine("Products Sorted by Name:");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("\n-----------------------------\n");

            //2.b

            string[] Arr2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };


            var result = Arr2.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);


            Console.WriteLine("Case-insensitive sort:");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }


            //2.c

            Console.WriteLine("\n-----------------------------\n");


            var sortedStock = ProductsData.Products.OrderByDescending(p => p.UnitsInStock);


            Console.WriteLine("\nProducts Sorted by Stock (Highest to Lowest):");
            foreach (var p in sortedStock)
            {
                Console.WriteLine(p);
            }



            //2.d

            Console.WriteLine("\n-----------------------------\n");

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = Arr.OrderBy(name => name.Length).ThenBy(name => name);

            Console.WriteLine("\nDigits sorted by length, then alphabetically:");
            foreach (var d in sortedDigits)
            {
                Console.WriteLine(d);
            }


            Console.WriteLine("\n-----------------------------\n");
            //2.e




            var resultE = Arr2.OrderBy(w => w.Length)
                               .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("Sorted by length, then Case-insensitive:");
            foreach (var w in resultE)
            {
                Console.WriteLine(w);
            }

            Console.WriteLine("\n-----------------------------\n");

            // 2.f
            // string[] ArrDigits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var resultF = Arr.Where(d => d.Length > 1 && d[1] == 'i')
                                   .Reverse();


            //var resultF = (from d in Arr
            //                    where d.Length > 1 && d[1] == 'i'
            //                    select d).Reverse();

            Console.WriteLine("\nDigits with second letter 'i' (Reversed):");
            foreach (var d in resultF)
            {
                Console.WriteLine(d);
            }

            #endregion


            #region Partitioning Operators

            //// 3.a

            var first3CairoOrders = OrdersData.Orders
                .Where(o => CustomersData.Customers
                    .Any(c => c.CustomerID == o.CustomerID && c.City == "Cairo"))
                .Take(3);

            Console.WriteLine("First 3 orders from Cairo:");
            foreach (var order in first3CairoOrders)
            {
                Console.WriteLine(order);
            }


            Console.WriteLine("\n-----------------------------\n");

            // 3.b 
            var skipFirst2CairoOrders = OrdersData.Orders
                .Where(o => CustomersData.Customers
                    .Any(c => c.CustomerID == o.CustomerID && c.City == "Cairo"))
                .Skip(2);

            Console.WriteLine("\nAll orders from Cairo except the first 2:");
            foreach (var order in skipFirst2CairoOrders)
            {
                Console.WriteLine(order);
            }




            Console.WriteLine("\n-----------------------------\n");

            // 3.c
            int[] numbersC = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultC = numbersC.TakeWhile((num, index) => num >= index);

            Console.WriteLine("Numbers until a number is less than its position:");
            foreach (var n in resultC)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("\n-----------------------------\n");

            // 3.d
            int[] numbersD = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultD = numbersD.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("Elements starting from the first number divisible by 3:");
            foreach (var n in resultD)
            {
                Console.WriteLine(n);
            }


            Console.WriteLine("\n-----------------------------\n");

            // 3.e
            int[] ArrE = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var secondGreaterThan5 = ArrE.Where(n => n > 5).Skip(1).FirstOrDefault();

            Console.WriteLine($"\nThe second number greater than 5 is: {secondGreaterThan5}");


            Console.WriteLine("\n-----------------------------\n");

            // 3.f 
            void GetPage(int pageNumber, int pageSize)
            {
                var result = OrdersData.Orders
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

                Console.WriteLine($"--- Page {pageNumber} (Size: {pageSize}) ---");
                foreach (var order in result)
                {
                    Console.WriteLine(order);
                }
            }


            GetPage(2, 5);

            #endregion




            #region Projection Operators

            //// 4.a
            var productNames = ProductsData.Products.Select(p => p.ProductName);

            Console.WriteLine("Product Names only:");
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine("\n-----------------------------\n");


            // 4.b
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var wordVersions = words.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });

            Console.WriteLine("\nWords in Upper and Lower cases:");
            foreach (var v in wordVersions)
            {
                Console.WriteLine($"Upper: {v.Upper}, Lower: {v.Lower}");
            }

            Console.WriteLine("\n-----------------------------\n");
            // 4.c
            var productCustom = ProductsData.Products.Select(p => new
            {
                p.ProductName,
                Price = p.UnitPrice
            });

            Console.WriteLine("\nProducts with renamed Price property:");
            foreach (var item in productCustom)
            {
                Console.WriteLine($"{item.ProductName} costs {item.Price}");
            }

            Console.WriteLine("\n-----------------------------\n");

            // 4.d
            int[] ArrD = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var inPlaceResult = ArrD.Select((num, index) => new
            {
                Number = num,
                InPlace = (num == index)
            });

            Console.WriteLine("\nNumber: In-place?");
            foreach (var item in inPlaceResult)
            {
                Console.WriteLine($"{item.Number}: {item.InPlace}");
            }

            Console.WriteLine("\n-----------------------------\n");

            // 4.e
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { a, b };

            Console.WriteLine("Pairs where a < b:");
            foreach (var p in pairs)
            {
                Console.WriteLine($"{p.a} is less than {p.b}");
            }

            Console.WriteLine("\n-----------------------------\n");

            // 4.f
            var cheapOrders = OrdersData.Orders.Where(o => o.TotalAmount < 500.00M);

            Console.WriteLine("\nOrders with total less than 500:");
            foreach (var order in cheapOrders)
            {
                Console.WriteLine(order);
            }

            #endregion



        }
    }
}
