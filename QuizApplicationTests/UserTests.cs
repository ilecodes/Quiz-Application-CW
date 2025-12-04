using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;

namespace QuizApplicationTests
{
    // to test abstract User class
    public class TestUser : User
    {
        public TestUser() : base() { }

        public TestUser(string username, string password, string email, string role)
            : base(username, password, email, role) { }
    }

    [TestClass]
    public class UserTests
    {
        // Default constructor should create object
        [TestMethod]
        public void DefaultConstructor_ShouldCreateUserInstance()
        {
            var user = new TestUser();
            Assert.IsNotNull(user, "User instance should be created.");
        }

        // Custom constructor sets all fields correctly
        [TestMethod]
        public void CustomConstructor_ShouldSetPropertiesCorrectly()
        {
            string username = "John";
            string password = "pass123";
            string email = "john@example.com";
            string role = "member";

            var user = new TestUser(username, password, email, role);

            Assert.AreEqual(username, user.UserName, "UserName should match constructor value.");
            Assert.AreEqual(password, user.UserPassword, "UserPassword should match constructor value.");
            Assert.AreEqual(email, user.UserEmail, "UserEmail should match constructor value.");
            Assert.AreEqual(role, user.UserRole, "UserRole should match constructor value.");
            Assert.IsTrue(user.UserId > 0, "UserId should be greater than zero.");
        }

        // UserCount increments correctly
        [TestMethod]
        public void UserCount_ShouldIncrementWithEachNewUser()
        {
            var u1 = new TestUser("A", "B", "C", "member");
            var u2 = new TestUser("X", "Y", "Z", "admin");

            Assert.IsTrue(u2.UserId > u1.UserId, "Second user's ID should be higher than first user's ID.");
        }

        // UpdateUser updates only non-empty fields
        [TestMethod]
        public void UpdateUser_ShouldUpdateOnlyProvidedFields()
        {
            var user = new TestUser("OldName", "OldPass", "old@example.com", "member");

            user.UpdateUser("NewName", null, "new@example.com");

            Assert.AreEqual("NewName", user.UserName);
            Assert.AreEqual("OldPass", user.UserPassword, "Password should remain unchanged if null is passed.");
            Assert.AreEqual("new@example.com", user.UserEmail);
        }

        // LoggedIn and Logout do not throw exceptions
        [TestMethod]
        public void LoggedIn_ShouldNotThrowException()
        {
            var user = new TestUser("TestUser", "pass", "email@test.com", "member");

            try
            {
                user.LoggedIn();
            }
            catch
            {
                Assert.Fail("LoggedIn() should not throw exceptions.");
            }
        }

        [TestMethod]
        public void Logout_ShouldNotThrowException()
        {
            var user = new TestUser("TestUser", "pass", "email@test.com", "member");

            try
            {
                user.Logout();
            }
            catch
            {
                Assert.Fail("Logout() should not throw exceptions.");
            }
        }

        // LoadUser should not throw exceptions
        [TestMethod]
        public void LoadUser_ShouldNotThrowException()
        {
            var user = new TestUser("TestUser", "pass", "email@test.com", "member");

            try
            {
                user.LoadUser();
            }
            catch
            {
                Assert.Fail("LoadUser() should not throw exceptions.");
            }
        }
    }
}
