using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace QuizApplication
{
    // Student class represents the student users of the quiz application
    // Student class inherits from User class, student is a child
    public class Student : User
    {
        // protected attribute for status to allow access by other subclasses if needed (Admin)
        // this shows if the student is active, inactive
        protected string status;
        // public property to access status
        public string Status
        {
            get { return status; }
            protected set { status = value; } // only other derived classes can set status
        }
        // custom constructor that calls base class custom constructor, the student constructor here does not need the UserRole as parameter passed, because automatically if this constructor is called that means the role is student
        public Student(string UserName, string UserPassword, string UserEmail): base(UserName, UserPassword, UserEmail, "student")
        {
            // Initialize status to "active" by default
            this.status = "active";
            this.UserRole = "student";
           
        }
        // default constructor, obviously calls base class default constructor
        public Student() : base()
        {
            
        }

        // method to change the status of the student
        public void ManageStatus(string uStatus)
        {
            // try-catch block to handle any potential exceptions and output appropriate message
            try
            {
                // update status to the passed parameter
                this.status = uStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating status: {ex.Message}");
            }
            
        }
    }
}
