using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public class Manager:Stuff
    {
        public decimal MonthBonus => 20000;
        public Manager(string name, List<TimeRecord> timeRecords) : base(name, 200000,timeRecords)
        {
            decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            decimal TotalPay = 0;
            decimal bonusPerDay = Settings.WorkHoursInDay * MonthBonus / Settings.WorkHoursInMonth;
            foreach (var timerecord in timeRecords)
            {
                if (timerecord.Hours <= 8)
                {
                    TotalPay += timerecord.Hours * payPerHour;
                }
                else
                {
                    TotalPay += Settings.WorkHoursInDay * payPerHour + bonusPerDay;   
                }
                //вариант сокращенной записи
                TotalPay += timerecord.Hours <= 8 ? timerecord.Hours * payPerHour : Settings.WorkHoursInDay * payPerHour + bonusPerDay;
            }
        } 
    }
}
