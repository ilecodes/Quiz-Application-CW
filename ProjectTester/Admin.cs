using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    public class Admin : User
    {
        private DateTime loginDate;
        public DateTime LoginDate
        {
            get { return loginDate; }
            set{loginDate = value;}
        }
        public Admin(): base()
        {
            this.UserRole = "";
        }
        public Admin(string UserName, string UserPassword, string UserEmail): base(UserName, UserPassword, UserEmail, "admin")
        {
            
            this.LoginDate = DateTime.Now;
            
             
        }
 
       
        public void LoggedDate()
        {
            this.loginDate = DateTime.Now;
        }
        
    }
}
