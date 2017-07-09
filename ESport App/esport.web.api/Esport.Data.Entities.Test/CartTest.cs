using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class CartTest
    {
        public User userTest;
        public Product productTest;
        public DateTime cartDate;
        public CartTest()
        {
            string USER_ID = "admin";
            string USER_NAME = "Administrador";
            string USER_LAST_NAME = "Sistema";
            string USER_PASSWORD = "pass";
            string USER_ADDRESS = "Cuareim";
            string USER_MAIL = "admin@esport.com.uy";
            string USER_PHONE = "09912346";
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            productTest = new Product(PRODUCT_ID,PRODUCT_NAME, PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            userTest = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL,USER_PHONE);
            cartDate = new DateTime();
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
        public void TestCartOpendate()
        {
            Cart cart = new Cart();
            cart.Opendate = cartDate;
            Assert.AreEqual(cartDate, cart.Opendate);
        }

        [TestMethod]
        public void TestCartUser()
        {
            Cart cart = new Cart();
            cart.User = userTest;
            Assert.AreEqual(userTest, cart.User);
        }

        [TestMethod]
        public void TestCartState()
        {
            Cart cart = new Cart();
            Assert.AreEqual(Cart.INIT_CART, cart.State);
        }

        [TestMethod]
        public void TestCartTotal()
        {
            Cart cart = new Cart();
            cart.Total = ESportUtils.ZERO;
            Assert.AreEqual(ESportUtils.ZERO, cart.Total);
        }

        [TestMethod]
        public void TestCartDeliveryAddress()
        {
            string ADDRESS = "test";
            Cart cart = new Cart();
            cart.DeliveryAddress = ADDRESS;
            Assert.AreEqual(ADDRESS, cart.DeliveryAddress);
        }

        [TestMethod]
        public void TestCartProducts()
        {
            Cart cart = new Cart();
            Assert.IsFalse(cart.HasProducts());
        }


    }
}
