using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public string UserName { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Message> Messages { get; set; } = new List<Message>();
        public List<User> MySubscriptions { get; set; } = new List<User>();


        public User(string UserName)
        {
            this.UserName = UserName;
        }

        
    }
}
