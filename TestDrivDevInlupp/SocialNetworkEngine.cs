using System;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class SocialNetworkEngine
    {
        public List<User> Users { get; set; } = new List<User>();



        public bool UserExist(string name)
        {
            var user = Users.FirstOrDefault(x => x.UserName == name);
            if (user == null)
            {
                return false;
            }
            else return true;
        }

        public void CreateUser(string name)
        {
            User user = new User(name);
            Users.Add(user);
        }

        public User GetUser(string name)
        { 
            foreach (var user in Users)
            {
                if (user.UserName == name) return user;
            }
            CreateUser(name);
            return Users.FirstOrDefault(x => x.UserName == name);
        }

        public List<Post> Wall(string user)
        {
            List<Post> SubscriptionList = new List<Post>();

            GetUser(user).MySubscriptions.ForEach(r => SubscriptionList.AddRange(r.Posts.Where(x => r.UserName == x.Sender)));

            return SubscriptionList.OrderByDescending(s => s.SendDateTime).ToList();
        }


        public List<Post> TimeLine(string user)
        {
            return GetUser(user).Posts.OrderByDescending(s => s.SendDateTime).ToList();
        }


        public List<User> Follow(string user, string followedUser)
        {
            GetUser(user).MySubscriptions.Add(GetUser(followedUser));
            return GetUser(user).MySubscriptions;
        }

        public void CreatePost(string user, string post)
        {
            var newPost = new Post(user, post);

            if (post[0] == '@')
            {
                GetUser(user).Posts.Add(newPost);
                var postArray = post.Split(' ');
                string receiver = postArray[0].Remove(0, 1);
                SendMessage(user, receiver, post);
                GetUser(receiver).Posts.Add(newPost);
            }
            else
                GetUser(user).Posts.Add(newPost);
        }

        public void SendMessage(string user, string receiverUser, string message)
        {
            GetUser(receiverUser).Messages.Add(new Message(user, message));
        }

        public List<Message> ViewMessages(string user)
        {
            return GetUser(user).Messages.OrderByDescending(x => x.SendDateTime).ToList();
        }
    }
}
