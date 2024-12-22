using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Entities
{
        public class User
        {
            private int EId;
            private string Ename;
            private string user;
            private string dob;
            private string number;
            private string email;
            private string gender;
            private string usertype;
            private string password;

            public int EmployeeId {
            get { return EId; }
            set { EId = value; } 
             }
            public string Name {
            get { return Ename; }
            set { Ename = value; }
        }
            public string Username {
            get { return user; }
            set { user = value; }
        }
            public string DateOfBirth {
            get { return dob; }
            set { dob = value; }
        }
            public string Email {
            get { return email; }
            set { email = value; }
        }
            public string PhoneNumber {
            get { return number; }
            set { number = value; }
        }
            public string Gender {
            get { return gender; }
            set { gender = value; }
        }
            public string UserType {
            get { return usertype; }
            set { usertype = value; }
        }
            public string Password {
            get { return password; }
            set { password = value; }
        }

    }
    
}
