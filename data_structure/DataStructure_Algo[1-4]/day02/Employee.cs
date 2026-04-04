using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace day02
{
    class Employee : IComparable<Employee>
{
 
    private static int counter = 1;

   
    public int ID { get; private set; }
    public string Name { get; set; }
    public DateTime HireDate { get; set; }
    public double Salary { get; set; }


    public Employee(string name, DateTime hireDate, double salary)
    {
        ID = counter++;   
        Name = name;
        HireDate = hireDate;
        Salary = salary;
    }

   
    public int CompareTo(Employee other)
    {
        if (other == null)
            return 1;

        return this.HireDate.CompareTo(other.HireDate);
    }


    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, HireDate: {HireDate.ToShortDateString()}, Salary: {Salary}";
    }
}
}
