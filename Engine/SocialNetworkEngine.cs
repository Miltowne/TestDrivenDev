using System;
using SocialNetwork.Model;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class SocialNetworkEngine
    {
        List<User> Users { get; set; } = new List<User>();



        public bool UserExist(string name)
        {
            var user = Users.FirstOrDefault(x => x.UserName == name);
            if (user == null)
            {
                CreateUser(name);
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
            if (!UserExist(name))
                CreateUser(name);

            foreach (var user in Users)
            {
                if (user.UserName == name) return user;
            }
            throw new ArgumentException($"username: {name}, does not exist");
        }

        public List<Post> Wall(string user)
        {
            List<Post> SubscriptionList = new List<Post>();

            GetUser(user).MySubscriptions.ForEach(r => SubscriptionList.AddRange(r.Posts.Where(x => r.UserName == x.Sender)));

            return SubscriptionList.OrderByDescending(s => s.SendDateTime).ToList();
        }


        public List<Post> TimeLine(string user)
        {
            List<Post> postList = new List<Post>();
            GetUser(user).Posts.Sort((a, b) => b.SendDateTime.CompareTo(a.SendDateTime));
            foreach (var post in GetUser(user).Posts)
                postList.Add(post);
            return postList;
        }


        public List<User> Follow(string user, string followedUser)
        {
            GetUser(user).MySubscriptions.Add(GetUser(followedUser));
            return GetUser(user).MySubscriptions;
        }

        public void CreatePost(string user, string post)
        {
            var newPost = new Post(user, post);

            if (newPost.Body[0] == '@')
            {
                GetUser(user).Posts.Add(newPost);
                var postArray = post.Split(' ');
                postArray[0].Remove(0, 1);
                SendMessage(user, postArray[0], post);
                GetUser(postArray[0]).Posts.Add(newPost);
            }
            GetUser(user).Posts.Add(newPost);
        }

        public void SendMessage(string user, string receiverUser, string message)
        {
            GetUser(receiverUser).Messages.Add(new Message(user, message));
        }

        public List<Message> ViewMessages(string user)
        {
            var messageList = new List<Message>();
            GetUser(user).Messages.Sort((a, b) => b.SendDateTime.CompareTo(a.SendDateTime));
            foreach (var message in GetUser(user).Messages)
            {
                messageList.Add(message);
            }
            return messageList;
        }
    }
}
