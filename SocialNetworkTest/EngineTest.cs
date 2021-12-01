using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkTest
{
    [TestClass]
    public class UnitTest1
    {
        public SocialNetworkEngine engine { get; set; }

        [TestInitialize]
        public void TestInitializer()
        {
            engine = new SocialNetworkEngine();
            //    engine.CreateUser("Alice");
            //    engine.CreateUser("Bob");
            //    engine.CreateUser("Charlie");
            //    engine.CreateUser("Mallory ");
            //    engine.CreateUser("Erik");
            //    engine.CreateUser("Patrik");
            //    engine.CreateUser("Cuba");
            //    engine.CreateUser("Elis");
            //    engine.CreateUser("Martin");
        }

        [TestMethod]
        [DataRow("Pia")]
        public void TestUserExist(string user)
        {
            //Arrange


            //Act
            bool userExist = engine.UserExist(user);

            //Assert
            Assert.IsFalse(userExist);
        }

        [TestMethod]
        [DataRow("Milton")]
        public void TestCreateUser(string name)
        {
            //Arrange
            List<User> Users = new List<User>();
            User user = new User(name);
            Users.Add(user);


            //Act
            engine.CreateUser(name);

            //Assert
            Assert.AreEqual(engine.Users[0].UserName, user.UserName);
        }

        [TestMethod]
        [DataRow("Milton", "Joe", "kikiki")]
        public void TestWall(string name, string followedUser, string post)
        {
            //Arrange

            engine.CreateUser(name);
            engine.CreateUser(followedUser);
            var user1 = engine.GetUser(name);
            var user2 = engine.GetUser(followedUser);

            var posten = new Post(followedUser, post);

            user1.Posts.Add(posten);
            user2.Posts.Add(posten);


            //Act
            engine.Follow(name, followedUser);
            var list = engine.Wall(name);


            //Assert
            Assert.AreEqual(list.FirstOrDefault(), posten);
        }


        [TestMethod]
        [DataRow("Milton", "detta är en påst")]
        public void TestTimeline(string name, string post)
        {
            //Arrange
            engine.CreatePost(name, post);

            //Act
            var list = engine.TimeLine(name);

            //Assert
            Assert.AreEqual(list.FirstOrDefault().Body, post);
        }

        [TestMethod]
        [DataRow("Pia", "Ludde", "Vad gï¿½r du?")]
        public void TestViewMessages(string sender, string receiver, string message)
        {
            //Arrange
            var receiverUser = engine.GetUser(receiver);

            //Act
            engine.SendMessage(sender, receiver, message);

            //Assert
            Assert.AreEqual(message, receiverUser.Messages.FirstOrDefault().Body);
        }


        [TestMethod]
        [DataRow("Erik", "Sara"), DataRow("Elis", "Patrik"), DataRow("Martin", "Cuba")]
        public void TestFollower(string follower, string followed)
        {
            //Arrange
            var followerUser = engine.GetUser(follower);

            //Act
            engine.Follow(follower, followed);


            //Assert
            Assert.AreEqual(followerUser.MySubscriptions.FirstOrDefault().UserName, followed);
        }

        [TestMethod]
        [DataRow("Erik", "/Post", "Hello")]
        public void TestExistsOnTimeline(string sender, string receiver, string post)
        {
            //Arrange
            var user = engine.GetUser("Erik");

            var timelineList = user.Posts;


            //Act
            engine.CreatePost(sender, post);


            //Assert
            Assert.AreEqual(1, timelineList.Count);
        }


        [TestMethod]
        [DataRow("Erik"), DataRow("Tim")]
        public void TestGetUser(string expectedName)
        {
            //Arrange

            //Act
            engine.CreateUser(expectedName);
            var actualName = engine.GetUser(expectedName);

            //Assert
            Assert.AreEqual(expectedName, actualName.UserName);
        }

        [TestMethod]
        [DataRow("Erik", "@Alice hej vad gör du", "Alice"), DataRow("Tim", "@Erik varför stavas du med k?", "Erik")]
        public void TestTaggedUserInCreatePost(string userName, string post, string timelineUserName)
        {
            //Arrange
            var expectedUser = engine.GetUser(timelineUserName);


            //Act
            engine.CreatePost(userName, post);
            var listOfPosts = engine.TimeLine(timelineUserName);

            //Assert
            Assert.AreEqual(listOfPosts.FirstOrDefault().Body, post);
        }
    }
}
