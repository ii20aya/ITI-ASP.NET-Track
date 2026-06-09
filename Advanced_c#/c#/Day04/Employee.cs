using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public delegate bool PromotionCriteria(Employee emp);
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public double Salary { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int Experience { get; set; }


        public static List<Employee> Prompt(List<Employee> employees, PromotionCriteria criteria)
        {
            List<Employee> promotedList = new List<Employee>();

            foreach (var emp in employees)
            {
               
                if (criteria(emp))
                {
                    promotedList.Add(emp);
                }
            }
            return promotedList;
        
    }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Experience: {Experience}, Salary: {Salary}";
        }

    }
}
