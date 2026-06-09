using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private Dictionary<Product, int> inventory = new Dictionary<Product, int>();

       
        public event EventHandler<StockEventArgs> LowStockEvent;

        public void BuyFromSupplier(Product p, int quantity)
        {
            if (inventory.ContainsKey(p))
                inventory[p] += quantity;
            else
                inventory.Add(p, quantity);
        }

        public void SellToCustomer(Product p, int quantity)
        {
            if (inventory.ContainsKey(p))
            {
                inventory[p] -= quantity;

            
                if (inventory[p] < 5)
                {
                    OnLowStock(p.Name);
                }
            }
        }

        protected virtual void OnLowStock(string productName)
        {
           
            LowStockEvent?.Invoke(this, new StockEventArgs
            {
                ProductName = productName,
                CompanyName = this.Name
            });
        }
    }
}
