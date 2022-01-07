using System;
using System.Collections.Generic;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public List<TimeRecord> TimeRecords { get; }
        public Person(string name, List<TimeRecord> timeRecords)
        {
            Name = name;
            TimeRecords = timeRecords;
        }
    }
}
