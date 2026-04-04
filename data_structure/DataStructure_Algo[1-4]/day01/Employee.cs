using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    class Employee
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string DepartmentName { get; set; }

        public Employee(int id, int age, double salary, string dept)
        {
            ID = id;
            Age = age;
            Salary = salary;
            DepartmentName = dept;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Age: {Age}, Salary: {Salary}, Department: {DepartmentName}";
        }
    }
}
