using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }

       
        public void HandleLowStock(object sender, StockEventArgs e)
        {
            Console.WriteLine($"[إشعار للمورد {Name}]: الشركة {e.CompanyName} محتاجة بضاعة من {e.ProductName} فوراً!");
        }
    }
}
