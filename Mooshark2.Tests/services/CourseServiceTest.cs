using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooshark2.Services;
using Mooshark2.Models.Entities;

namespace Mooshark2.Tests.services
{
    [TestClass]
    public class CourseServiceTest
    {
        // ********    Test getCoursesForStudent    *************************************
        [TestMethod]
        public void TestGetCoursesForStudentNotExist()
        {
            // Arrange
            const string studentid = "-1";
            var service = new CourseService();

            // Act
             var result = service.getCoursesForStudent(studentid);

            // Assert
            int cnt = 0;
            foreach (Course value in result)
            {
                cnt++;
                break;
            }
            Assert.IsTrue(cnt == 0);
        }

        [TestMethod]
        public void TestGetCoursesForStudentExist()
        {
            // Arrange
            const string studentid = "9c197a28-e33e-4faf-8d18-0e8b24381785";
            var service = new CourseService();

            // Act
            var result = service.getCoursesForStudent(studentid);

            // Assert
            int cnt = 0;
            foreach (Course value in result)
            {
                cnt++;
                break;
            }
            Assert.IsTrue(cnt > 0);
        }


        // ********    Test getCoursesForTeacher    *************************************
        [TestMethod]
        public void TestGetCoursesForTeacherNotExist()
        {
            // Arrange
            const string teacherid = "-1";
            var service = new CourseService();

            // Act
            var result = service.getCoursesForTeacher(teacherid);

            // Assert
            int cnt = 0;
            foreach (Course value in result)
            {
                cnt++;
                break;
            }
            Assert.IsTrue(cnt == 0);
        }

        [TestMethod]
        public void TestGetCoursesForTeacherExist()
        {
            // Arrange
            const string teacherid = "cad253be-d742-4f0b-879d-80b9a8fca2d6";
            var service = new CourseService();

            // Act
            var result = service.getCoursesForTeacher(teacherid);

            // Assert
            int cnt = 0;
            foreach (Course value in result)
            {
                cnt++;
                break;
            }
            Assert.IsTrue(cnt > 0);
        }

        // ********    Test getCourseById    *************************************
        [TestMethod]
        public void TestGetCourseByIdNotExist()
        {
            // Arrange
            const int courseid = -1;
            var service = new CourseService();

            // Act
            var result = service.getCourseById(courseid);

            // Assert
            
            Assert.IsTrue(result == null);
        }
        [TestMethod]
        public void TestGetCourseByIdExist()
        {
            // Arrange
            const int courseid = 1;
            var service = new CourseService();

            // Act
            var result = service.getCourseById(courseid);

            // Assert

            Assert.IsTrue(result.Name.Equals("Forritun 1"));
        }
    }
}
