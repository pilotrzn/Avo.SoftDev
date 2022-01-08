using Avo.SoftDev.Domain;
using Avo.SoftDev.Domain.Persons;
using Avo.SoftDev.Persistance;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avo.SoftDev.SDTests
{
    public class RepositoryTest
    {
        IRepository memoryRepo = new MemoryRepository();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserCreate()
        {
            bool isCreated = memoryRepo.UserCreate(UserRole.Employee, "Купер");
            var newuser = memoryRepo.Users().FirstOrDefault(x => x.Name == "Купер");

            Assert.IsTrue(isCreated);
            Assert.IsTrue(newuser != null);
            Assert.IsTrue(newuser.UserRole == UserRole.Employee);
        }


        [Test]
        public void UserCreateEmp()
        {
            bool isCreated = memoryRepo.UserCreate(UserRole.Employee, "Иванов");
            var newuser = memoryRepo.Users().FirstOrDefault(x => x.Name == "Иванов");

            Assert.IsTrue(!isCreated);
            Assert.IsTrue(newuser != null);
            Assert.IsTrue(newuser.UserRole == UserRole.Employee);
        }

        [Test]
        public void UserGetTest()
        {
            var user = memoryRepo.UserGet("Иванов");
            Assert.IsTrue(user != null);

        }

        [Test]
        public void ReportGetByUserTest()
        {
            var reportList = memoryRepo.ReportGetByUser("Иванов",UserRole.Employee,null,null);
            var samplelist = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"Иванов",8,"ттт"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"Иванов",10,"ттт"),
            };
             
            //var firstInSecond = reportList.Except(samplelist).ToList();
            //var secondInSecond = samplelist.Except(reportList).ToList();
            
            //Assert.IsTrue(!secondInSecond.Any() && !firstInSecond.Any());
            Assert.IsTrue( Enumerable.SequenceEqual(reportList,samplelist,new TimeRecordComparer()));
        }
    }
}