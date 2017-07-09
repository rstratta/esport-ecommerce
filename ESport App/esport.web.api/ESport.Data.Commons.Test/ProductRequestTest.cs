using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESport.Data.Commons.Test
{

    [TestClass]
    public class ProductRequestTest
    {
        public ProductRequestTest()
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
        public void TestProductRequestProductId()
        {
            string PRODUCT_ID = "1";
            ProductRequest request = new ProductRequest();
            request.ProductId = PRODUCT_ID;
            Assert.AreEqual(PRODUCT_ID, request.ProductId);
        }

        [TestMethod]
        public void TestProductRequestProductDescription()
        {
            string PRODUCT_DESC = "IPad";
            ProductRequest request = new ProductRequest();
            request.Description = PRODUCT_DESC;
            Assert.AreEqual(PRODUCT_DESC, request.Description);
        }

        [TestMethod]
        public void TestProductPrice()
        {
            double PRODUCT_PRICE = 23.50;
            ProductRequest request = new ProductRequest();
            request.Price = PRODUCT_PRICE;
            Assert.AreEqual(PRODUCT_PRICE, request.Price);
        }

        [TestMethod]
        public void TestProductFactory()
        {
            string PRODUCT_FACTORY = "Apple";
            ProductRequest request = new ProductRequest();
            request.Factory = PRODUCT_FACTORY;
            Assert.AreEqual(PRODUCT_FACTORY, request.Factory);
        }


        [TestMethod]
        public void TestProductImagePath()
        {
            ProductRequest request = new ProductRequest();
            Assert.AreEqual(ESportUtils.EMPTY_LIST, request.Images.Count);
        }



    }
}
