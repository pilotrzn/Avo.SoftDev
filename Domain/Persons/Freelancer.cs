using System;
using System.Collections.Generic;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public class Freelancer:Person
    {
        public Freelancer(string name,List<TimeRecord> timeRecords) : base(name,timeRecords)
        {
        }
    }
}
