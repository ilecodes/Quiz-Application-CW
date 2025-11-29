using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    public abstract class User
    {
        protected int userId;
        private string userName;
        private string userPassword;
        private string userEmail;
        private string userRole;
        private static int userCount = 1;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }
        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }
        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
        public int UserId
        {
            get { return userId; }
            protected set { userId = value; }
        }
        public static int UserCount { get { return userCount; } }
        protected static int GetNextUserId()
        {
            return userCount++;
        }
        public User() { }
        public User(string UserName, string UserPassword, string UserEmail, string UserRole)
        {
            this.userName = UserName;
            this.userPassword = UserPassword;
            this.userEmail = UserEmail;
            this.userRole = UserRole;
            this.userId = GetNextUserId();
        }
        public void LoadUser()
        {
            Console.WriteLine($"ID:{userId}");
            Console.WriteLine($"Username: {userName}");
            Console.WriteLine($"Password: {userPassword}");
            Console.WriteLine($"Email: {userEmail}");

        }
        public void UpdateUser(string uName, string uPassword, string uEmail)
        {
            if (! string.IsNullOrWhiteSpace(uName)) { this.userName = uName; }
            if (! string.IsNullOrWhiteSpace(uPassword)) { this.userPassword = uPassword; }
            if (!string.IsNullOrWhiteSpace(uEmail)) { this.userEmail = uEmail; }
         
        }
        public void LoggedIn()
        {
            Console.WriteLine($"{userName} logged in successfully as {userRole}.");
        }
        public void Logout()
        {
            Console.WriteLine($"{userName} logged out successfully.");
        }
    }
}
