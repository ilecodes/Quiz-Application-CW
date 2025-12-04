using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;

namespace QuizApplicationTests
{
    [TestClass]
    public class AdminTests
    {
        // Default constructor
        [TestMethod]
        public void DefaultConstructor_ShouldCreateAdminObject()
        {
            // Act
            var admin = new Admin();

            // Assert
            Assert.IsNotNull(admin, "Admin instance should be created.");
        }

        // Custom constructor set user data
        [TestMethod]
        public void CustomConstructor_ShouldSetUsernamePasswordEmailAndRole()
        {
            // Arrange
            string expectedName = "AdminUser";
            string expectedPass = "Secret123";
            string expectedEmail = "admin@example.com";

            // Act
            var admin = new Admin(expectedName, expectedPass, expectedEmail);

            // Assert
            Assert.AreEqual(expectedName, admin.UserName);
            Assert.AreEqual(expectedPass, admin.UserPassword);
            Assert.AreEqual(expectedEmail, admin.UserEmail);
            Assert.AreEqual("admin", admin.UserRole, "Admin constructor should force UserRole = 'admin'.");
        }

        // Custom constructor set LoginDate ToCurrentTime
        [TestMethod]
        public void CustomConstructor_ShouldInitializeLoginDate()
        {
            // Arrange
            DateTime before = DateTime.Now;

            // Act
            var admin = new Admin("A", "B", "C");

            DateTime after = DateTime.Now;

            // Assert
            Assert.IsTrue(
                admin.LoginDate >= before && admin.LoginDate <= after.AddSeconds(1),
                "LoginDate must be set to a current timestamp when created."
            );
        }

        // LoggedDate() ypdates LoginDate
        [TestMethod]
        public void LoggedDate_ShouldUpdateLoginDateToCurrentTime()
        {
            // Arrange
            var admin = new Admin("X", "Y", "Z");
            DateTime oldDate = admin.LoginDate;

            System.Threading.Thread.Sleep(20); // ensure time separation

            // Act
            admin.LoggedDate();

            // Assert
            Assert.IsTrue(admin.LoginDate > oldDate,
                "LoggedDate() should refresh LoginDate to a more recent time.");
        }

        // LoginDate read/write works
        [TestMethod]
        public void LoginDateProperty_ShouldSetAndReturnValue()
        {
            // Arrange
            var admin = new Admin();
            DateTime expected = new DateTime(2023, 8, 15, 12, 30, 0);

            // Act
            admin.LoginDate = expected;

            // Assert
            Assert.AreEqual(expected, admin.LoginDate);
        }

        // LoggedDate() should not throw exceptions 
        [TestMethod]
        public void LoggedDate_ShouldNotThrowExceptions()
        {
            // Arrange
            var admin = new Admin();

            // Act & Assert
            try
            {
                admin.LoggedDate();
            }
            catch
            {
                Assert.Fail("LoggedDate() must not throw exceptions because of internal try-catch.");
            }
        }
    }
}
