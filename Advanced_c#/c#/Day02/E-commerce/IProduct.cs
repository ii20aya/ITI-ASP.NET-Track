using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.E_commerce
{
    public interface IProduct : IComparable<IProduct>
    {
        string Name { get; set; }
        decimal Price { get; set; }
        string GetProductDetails();
    }
}
