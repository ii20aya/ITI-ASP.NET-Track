using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.Static_genaric
{

    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public string NationalId { get; set; }


        public bool Equals(Person other)
        {
            if (other == null) return false;
            return NationalId == other.NationalId;
        }
    

   
        public static string CompareObjects<T>(T obj1, T obj2) where T : IEquatable<T>
        {
            if (obj1.Equals(obj2))
                return "=";

            return "!=";
        }
    }
}
