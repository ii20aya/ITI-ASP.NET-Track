using NorthwindApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.Services.interfaces
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetById(int id);
        public List<Product> GetByCategory(int categoryId);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(int id);

       
        public List<Product> Search(string name);
        public List<Product> GetPaged(int pageNumber, int pageSize);


    }
}
