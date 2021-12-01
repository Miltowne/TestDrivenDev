using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Engine;

namespace TddInluppTest
{
    [TestClass]
    public class UnitTest1
    {
        public SocialNetworkEngine engine { get; set; }

        [TestInitialize]
        public void TestInitializer()
        {
            engine = new SocialNetworkEngine();
            engine.CreateUser("Alice");
            engine.CreateUser("Bob");
            engine.CreateUser("Charlie");
            engine.CreateUser("Mallory ");
            engine.CreateUser("Erik");
            engine.CreateUser("Patrik");
            engine.CreateUser("Cuba");
            engine.CreateUser("Elis");
            engine.CreateUser("Martin");
        }


        [TestMethod]
        [DataRow("Pia", "Ludde", "Vad gör du?")]
        public void TestViewMessages(string sender, string receiver, string message)
        {
            //Arrange
            var user = engine.GetUser(receiver);
            string[] userInput = new string[] { sender, "/send_message", receiver, message };

            //Act
            engine.SendMessage(sender, receiver, message);

            //Assert
            Assert.AreEqual(message, user.Messages[1]);
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
