using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkTest
{
    [TestClass]
    public class EngineUserTest
    {
        public SocialNetworkEngine engine { get; set; }

        [TestInitialize]
        public void TestInitializer()
        {
            engine = new SocialNetworkEngine();
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
            Assert.AreEqual(engine.Users.FirstOrDefault().UserName, user.UserName);
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