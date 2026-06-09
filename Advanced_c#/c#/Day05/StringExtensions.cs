using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{

    public static class StringExtensions
    {
       
        public static string ToTitleCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

           
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

      
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

          
            string cleaned = input.Replace(" ", "").ToLower();

         
            string reversed = new string(cleaned.ToCharArray().Reverse().ToArray());

          
            return cleaned == reversed;
        }
    }
}