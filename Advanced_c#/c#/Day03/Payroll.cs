using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    /// <summary>
    /// Handles employee salary calculations.
    /// </summary>
    internal class Payroll
    {
        /// <summary>
        /// Calculates the total salary based on work hours and hourly rate.
        /// </summary>
        /// <param name="employeeName">Name of the employee.</param>
        /// <param name="workHours">Number of hours worked.</param>
        /// <param name="hourlyRate">Rate per hour (Default is 50).</param>
        /// <param name="totalSalary">Output parameter to store the result.</param>
        public void CalculateSalary(string employeeName, int workHours,  out decimal totalSalary,decimal hourlyRate = 50)
        {
         
            totalSalary = workHours * hourlyRate;

            Console.WriteLine($"Employee: {employeeName}, Hours: {workHours}, Rate: {hourlyRate}");
        }
    }
}