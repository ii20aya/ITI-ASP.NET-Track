using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperProject.Models;

namespace DapperProject.Services.interfaces
{
    interface IProductDapperService
    {
        public List<Product> GetAll();
        public List<Product> FilterByCategory(string category);
    }
}
