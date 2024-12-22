using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Entities
{
    public class Category
    {
        private int CId;
        private string CName;
        public int CategoryId 
        { 
            get { return CId; } 
            set { CId = value; } 
        }
        public string CategoryName
        {
            get { return CName; }
            set { CName = value; }
        }
    }
}
