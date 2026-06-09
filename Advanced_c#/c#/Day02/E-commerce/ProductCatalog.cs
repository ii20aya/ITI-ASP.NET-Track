using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.E_commerce
{
 
    public class ProductCatalog<T> where T : IProduct
    {
      
        private List<T> _products = new List<T>();

     
        public void AddProduct(T product)
        {
            _products.Add(product);
            Console.WriteLine($"Added: {product.Name}");
        }

    
        public void RemoveProduct(string productName)
        {
            var item = _products.Find(p => p.Name == productName);

            if (item == null)
            {
              
                throw new ProductNotFoundException($"Oops! {productName} was not found in our catalog.");
            }

            _products.Remove(item);
            Console.WriteLine($"Removed: {productName}");
        }

 
        public void DisplayCatalog()
        {
            Console.WriteLine("\n--- Product Catalog ---");
            foreach (var p in _products)
            {
      
                Console.WriteLine(p.GetProductDetails());
            }
        }

      
        public void SortByPrice()
        {
            _products.Sort(); 
            Console.WriteLine("\nCatalog sorted by price!");
        }
    }
}