using Avo.SoftDev.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Avo.SoftDev.SDTests
{
    public class PersonsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestManager()
        {
            Manager manager = new Manager("user1", new List<TimeRecord>(){
                new TimeRecord(DateTime.Now.AddDays(-3),"user1",8,""),
                new TimeRecord(DateTime.Now.AddDays(-2),"user1",9,""),
                new TimeRecord(DateTime.Now.AddDays(-1),"user1",7,""),
            });

            Assert.IsTrue(manager.TotalPay == 29750);
        }

    }
}