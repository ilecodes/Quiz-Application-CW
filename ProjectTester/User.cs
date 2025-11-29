using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    // User is a parent, so it is declared as abstract
    public abstract class User 
    {
        // protected attribute for user ID due to the fact its needed to be accessed by derived classes
        protected int userId;
        // private attributes of the User class
        private string userName;
        private string userPassword;
        private string userEmail;
        private string userRole;
        private static int userCount = 1;

        // public properties for accessing private attributes
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
        // UserId property is read-only from outside the class
        public int UserId
        {
            get { return userId; }
            protected set { userId = value; }
        }
        public static int UserCount { get { return userCount; } }
        // this method increments the userCount and gives it to the User ID, so each user has a unique ID
        protected static int GetNextUserId()
        {
            return userCount++;
        }
        // default constructor for good practice
        public User() { }
        // custom constructor to initialize user attributes with the required passed parameters
        public User(string UserName, string UserPassword, string UserEmail, string UserRole)
        {
            this.userName = UserName;
            this.userPassword = UserPassword;
            this.userEmail = UserEmail;
            this.userRole = UserRole;
            // static method called to get unique user ID, and avoid errors
            this.userId = GetNextUserId(); 
        }
        // method to load user data
        public void LoadUser()
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // displaying user data to the console
                Console.WriteLine($"ID:{userId}");
                Console.WriteLine($"Username: {userName}");
                Console.WriteLine($"Password: {userPassword}");
                Console.WriteLine($"Email: {userEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading user data: {ex.Message}");
            }
        }
        // method to update user data, passing parameters that hold the new data
        public void UpdateUser(string uName, string uPassword, string uEmail)
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // if the passed parameter is not null or whitespace, update the corresponding attribute, helps the user to update only what they want without retypying everything
                if (!string.IsNullOrWhiteSpace(uName)) { this.userName = uName; }
                if (!string.IsNullOrWhiteSpace(uPassword)) { this.userPassword = uPassword; }
                if (!string.IsNullOrWhiteSpace(uEmail)) { this.userEmail = uEmail; }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating user data: {ex.Message}");
            }
        }
        //method to show that the specific user has logged in successfully
        public void LoggedIn()
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                Console.WriteLine($"{userName} logged in successfully as {userRole}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during login: {ex.Message}");
            }
           
        }
        //method to show that the specific user has logged out successfully
        public void Logout()
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                Console.WriteLine($"{userName} logged out successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during logout: {ex.Message}");
            }
           
        }
    }
}
