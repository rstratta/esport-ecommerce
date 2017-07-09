using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{

    [TestClass]
    
    public class CartItemTest
    {
        private Product productTest;
        public CartItemTest()
        {
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            productTest = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
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
        public void TestCartItemProduct()
        {
            CartItem item = new CartItem();
            item.Product = productTest;
            Assert.AreEqual(item.Product, productTest);
        }

   
        [TestMethod]
        public void TestCartItemQuantity()
        {
            int ITEM_QUANTITY = 2;
            CartItem item = new CartItem();
            item.Quantity = ITEM_QUANTITY;
            Assert.AreEqual(item.Quantity, ITEM_QUANTITY);
        }

        [TestMethod]
        public void TestCartItemAmount()
        {
            CartItem item = new CartItem();
            Assert.AreEqual(item.Amount, ESportUtils.ZERO);
        }

        [TestMethod]
        public void TestCartItemPendingReview()
        {
            CartItem item = new CartItem();
            Assert.IsTrue(item.PendingReview);
        }

        [TestMethod]
        public void TestCartItemConstructorWithArgs()
        {
            int ITEM_QUANTITY = 2;
            CartItem item = new CartItem(productTest, ITEM_QUANTITY);
            Assert.AreEqual(item.UnitPrice, productTest.Price);
        }
        [TestMethod]
        public void TestCartItemConstructorWithArgsTwo()
        {
            int ITEM_QUANTITY = 2;
            double EXPECTED_VALUE = productTest.Price * ITEM_QUANTITY;
            CartItem item = new CartItem(productTest, ITEM_QUANTITY);
            Assert.AreEqual(item.Amount, EXPECTED_VALUE);
        }

        [TestMethod]
        public void TestCartItemConstructorWithArgsThree()
        {
            int ITEM_QUANTITY = 2;
            CartItem item = new CartItem(productTest, ITEM_QUANTITY);
            Assert.AreEqual(item.Quantity, ITEM_QUANTITY);
        }

        [TestMethod]
        public void TestCartItemConstructorWithArgsFour()
        {
            int ITEM_QUANTITY = 2;
            CartItem item = new CartItem(productTest, ITEM_QUANTITY);
            Assert.IsTrue(item.PendingReview);
        }
    }
}
