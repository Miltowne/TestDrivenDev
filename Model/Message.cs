using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Message
    {
        public DateTime SendDateTime { get; set; }
        public string Body { get; set; }

        public Message(string userName, string message)
        {
            Body = message + "from" + userName;
            SendDateTime = DateTime.Now;
        }



    }
}
