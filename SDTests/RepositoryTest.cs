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
            bool isCreated = memoryRepo.UserCreate(UserRole.Employee, "�����");
            var newuser = memoryRepo.Users().FirstOrDefault(x => x.Name == "�����");

            Assert.IsTrue(isCreated);
            Assert.IsTrue(newuser != null);
            Assert.IsTrue(newuser.UserRole == UserRole.Employee);
        }


        [Test]
        public void UserCreateEmp()
        {
            bool isCreated = memoryRepo.UserCreate(UserRole.Employee, "������");
            var newuser = memoryRepo.Users().FirstOrDefault(x => x.Name == "������");

            Assert.IsTrue(!isCreated);
            Assert.IsTrue(newuser != null);
            Assert.IsTrue(newuser.UserRole == UserRole.Employee);
        }

        [Test]
        public void UserGetTest()
        {
            var user = memoryRepo.UserGet("������");
            Assert.IsTrue(user != null);

        }

        [Test]
        public void ReportGetByUserTest()
        {
            var reportList = memoryRepo.ReportGetByUser("������",UserRole.Employee,null,null);
            var samplelist = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"������",8,"���"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"������",10,"���"),
            };
             
            //var firstInSecond = reportList.Except(samplelist).ToList();
            //var secondInSecond = samplelist.Except(reportList).ToList();
            
            //Assert.IsTrue(!secondInSecond.Any() && !firstInSecond.Any());
            Assert.IsTrue( Enumerable.SequenceEqual(reportList,samplelist,new TimeRecordComparer()));
        }
    }
}