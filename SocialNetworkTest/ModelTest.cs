using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkTest
{
    [TestClass]
    public class EngineTest
    {
        public const string testMessage = "test message";

        [TestMethod]
        [DataRow("Drugi")]
        public void TestUserWithAttributes(string userName)
        {
            //Arrange
            User user = new User(userName);


            //Act
            user.Messages.Add(new Message(userName, testMessage));
            user.MySubscriptions.Add(new User("Greta"));
            user.Posts.Add(new Post(userName, testMessage));


            //Assert
            Assert.IsNotNull(user.Messages);
            Assert.AreEqual(1, user.Messages.Count);
            Assert.AreEqual(1, user.Posts.Count);
            Assert.AreEqual(1, user.MySubscriptions.Count);
        }


    }
}