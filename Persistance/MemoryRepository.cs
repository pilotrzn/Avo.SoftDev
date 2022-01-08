using Avo.SoftDev.Domain;
using Avo.SoftDev.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avo.SoftDev.Persistance
{
    internal class MemoryRepository : IRepository
    {
        #region FakeData
        private List<TimeRecord> employees = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.AddDays(-3),"Иванов",8,"ттт"),
                new TimeRecord(DateTime.Now.AddDays(-3),"Петров",8,"ттт"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Иванов",10,"ттт"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Петров",8,"ттт")
            };

        private List<User> users = new List<User>()
            {
                new User("Иванов", UserRole.Employee),
                new User("Петров",UserRole.Employee),
                new User("Смит",UserRole.Freelancer),
                new User("Бонд",UserRole.Freelancer),
                new User("Аво",UserRole.Manager),
            };

        private List<TimeRecord> freelancers = new List<TimeRecord>()
        {
            new TimeRecord(DateTime.Now.AddDays(-3),"Смит",8,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-3),"Бонд",8,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Смит",10,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Бонд",8,"ттт")
        };

        private List<TimeRecord> managers = new List<TimeRecord>()
        {
            new TimeRecord(DateTime.Now.AddDays(-3),"Аво",8,"ттт"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Аво",8,"ттт"),
        }; 
        #endregion

        public List<TimeRecord> Employees()
        {
            return employees;
        }

        public List<TimeRecord> Freelancers()
        {
            return freelancers;
        }

        public List<TimeRecord> Managers()
        {
            return managers;
        }

        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            var records = new List<TimeRecord>();
            switch (userRole)   
            {
                case UserRole.Manager:
                    records = Managers();
                    break;
                case UserRole.Employee:
                    records = Employees();
                    break;
                case UserRole.Freelancer:
                    records = Freelancers();
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
            if (from ==  null)
            {
                from = DateTime.Now.AddYears(-100);
            }
            if (to == null)
            {
                to = DateTime.Now;
            }
            return records.Where(x => from.Value >= x.Date && x.Date >= to.Value).ToList();
        }

        public List<TimeRecord> ReportGetByUser(string name, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            return ReportGet(userRole, from, to).Where(x => x.Name == name).ToList();
        }

        public void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord)
        {
            switch (userRole)
            {
                case UserRole.Manager:
                    managers.Add(timeRecord);
                    break;
                case UserRole.Employee:
                    employees.Add(timeRecord);
                    break;
                case UserRole.Freelancer:
                    freelancers.Add(timeRecord);
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
        }

        public bool UserCreate(UserRole userRole, string name)
        {
            var NewUser = new User(name, userRole);
            User UserExist = UserGet(name);
            if (UserExist == null)
            {
                users.Add(NewUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User UserGet(string name)
        {
            return Users().FirstOrDefault(x => x.Name == name);
        }

        public List<User> Users()
        {
            return users;
        }
    }
}