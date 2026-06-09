using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Employee : ISalaries, IComparable<Employee>
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public decimal CalcSalary() => BaseSalary + CalcBonus(2) - CalcAbsentValue(1);
        public decimal CalcBonus(int dayCount) => dayCount * 240;
        public decimal CalcAbsentValue(int dayCount) => dayCount * 200;

       
        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            return this.BaseSalary.CompareTo(other.BaseSalary);
        }
    }
}
