using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;

namespace QuizApplicationTests
{
    [TestClass]
    public class StudentTests
    {
        // Default constructor should create instance
        [TestMethod]
        public void DefaultConstructor_ShouldCreateStudentInstance()
        {
            var student = new Student();
            Assert.IsNotNull(student, "Student instance should be created.");
        }

        // Custom constructor should initialize prroperties
        [TestMethod]
        public void CustomConstructor_ShouldSetPropertiesCorrectly()
        {
            string username = "Alice";
            string password = "alice123";
            string email = "alice@example.com";

            var student = new Student(username, password, email);

            Assert.AreEqual(username, student.UserName);
            Assert.AreEqual(password, student.UserPassword);
            Assert.AreEqual(email, student.UserEmail);
            Assert.AreEqual("student", student.UserRole, "Role should automatically be 'student'.");
            Assert.AreEqual("active", student.Status, "Status should default to 'active'.");
            Assert.IsTrue(student.UserId > 0, "UserId should be greater than zero.");
        }

        // ManageStatus should update status correctly
        [TestMethod]
        public void ManageStatus_ShouldUpdateStatus()
        {
            var student = new Student("Bob", "pass", "bob@example.com");
            student.ManageStatus("inactive");

            Assert.AreEqual("inactive", student.Status, "ManageStatus should update the status.");
        }

        // ManageStatus should not throw exception
        [TestMethod]
        public void ManageStatus_ShouldNotThrowException()
        {
            var student = new Student("Charlie", "pass", "charlie@example.com");

            try
            {
                student.ManageStatus("suspended");
            }
            catch
            {
                Assert.Fail("ManageStatus() should not throw exceptions.");
            }
        }

        // Inherited User properties should work
        [TestMethod]
        public void InheritedProperties_ShouldWorkCorrectly()
        {
            var student = new Student("Dana", "pass", "dana@example.com");

            student.UpdateUser("DanaNew", "newpass", "newemail@example.com");

            Assert.AreEqual("DanaNew", student.UserName);
            Assert.AreEqual("newpass", student.UserPassword);
            Assert.AreEqual("newemail@example.com", student.UserEmail);
        }
    }
}
