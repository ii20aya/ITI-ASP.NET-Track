using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindApp.Models;
using NorthwindApp.Services.interfaces;

namespace NorthwindApp.Services.Implementations
{
    public class ProductService: IProductService
    {
        private readonly northwindContext _context;

        public ProductService(northwindContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> Search(string name)
        {
            return _context.Products
                .Where(p => p.ProductName.Contains(name))
                .ToList();
        }

        public List<Product> GetPaged(int pageNumber, int pageSize)
        {
            return _context.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
