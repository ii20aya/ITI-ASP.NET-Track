using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.E_commerce
{
    public class DigitalProduct : IProduct , IComparable<IProduct>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string GetProductDetails()
        {
            return $"[Digital Product] Name: {Name}, Price: {Price:C} (Instant Download)";
        }

        public int CompareTo(IProduct other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
    }
}