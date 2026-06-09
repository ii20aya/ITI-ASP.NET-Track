using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.E_commerce
{
    public static class ProductTools
    {
       
        
        public static T FindMostExpensiveProduct<T>(List<T> products) where T : IProduct
        {
       
            if (products == null || products.Count == 0)
                return default;

         
            T expensive = products[0];

  
            foreach (var currentProduct in products)
            {
                if (currentProduct.Price > expensive.Price)
                {
                    expensive = currentProduct; 
                }
            }

            return expensive;
        }
    }
}
