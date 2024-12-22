using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Entities
{
     public class Message
    {
        //private string receiver;
        private string sender;
        private string messages;
        public string Receiver { get; set; }
        public string Sender
        {
            get { return  sender; }
            set {  sender = value; }
        }
        public string Messages {
            get { return messages; }
            set { messages = value; }
            
        }
    }
}
