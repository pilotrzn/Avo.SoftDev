using Avo.SoftDev.Domain;
using Avo.SoftDev.Domain.Persons;
using System;
using System.Collections.Generic;

namespace Avo.SoftDev.Persistance
{
    public static class FakeData
    {
        public static List<TimeRecord> employees = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.AddDays(-3),"Иванов",8,"ттт"),
                new TimeRecord(DateTime.Now.AddDays(-3),"Петров",8,"ттт"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Иванов",10,"ттт"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Петров",8,"ттт")
            };

        public static List<User> users = new List<User>()
            {
                new User("Иванов", UserRole.Employee),
                new User("Петров",UserRole.Employee),
                new User("Смит",UserRole.Freelancer),
                new User("Бонд",UserRole.Freelancer),
                new User("Аво",UserRole.Manager),
            };

        public static List<TimeRecord> freelancers = new List<TimeRecord>()
        {
            new TimeRecord(DateTime.Now.AddDays(-3),"Смит",8,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-3),"Бонд",8,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Смит",10,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Бонд",8,"ттт")
        };

        public static List<TimeRecord> managers = new List<TimeRecord>()
        {
            new TimeRecord(DateTime.Now.AddDays(-3),"Аво",8,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Аво",8,"ттт"),
        };
    }
}
