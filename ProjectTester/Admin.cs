using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    // Admin class represents the admin users of the quiz application
    // Admin class inherits from User class, admin is a child
    public class Admin : User
    {
        // private attribute specific to Admin class
        private DateTime loginDate;
        // public property to access loginDate
        public DateTime LoginDate
        {
            get { return loginDate; }
            set{loginDate = value;}
        }
        // default constructor, obviously calls base class default constructor
        public Admin(): base()
        {
            
        }
        // custom constructor that calls base class custom constructor, the Admin constructor does not need the UserRole parameter, because once called the object is known to be admin as role
        public Admin(string UserName, string UserPassword, string UserEmail): base(UserName, UserPassword, UserEmail, "admin")
        {
            // Initialize loginDate to current date and time, just so its not empty
            this.LoginDate = DateTime.Now;
            this.UserRole = "admin";

        }

        // method to update loginDate to the last logged in date and time
        public void LoggedDate()
        {
            // when admin logs in, this attribute is updated
            // try-catch block to handle any potential exceptions and output appropriate message
            try
            {
                this.loginDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating login date: {ex.Message}");
            }
            
        }
        
    }
}
