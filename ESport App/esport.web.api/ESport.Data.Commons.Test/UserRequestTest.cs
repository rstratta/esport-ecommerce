using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESport.Data.Commons.Test
{

    [TestClass]
    public class UserRequestTest
    {
        public UserRequestTest()
        {
          
        }

        private TestContext testContextInstance;

       
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

       
        [TestMethod]
        public void TestUserRequestUserId()
        {
            string USER_ID = "123";
            UserRequest request = new UserRequest();
            request.UserId = USER_ID;
            Assert.AreEqual(USER_ID, request.UserId);
        }

        [TestMethod]
        public void TestUserRequestUserRole()
        {
            string ROLE_ID = "admin";
            UserRequest request = new UserRequest();
            request.RoleId = ROLE_ID;
            Assert.AreEqual(ROLE_ID, request.RoleId);
        }

        [TestMethod]
        public void TestUserRequestUserAddress()
        {
            string USER_ADDRESS = "ejido 1928";
            UserRequest request = new UserRequest();
            request.Address = USER_ADDRESS;
            Assert.AreEqual(USER_ADDRESS, request.Address);
        }

        [TestMethod]
        public void TestUserRequestUserEliminated()
        {
            bool USER_ELIMINATED = false;
            UserRequest request = new UserRequest();
            request.Eliminated = USER_ELIMINATED;
            Assert.AreEqual(USER_ELIMINATED, request.Eliminated);
        }

        [TestMethod]
        public void TestUserRequestUserEMail()
        {
            string USER_EMAIL = "juanperez@gmail.com";
            UserRequest request = new UserRequest();
            request.EMail = USER_EMAIL;
            Assert.AreEqual(USER_EMAIL, request.EMail);
        }

        [TestMethod]
        public void TestUserRequestUserPassword()
        {
            string USER_PASSWORD = "C45&d.a";
            UserRequest request = new UserRequest();
            request.Password = USER_PASSWORD;
            Assert.AreEqual(USER_PASSWORD, request.Password);
        }

        [TestMethod]
        public void TestUserRequestUserLastName()
        {
            string USER_LASTNAME = "Perez";
            UserRequest request = new UserRequest();
            request.UserLastName = USER_LASTNAME;
            Assert.AreEqual(USER_LASTNAME, request.UserLastName);
        }

        [TestMethod]
        public void TestUserRequestUserName()
        {
            string USER_NAME = "Juan";
            UserRequest request = new UserRequest();
            request.UserName = USER_NAME;
            Assert.AreEqual(USER_NAME, request.UserName);
        }

    }
}
