using ESport.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class ProductTest
    {
        public ProductTest()
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
        public void TestProductId()
        {
            string PRODUCT_ID = "123";
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            Assert.AreEqual(PRODUCT_ID, product.ProductId);
        }

        [TestMethod]
        public void TestProductDescription()
        {
            string PRODUCT_DESC = "IPad";
            Product product = new Product();
            product.Description = PRODUCT_DESC;
            Assert.AreEqual(PRODUCT_DESC, product.Description);
        }

        [TestMethod]
        public void TestProductPrice()
        {
            double PRODUCT_PRICE= 23.50;
            Product product = new Product();
            product.Price = PRODUCT_PRICE;
            Assert.AreEqual(PRODUCT_PRICE, product.Price);
        }

        [TestMethod]
        public void TestProductFactory()
        {
            string PRODUCT_FACTORY = "Apple";
            Product product = new Product();
            product.Factory = PRODUCT_FACTORY;
            Assert.AreEqual(PRODUCT_FACTORY, product.Factory);
        }


        [TestMethod]
        public void TestProductImagePath()
        {
            Product product = new Product();
            Assert.IsFalse(product.HasImages());
        }

        [TestMethod]
        public void TestProductReviewAverage()
        {
            double AVERAGE = 2.5;
            Product product = new Product();
            product.ReviewAverage = AVERAGE;
            Assert.AreEqual(product.ReviewAverage, AVERAGE);
        }

        [TestMethod]
        public void TestProductConstructorWithParamsOne()
        {
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            Assert.AreEqual(PRODUCT_ID, product.ProductId);
        }

        [TestMethod]
        public void TestProductConstructorWithParamsTwo()
        {
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            Assert.AreEqual(PRODUCT_DESC, product.Description);
        }

        [TestMethod]
        public void TestProductConstructorWithParamsThree()
        {
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID,PRODUCT_NAME, PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            Assert.AreEqual(PRODUCT_PRICE, product.Price);
        }

        [TestMethod]
        public void TestProductConstructorWithParamsFour()
        {
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            Assert.AreEqual(PRODUCT_FACTORY, product.Factory);
        }

        [TestMethod]
        public void TestProductConstructorWithParamsFive()
        {
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID,PRODUCT_NAME, PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            Assert.IsFalse(product.HasImages());
        }

        [TestMethod]
        public void TestProductConstructorWithParamsSix()
        {
            string PRODUCT_ID = "123";
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            product.Eliminated = true;
            Assert.IsTrue(product.Eliminated);
        }


        [TestMethod]
        public void TestField()
        {
            Product product = new Product();
            Assert.IsNotNull(product.Fields);
        }

    }
}
