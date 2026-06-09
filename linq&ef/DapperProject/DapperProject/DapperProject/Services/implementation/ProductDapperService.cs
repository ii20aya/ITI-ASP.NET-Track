using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperProject.Models;
using DapperProject.Services.interfaces;

namespace DapperProject.Services.implementation
{
    internal class ProductDapperService: IProductDapperService
    {
        private string _connectionString;

        public ProductDapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetAll()
        {
            using var conn = new SqlConnection(_connectionString);

            string sql = @"
            SELECT p.ProductName, c.CategoryName, s.CompanyName AS SupplierName
            FROM Products p
            JOIN Categories c ON p.CategoryID = c.CategoryID
            JOIN Suppliers s ON p.SupplierID = s.SupplierID";

            return conn.Query<Product>(sql).ToList();
        }

        public List<Product> FilterByCategory(string category)
        {
            using var conn = new SqlConnection(_connectionString);

            string sql = @"
            SELECT p.ProductName, c.CategoryName, s.CompanyName AS SupplierName
            FROM Products p
            JOIN Categories c ON p.CategoryID = c.CategoryID
            JOIN Suppliers s ON p.SupplierID = s.SupplierID
            WHERE c.CategoryName = @category";

            return conn.Query<Product>(sql, new { category }).ToList();
        }

        public List<Product> GetAllSorted(int? top = null)
        {
            using var conn = new SqlConnection(_connectionString);

            string sql = $@"
            SELECT {(top.HasValue ? $"TOP ({top.Value})" : "")}
                p.ProductName,
                c.CategoryName,
                s.CompanyName AS SupplierName
            FROM Products p
            JOIN Categories c ON p.CategoryID = c.CategoryID
            JOIN Suppliers s ON p.SupplierID = s.SupplierID
            ORDER BY p.ProductName ASC";

            return conn.Query<Product>(sql).ToList();
        }
    }
}
