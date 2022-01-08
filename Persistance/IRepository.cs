using System;
using System.Collections.Generic;
using Avo.SoftDev.Domain;
using Avo.SoftDev.Domain.Persons;

namespace Avo.SoftDev.Persistance
{
    public interface IRepository
    {
        List<User> Users();
        bool UserCreate(UserRole userRole, string name);
        User UserGet(string name);
        void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord);
        List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null,DateTime? to = null);
        List<TimeRecord> ReportGetByUser(string name, UserRole userRole, DateTime? from = null, DateTime? to = null);
        List<TimeRecord> Employees();
        List<TimeRecord> Managers();
        List<TimeRecord> Freelancers();
    }

}
 