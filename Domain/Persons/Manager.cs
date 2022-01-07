using System;
using System.Collections.Generic;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public class Manager:Stuff
    {
        public Manager(string name, List<TimeRecord> timeRecords) : base(name, 200000,timeRecords)
        {

        }
    }
}
