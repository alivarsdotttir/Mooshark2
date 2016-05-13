using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooshark2.Services;
using Mooshark2.Models.Entities;

namespace Mooshark2.Tests.services
{
    [TestClass]
    public class ProjectServiceTest
    {
        // ********    Test getProjectsForCourse    *************************************
        [TestMethod]
        public void TestGetProjectForCourseNotExist()
        {
            // Arrange
            const int courseid = -1;
            var service = new ProjectService();

            // Act
            var result = service.getProjectsForCourse(courseid);

            // Assert
            int cnt = 0;
            foreach (Project value in result)
            {
                cnt++;
                break;
            }
            Assert.IsTrue(cnt == 0);
        }

        [TestMethod]
        public void TestGetProjectForCourseExist()
        {
            // Arrange
            const int courseid = 1;
            var service = new ProjectService();

            // Act
            var result = service.getProjectsForCourse(courseid);

            // Assert
            int cnt = 0;
            foreach (Project value in result)
            {
                cnt++;
                break;
            }
            Assert.IsTrue(cnt > 0);
        }

        // ********    Test getProjectById    *************************************
        [TestMethod]
        public void TestGetProjectByIdNotExist()
        {
            // Arrange
            const int projectid = -1;
            var service = new ProjectService();

            // Act
            var result = service.getProjectById(projectid);

            // Assert

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void TestGetProjectByIdExist()
        {
            // Arrange
            const int projectid = 1;
            var service = new ProjectService();

            // Act
            var result = service.getProjectById(projectid);

            // Assert

            Assert.IsTrue(result.Name.Equals("Project 1"));
        }
    }
}
