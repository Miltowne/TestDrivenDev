using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

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

<<<<<<< HEAD
        [TestMethod]
        [DataRow("Pia")]
        public void TestUserExist(string user)
        {
            //Arrange
            int e = 1;


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
            var name1 = engine.GetUser(name);
            var name2 = engine.GetUser(followedUser);

            var posten = new Post(followedUser, post);

            name1.Posts.Add(posten);
            name2.Posts.Add(posten);


            //Act
            engine.Follow(name, followedUser);
            var list = engine.Wall(name);


            //Assert
            Assert.AreEqual(list[0], posten);
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
            Assert.AreEqual(list[0].Body, post);
        }


=======
       
>>>>>>> 07678ad4b28d368f9745e9d0454c6901b91e0c31

        [TestMethod]
        [DataRow("Pia", "Ludde", "Vad gï¿½r du?")]
        public void TestViewMessages(string sender, string receiver, string message)
        {
            //Arrange
            var receiverUser = engine.GetUser(receiver);

            //Act
            engine.SendMessage(sender, receiver, message);

            //Assert
            Assert.AreEqual(message, receiverUser.Messages[0].Body);
        }


        [TestMethod]
        [DataRow("Erik", "Sara"), DataRow("Elis", "Patrik"), DataRow("Martin", "Cuba")]
        public void TestFollowers(string follower, string followed)
        {
            //Arrange
            var user = engine.GetUser(followed);
            string[] userInput = new string[] { follower, "/follow", followed };
            engine.Follow(follower, followed);
            List<string> listOfFollowers = new List<string>();

            //Act
            listOfFollowers.Add(follower);

            //Assert
            //Assert.AreEqual(user.[0], listOfFollowers[0]);
        }

        [TestMethod]
        [DataRow("Erik", "/Post", "Hello")]
        public void TestExistsOnTimeline(string sender, string receiver, string post)
        {
            //Arrange
            var user = engine.GetUser("Erik");
            string[] userInput = new string[] { "Erik", "/CreatePost", "Hello" };

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
    }
}
