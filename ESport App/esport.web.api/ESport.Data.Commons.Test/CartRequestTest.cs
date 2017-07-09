using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESport.Data.Commons.Test
{
    /// <summary>
    /// Descripción resumida de CartRequestTest
    /// </summary>
    [TestClass]
    public class CartRequestTest
    {
        public CartRequestTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
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
        public void TestMethodCartRequestUserId()
        {
            string USER_ID = "admin";
            CartRequest request = new CartRequest();
            request.UserId = USER_ID;
            Assert.AreEqual(request.UserId, USER_ID);
        }

        [TestMethod]
        public void TestMethodCartRequestProductId()
        {
            string PRODUCT_ID = "1";
            CartRequest request = new CartRequest();
            request.ProductId = PRODUCT_ID;
            Assert.AreEqual(request.ProductId, PRODUCT_ID);
        }

        [TestMethod]
        public void TestMethodCartRequestQuantity()
        {
            int QUANTITY = 1;
            CartRequest request = new CartRequest();
            request.Quantity = QUANTITY;
            Assert.AreEqual(request.Quantity, QUANTITY);
        }

        [TestMethod]
        public void TestMethodCartRequestDeliveryAddress()
        {
            string ADDRESS = "test";
            CartRequest request = new CartRequest();
            request.DeliveryAddress = ADDRESS;
            Assert.AreEqual(request.DeliveryAddress, ADDRESS);
        }
    }
}
