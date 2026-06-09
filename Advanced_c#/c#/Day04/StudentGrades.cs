using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    internal class StudentGrades 
    {
      
        private IDictionary<string, List<int>> _studentData;

        public StudentGrades()
        {
            _studentData = new Dictionary<string, List<int>>();
        }



   
        public void AddStudent(string name)
        {
            if (string.IsNullOrEmpty(name)) return;

            if (!_studentData.ContainsKey(name))
            {
                _studentData.Add(name, new List<int>());
                Console.WriteLine($"[System]: Student '{name}' added.");
            }
        }

   
        public void AddGrade(string name, int grade)
        {
            if (_studentData.ContainsKey(name))
            {
                _studentData[name].Add(grade);
                Console.WriteLine($"[System]: Grade {grade} added to {name}.");
            }
            else
            {
                Console.WriteLine($"[Error]: Student '{name}' not found!");
            }
        }

   
        public double GetAverage(string name)
        {
            if (_studentData.ContainsKey(name) && _studentData[name].Count > 0)
            {
                return _studentData[name].Average();
            }
            return 0;
        }

    
        public void DisplayAll()
        {
        
            ICollection<string> keys = _studentData.Keys;

            Console.WriteLine("\n--- Student Report ---");
            foreach (var name in keys)
            {
                var grades = _studentData[name];
                string gradesStr = grades.Count > 0 ? string.Join(", ", grades) : "No grades yet";
                Console.WriteLine($"- {name}: [{gradesStr}] (Avg: {GetAverage(name):F2})");
            }
            Console.WriteLine("----------------------\n");
        }
    }
}