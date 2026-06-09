using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.E_commerce
{
    
    public class PhysicalProduct : IProduct , IComparable<IProduct>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    
        public string GetProductDetails()
        {
            return $"[Physical Product] Name: {Name}, Price: {Price:C} (Shipping fees may apply)";
        }

      
        public int CompareTo(IProduct other)
        {
            if (other == null) return 1;
            
            return this.Price.CompareTo(other.Price);
        }
    }

 
  
    }
