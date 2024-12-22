using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Entities
{
     public class Customer
    {

        private string phonenumber;
        private string name;

        public string PhoneNumber 
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }

        public string Name
        {
            get { return  name; }
            set { name = value; }
        }
    }
}
