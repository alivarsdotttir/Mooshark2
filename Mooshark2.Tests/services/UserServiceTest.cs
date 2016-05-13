using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooshark2.Services;
using System.Web.Mvc;

namespace Mooshark2.Tests.services
{
    [TestClass]
    public class UserServiceTest
    {
    

        //*********************** Test GetUserById ************************
        [TestMethod]
        public void TestGetUserByIdNotExist()
        {
            // Arrange
            const string userid = "-1";
            var service = new UserService();

            // Act
            var result = service.getUserById(userid);

            // Assert

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void TestGetUserByIdExist()
        {
            // Arrange
            const string userid = "5254714a-f2c8-4d04-8748-1a5f7829766d";
            var service = new UserService();

            // Act
            var result = service.getUserById(userid);

            // Assert

            Assert.IsTrue(result.UserName.Equals("admin"));
        }
    }
}
