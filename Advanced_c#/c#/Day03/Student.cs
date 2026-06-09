using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    /// <summary>
    /// Represents a student with a name and GPA.
    /// </summary>
    internal class Student
    {
        public string Name { get; set; }
        public float GPA { get; set; }

        public override string ToString() => $"Name: {Name}, GPA: {GPA}";
    }

    /// <summary>
    /// Represents a grade (class) containing multiple students.
    /// Supports indexing by name or position.
    /// </summary>
    internal class Grade : IEnumerable<Student>
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student s) => students.Add(s);

        // 1. Indexer by Student Name
        public float this[string name]
        {
            get
            {
                var student = students.Find(s => s.Name == name);
                return student?.GPA ?? 0;
            }
            set
            {
                var student = students.Find(s => s.Name == name);
                if (student != null) student.GPA = value;
            }
        }

        // 2. Indexer by Integer Index
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < students.Count)
                    return students[index].ToString();
                return "Index Out of Range";
            }
        }

      
        public IEnumerator<Student> GetEnumerator() => students.GetEnumerator();
       IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}