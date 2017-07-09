using ESport.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class UserTest
    {
        public UserTest()
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

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestId()
        {
            string USER_ID = "admin";
            User user = new User();
            user.UserId = USER_ID;
            Assert.AreEqual(user.UserId, USER_ID);
        }

        [TestMethod]
        public void TestUserName()
        {
            string USER_NAME = "Administrador";
            User user = new User();
            user.UserName = USER_NAME;
            Assert.AreEqual(user.UserName, USER_NAME);
        }

        [TestMethod]
        public void TestUserLastName()
        {
            string USER_LAST_NAME = "Sistema";
            User user = new User();
            user.UserLastName = USER_LAST_NAME;
            Assert.AreEqual(user.UserLastName, USER_LAST_NAME);
        }

        [TestMethod]
        public void TestUserPassword()
        {
            string USER_PASSWORD = "pass";
            User user = new User();
            user.Password = USER_PASSWORD;
            Assert.AreEqual(user.Password, USER_PASSWORD);
        }

        [TestMethod]
        public void TestUserAddress()
        {
            string USER_ADDRESS= "Cuareim";
            User user = new User();
            user.Address = USER_ADDRESS;
            Assert.AreEqual(user.Address, USER_ADDRESS);
        }

        [TestMethod]
        public void TestUserMail()
        {
            string USER_MAIL = "admin@esport.com.uy";
            User user = new User();
            user.EMail = USER_MAIL;
            Assert.AreEqual(user.EMail, USER_MAIL);
        }

        [TestMethod]
        public void TestUserEliminated()
        {
            User user = new User();
            Assert.IsFalse(user.Eliminated);
        }

        [TestMethod]
        public void TestUserRoles()
        {
            User user = new User();
            Assert.IsFalse(user.HasRole());
        }

        [TestMethod]
        public void TestUserConstructorWithArgumentsOne()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.AreEqual(user.UserId, USER_ID);
        }

        [TestMethod]
        public void TestUserConstructorWithArgumentsTwo()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.AreEqual(user.UserName, USER_NAME);
        }

        [TestMethod]
        public void TestUserConstructorWithArgumentsThree()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.AreEqual(user.UserLastName, USER_LAST_NAME);
        }

        [TestMethod]
        public void TestUserConstructorWithArgumentsFour()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.AreEqual(user.Password, USER_PASSWORD);
        }

        [TestMethod]
        public void TestUserConstructorWithArgumentsFive()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.AreEqual(user.Address, USER_ADDRESS);
        }
        [TestMethod]
        public void TestUserConstructorWithArgumentsSix()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.AreEqual(user.EMail, USER_MAIL);
        }

        [TestMethod]
        public void TestUserConstructorWithArgumentsSeven()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.IsFalse(user.Eliminated);
        }

        [TestMethod]
        public void TestUserConstructorWithArgumentsEight()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            Assert.IsFalse(user.HasRole());
        }

        [TestMethod]
        public void TestUserSetEliminated()
        {
            User user = new User();
            user.Eliminated = true;
            Assert.IsTrue(user.Eliminated);
        }



    }
}
