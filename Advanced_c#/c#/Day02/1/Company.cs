using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    //
    internal class Company<T> where T : ISalaries, IComparable<T>
    {
        public List<T> Employees { get; set; } 
        public Company()
        {
            Employees = new List<T>();
        }

        public void AddEmployee(T emp) => Employees.Add(emp);

      
        public void SortEmployees()
        {
            Employees.Sort(); 
            Console.WriteLine("emp sorted donee");
        }
    }
}