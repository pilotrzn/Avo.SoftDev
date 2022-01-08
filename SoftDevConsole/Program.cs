using Avo.SoftDev.Domain;
using Avo.SoftDev.Persistance;
using System;
using System.Collections.Generic;

namespace Avo.SoftDev.SoftDevConcole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person;
            Manager manager = new Manager("user1",new List<TimeRecord>(){
                new TimeRecord(DateTime.Now.AddDays(-3),"user1",8,""),
                new TimeRecord(DateTime.Now.AddDays(-2),"user1",9,""),
                new TimeRecord(DateTime.Now.AddDays(-1),"user1",7,""),
            });
            Console.WriteLine(manager.TotalPay);
            
        }
    }
}
