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
            var listOfMessages = engine.ViewMessages(receiver);

            //Assert
            Assert.AreEqual(message, receiverUser.Messages.FirstOrDefault().Body);
            Assert.IsNotNull(listOfMessages);
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
        [DataRow("Erik", "@Alice hej vad gör du", "Alice", "Erik tagged you in a post: @Alice hej vad gör du"), DataRow("Tim", "@Erik varför stavas du med k?", "Erik", "Tim tagged you in a post: @Erik varför stavas du med k?")]
        public void TestTaggedUserInCreatePost(string userName, string post, string taggedUser, string expectedPost)
        {
            //Arrange

            //Act
            engine.CreatePost(userName, post);
            var listOfPosts = engine.TimeLine(taggedUser);

            //Assert
            Assert.AreEqual(listOfPosts.FirstOrDefault().Body, expectedPost);
        }
    }
}
