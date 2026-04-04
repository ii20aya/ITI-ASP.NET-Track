using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    public class Employee
    {
       
        private static int counter = 1;

       
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

     
        public Employee(string name, string department, double salary)
        {
            this.ID = counter++; 
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Employee))
                return false;

            Employee other = (Employee)obj;

            return this.ID == other.ID &&
                   this.Name == other.Name &&
                   this.Department == other.Department;
        }

        

      
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Dept: {Department}, Salary: {Salary}";
        }
    }
}
