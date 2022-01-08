using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public class Manager:Stuff
    {
        public decimal MonthBonus => 20000;
        public decimal TotalPay { get; }
        public Manager(string name, List<TimeRecord> timeRecords) : base(name, 200000,timeRecords)
        {
            decimal totalPay = 0;
            decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            decimal bonusPerDay = Settings.WorkHoursInDay * MonthBonus / Settings.WorkHoursInMonth;
            
            foreach (var timerecord in timeRecords)
            {
                totalPay += timerecord.Hours <= 8 ? timerecord.Hours * payPerHour : Settings.WorkHoursInDay * payPerHour + bonusPerDay;
                //if (timerecord.Hours <= 8)
                //{
                //    totalPay += timerecord.Hours * payPerHour;
                //}
                //else
                //{
                //    totalPay += Settings.WorkHoursInDay * payPerHour + bonusPerDay;   
                //}
            }
            TotalPay = totalPay;
        } 
    }
}
