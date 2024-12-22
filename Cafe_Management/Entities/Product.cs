using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Entities
{
     public class Product
    {

        private int pid;
        private string productname;
        private Double price;
        private int quantity;
        private int cid;
        public int ProductId
        {
            get { return pid; }
            set { pid = value; }
        }
        public string ProductName {
            get { return productname; }
            set { productname = value; }
        }
        public Double Price {
            get { return price; }
            set { price = value; }
        }
        public int Quantity {
            get { return quantity; }
            set { quantity = value; }
        }
        public int CategoryId {
            get { return cid; }
            set { cid = value; }
        }
    }
}
