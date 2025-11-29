using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace QuizApplication
{
    public class Student : User
    {
        protected string status;
        public string Status
        {
            get { return status; }
            protected set { status = value; }
        }
        public Student(string UserName, string UserPassword, string UserEmail): base(UserName, UserPassword, UserEmail, "student")
        {
            
            this.UserRole = "student";
           
        }
        public Student() : base()
        {
            this.UserRole = "";
        }

       
        public void ManageStatus(string uStatus)
        {
            this.status = uStatus;
        }
    }
}
