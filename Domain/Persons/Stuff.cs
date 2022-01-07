using System;
using System.Collections.Generic;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public class Stuff:Person
    {
        public decimal MonthSalary { get; }
        public Stuff(string name,decimal monthSalary, List<TimeRecord> timeRecords) : base(name, timeRecords)
        {
            MonthSalary = monthSalary;
        }
    }
}
