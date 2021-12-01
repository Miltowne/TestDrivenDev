using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Model
{
    public class Post
    {
        public DateTime SendDateTime { get; set; }
        public string Body { get; set; }

        public string Sender { get; set; }

        public Post(string userName, string message)
        {
            Sender = userName;
            Body = message;
            SendDateTime = DateTime.Now;
        }
    }
}
