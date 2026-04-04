using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day03
{
     class Employee
    {

        private int id;
        private string name;
        private int age;
        private float salary;



        public void SetId(int i)
        {
            id = i;
        }

        public int GetId()
        {
            return id;
        }

        public void SetName(string n)
        {
            name = n;
        }

        public string GetName()
        {
            return name;
        }

        public void SetAge(int a)
        {
            age = a;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetSalary(float s)
        {
            salary = s;
        }

        public float GetSalary()
        {
            return salary;
        }



        public string Print()
        {
            return $"Id: {id} | Name: {name} | Age: {age} | Salary: {salary}";
        }
    }
}
