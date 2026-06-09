using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal interface ISalaries
    {
        decimal CalcSalary();
        decimal CalcBonus(int dayCount);
        decimal CalcAbsentValue(int dayCount);
    }
}
