public static class OrdersData
{
    public static List<Order> Orders = new List<Order>()
        {
            new Order
            {
                OrderID = 1,
                CustomerID = 5,
                OrderDate = DateTime.Parse("2025-01-03"),
                TotalAmount = 175.50M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 12, Quantity = 2, UnitPrice = 50.00M, LineTotal = 100.00M },
                    new OrderLine { ProductID = 7, Quantity = 3, UnitPrice = 25.17M, LineTotal = 75.50M },
                }
            },
            new Order
            {
                OrderID = 2,
                CustomerID = 12,
                OrderDate = DateTime.Parse("2025-01-05"),
                TotalAmount = 213.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 20, Quantity = 1, UnitPrice = 81.00M, LineTotal = 81.00M },
                    new OrderLine { ProductID = 18, Quantity = 2, UnitPrice = 66.00M, LineTotal = 132.00M },
                }
            },
            new Order
            {
                OrderID = 3,
                CustomerID = 8,
                OrderDate = DateTime.Parse("2025-01-07"),
                TotalAmount = 98.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 9, Quantity = 1, UnitPrice = 98.00M, LineTotal = 98.00M },
                }
            },
            new Order
            {
                OrderID = 4,
                CustomerID = 21,
                OrderDate = DateTime.Parse("2025-01-08"),
                TotalAmount = 115.50M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 18, Quantity = 2, UnitPrice = 57.75M, LineTotal = 115.50M },
                }
            },
            new Order
            {
                OrderID = 5,
                CustomerID = 2,
                OrderDate = DateTime.Parse("2025-01-09"),
                TotalAmount = 140.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 51, Quantity = 2, UnitPrice = 70.00M, LineTotal = 140.00M },
                }
            },
            new Order
            {
                OrderID = 6,
                CustomerID = 17,
                OrderDate = DateTime.Parse("2025-01-11"),
                TotalAmount = 190.50M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 27, Quantity = 2, UnitPrice = 43.90M, LineTotal = 87.80M },
                    new OrderLine { ProductID = 40, Quantity = 5, UnitPrice = 20.54M, LineTotal = 102.70M },
                }
            },
            new Order
            {
                OrderID = 7,
                CustomerID = 9,
                OrderDate = DateTime.Parse("2025-01-12"),
                TotalAmount = 205.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 29, Quantity = 1, UnitPrice = 123.00M, LineTotal = 123.00M },
                    new OrderLine { ProductID = 14, Quantity = 4, UnitPrice = 20.50M, LineTotal = 82.00M },
                }
            },
            new Order
            {
                OrderID = 8,
                CustomerID = 25,
                OrderDate = DateTime.Parse("2025-01-13"),
                TotalAmount = 67.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 23, Quantity = 2, UnitPrice = 9.50M, LineTotal = 19.00M },
                    new OrderLine { ProductID = 48, Quantity = 4, UnitPrice = 12.00M, LineTotal = 48.00M },
                }
            },
            new Order
            {
                OrderID = 9,
                CustomerID = 15,
                OrderDate = DateTime.Parse("2025-01-14"),
                TotalAmount = 156.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 32, Quantity = 3, UnitPrice = 32.00M, LineTotal = 96.00M },
                    new OrderLine { ProductID = 19, Quantity = 5, UnitPrice = 12.00M, LineTotal = 60.00M },
                }
            },
            new Order
            {
                OrderID = 10,
                CustomerID = 28,
                OrderDate = DateTime.Parse("2025-01-15"),
                TotalAmount = 220.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 38, Quantity = 1, UnitPrice = 120.00M, LineTotal = 120.00M },
                    new OrderLine { ProductID = 26, Quantity = 4, UnitPrice = 25.00M, LineTotal = 100.00M },
                }
            },
            new Order
            {
                OrderID = 11,
                CustomerID = 4,
                OrderDate = DateTime.Parse("2025-01-16"),
                TotalAmount = 142.50M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 6, Quantity = 3, UnitPrice = 27.50M, LineTotal = 82.50M },
                    new OrderLine { ProductID = 15, Quantity = 2, UnitPrice = 30.00M, LineTotal = 60.00M },
                }
            },
            new Order
            {
                OrderID = 12,
                CustomerID = 22,
                OrderDate = DateTime.Parse("2025-01-17"),
                TotalAmount = 305.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 31, Quantity = 5, UnitPrice = 61.00M, LineTotal = 305.00M },
                }
            },
            new Order
            {
                OrderID = 13,
                CustomerID = 7,
                OrderDate = DateTime.Parse("2025-01-18"),
                TotalAmount = 79.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 45, Quantity = 2, UnitPrice = 39.50M, LineTotal = 79.00M },
                }
            },
            new Order
            {
                OrderID = 14,
                CustomerID = 3,
                OrderDate = DateTime.Parse("2025-01-19"),
                TotalAmount = 264.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 11, Quantity = 4, UnitPrice = 66.00M, LineTotal = 264.00M },
                }
            },
            new Order
            {
                OrderID = 15,
                CustomerID = 29,
                OrderDate = DateTime.Parse("2025-01-20"),
                TotalAmount = 148.75M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 8, Quantity = 5, UnitPrice = 29.75M, LineTotal = 148.75M },
                }
            },
            new Order
            {
                OrderID = 16,
                CustomerID = 11,
                OrderDate = DateTime.Parse("2025-01-21"),
                TotalAmount = 335.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 22, Quantity = 10, UnitPrice = 33.50M, LineTotal = 335.00M },
                }
            },
            new Order
            {
                OrderID = 17,
                CustomerID = 18,
                OrderDate = DateTime.Parse("2025-01-22"),
                TotalAmount = 93.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 30, Quantity = 3, UnitPrice = 31.00M, LineTotal = 93.00M },
                }
            },
            new Order
            {
                OrderID = 18,
                CustomerID = 14,
                OrderDate = DateTime.Parse("2025-01-23"),
                TotalAmount = 120.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 2, Quantity = 6, UnitPrice = 20.00M, LineTotal = 120.00M },
                }
            },
            new Order
            {
                OrderID = 19,
                CustomerID = 1,
                OrderDate = DateTime.Parse("2025-01-24"),
                TotalAmount = 88.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 36, Quantity = 2, UnitPrice = 44.00M, LineTotal = 88.00M },
                }
            },
            new Order
            {
                OrderID = 20,
                CustomerID = 19,
                OrderDate = DateTime.Parse("2025-01-25"),
                TotalAmount = 260.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 10, Quantity = 10, UnitPrice = 26.00M, LineTotal = 260.00M },
                }
            },
            new Order
            {
                OrderID = 21,
                CustomerID = 6,
                OrderDate = DateTime.Parse("2025-01-26"),
                TotalAmount = 144.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 13, Quantity = 6, UnitPrice = 24.00M, LineTotal = 144.00M },
                }
            },
            new Order
            {
                OrderID = 22,
                CustomerID = 30,
                OrderDate = DateTime.Parse("2025-01-27"),
                TotalAmount = 95.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 44, Quantity = 5, UnitPrice = 19.00M, LineTotal = 95.00M },
                }
            },
            new Order
            {
                OrderID = 23,
                CustomerID = 8,
                OrderDate = DateTime.Parse("2025-01-28"),
                TotalAmount = 315.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 25, Quantity = 7, UnitPrice = 45.00M, LineTotal = 315.00M },
                }
            },
            new Order
            {
                OrderID = 24,
                CustomerID = 10,
                OrderDate = DateTime.Parse("2025-01-29"),
                TotalAmount = 70.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 50, Quantity = 2, UnitPrice = 35.00M, LineTotal = 70.00M },
                }
            },
            new Order
            {
                OrderID = 25,
                CustomerID = 27,
                OrderDate = DateTime.Parse("2025-01-30"),
                TotalAmount = 222.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 3, Quantity = 6, UnitPrice = 37.00M, LineTotal = 222.00M },
                }
            },
            new Order
            {
                OrderID = 26,
                CustomerID = 20,
                OrderDate = DateTime.Parse("2025-01-31"),
                TotalAmount = 162.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 42, Quantity = 3, UnitPrice = 54.00M, LineTotal = 162.00M },
                }
            },
            new Order
            {
                OrderID = 27,
                CustomerID = 9,
                OrderDate = DateTime.Parse("2025-02-01"),
                TotalAmount = 216.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 17, Quantity = 6, UnitPrice = 36.00M, LineTotal = 216.00M },
                }
            },
            new Order
            {
                OrderID = 28,
                CustomerID = 16,
                OrderDate = DateTime.Parse("2025-02-02"),
                TotalAmount = 180.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 5, Quantity = 12, UnitPrice = 15.00M, LineTotal = 180.00M },
                }
            },
            new Order
            {
                OrderID = 29,
                CustomerID = 13,
                OrderDate = DateTime.Parse("2025-02-03"),
                TotalAmount = 132.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 28, Quantity = 4, UnitPrice = 33.00M, LineTotal = 132.00M },
                }
            },
            new Order
            {
                OrderID = 30,
                CustomerID = 26,
                OrderDate = DateTime.Parse("2025-02-04"),
                TotalAmount = 119.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 46, Quantity = 7, UnitPrice = 17.00M, LineTotal = 119.00M },
                }
            },
            new Order
            {
                OrderID = 31,
                CustomerID = 12,
                OrderDate = DateTime.Parse("2025-02-05"),
                TotalAmount = 288.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 33, Quantity = 6, UnitPrice = 48.00M, LineTotal = 288.00M },
                }
            },
            new Order
            {
                OrderID = 32,
                CustomerID = 24,
                OrderDate = DateTime.Parse("2025-02-06"),
                TotalAmount = 135.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 1, Quantity = 9, UnitPrice = 15.00M, LineTotal = 135.00M },
                }
            },
            new Order
            {
                OrderID = 33,
                CustomerID = 2,
                OrderDate = DateTime.Parse("2025-02-07"),
                TotalAmount = 250.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 39, Quantity = 5, UnitPrice = 50.00M, LineTotal = 250.00M },
                }
            },
            new Order
            {
                OrderID = 34,
                CustomerID = 15,
                OrderDate = DateTime.Parse("2025-02-08"),
                TotalAmount = 176.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 21, Quantity = 8, UnitPrice = 22.00M, LineTotal = 176.00M },
                }
            },
            new Order
            {
                OrderID = 35,
                CustomerID = 5,
                OrderDate = DateTime.Parse("2025-02-09"),
                TotalAmount = 186.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 4, Quantity = 6, UnitPrice = 31.00M, LineTotal = 186.00M },
                }
            },
            new Order
            {
                OrderID = 36,
                CustomerID = 18,
                OrderDate = DateTime.Parse("2025-02-10"),
                TotalAmount = 99.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 35, Quantity = 3, UnitPrice = 33.00M, LineTotal = 99.00M },
                }
            },
            new Order
            {
                OrderID = 37,
                CustomerID = 7,
                OrderDate = DateTime.Parse("2025-02-11"),
                TotalAmount = 184.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 24, Quantity = 8, UnitPrice = 23.00M, LineTotal = 184.00M },
                }
            },
            new Order
            {
                OrderID = 38,
                CustomerID = 20,
                OrderDate = DateTime.Parse("2025-02-12"),
                TotalAmount = 276.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 41, Quantity = 4, UnitPrice = 69.00M, LineTotal = 276.00M },
                }
            },
            new Order
            {
                OrderID = 39,
                CustomerID = 23,
                OrderDate = DateTime.Parse("2025-02-13"),
                TotalAmount = 264.00M,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine { ProductID = 47, Quantity = 6, UnitPrice = 44.00M, LineTotal = 264.00M },
                }
            }

    };

}


