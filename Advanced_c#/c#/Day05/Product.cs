using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


    public class StockEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
    }
}
