using System;
using System.Collections.Generic;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public  class Employee:Stuff
    {
        public Employee(string name, List<TimeRecord> timeRecords) : base(name, 120000,timeRecords)
        {
        }
    }
}
