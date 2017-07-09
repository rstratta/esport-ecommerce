using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class ReviewTest
    {
        public User userTest;
        public Product productTest;
        


        public ReviewTest()
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
            productTest = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            userTest = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
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
        public void TestReviewUser()
        {
            Review review = new Review();
            review.User = userTest;
            Assert.AreEqual(review.User, userTest);
        }

        [TestMethod]
        public void TestReviewDate()
        {
            DateTime REVIEW_DATE =new DateTime();
            Review review = new Review();
            review.ReviewDate = REVIEW_DATE;
            Assert.AreEqual(review.ReviewDate, REVIEW_DATE);
        }

        [TestMethod]
        public void TestReviewDateNotNull()
        {
            Review review = new Review();
            Assert.IsNotNull(review.ReviewDate);
        }

        [TestMethod]
        public void TestReviewProduct()
        {
            Review review = new Review();
            review.Product = productTest;
            Assert.AreEqual(review.Product, productTest);
        }

        [TestMethod]
        public void TestReviewDescription()
        {
            Review review = new Review();
            string REVIEW_DESCRIPTION = "Excelente";
            review.Description = REVIEW_DESCRIPTION;
            Assert.AreEqual(review.Description, REVIEW_DESCRIPTION);
        }

        [TestMethod]
        public void TestReviewPoints()
        {
            Review review = new Review();
            int REVIEW_POINTS = 3;
            review.Points = REVIEW_POINTS;
            Assert.AreEqual(review.Points, REVIEW_POINTS);
        }

     

        [TestMethod]
        public void TestReviewConstructorWithArgsTwo()
        {
            string REVIEW_DESCRIPTION = "Excelente";
            int REVIEW_POINTS = 3;
            Review review = new Review(userTest, productTest, REVIEW_DESCRIPTION, REVIEW_POINTS);
            Assert.AreEqual(review.User, userTest);
        }

        [TestMethod]
        public void TestReviewConstructorWithArgsThree()
        {
            string REVIEW_DESCRIPTION = "Excelente";
            int REVIEW_POINTS = 3;
            Review review = new Review( userTest, productTest, REVIEW_DESCRIPTION, REVIEW_POINTS);
            Assert.AreEqual(review.Product, productTest);
        }

        [TestMethod]
        public void TestReviewConstructorWithFour()
        {
            string REVIEW_DESCRIPTION = "Excelente";
            int REVIEW_POINTS = 3;
            Review review = new Review( userTest, productTest, REVIEW_DESCRIPTION, REVIEW_POINTS);
            Assert.AreEqual(review.Description, REVIEW_DESCRIPTION);
        }

        [TestMethod]
        public void TestReviewConstructorWithArgsFive()
        {
            string REVIEW_DESCRIPTION = "Excelente";
            int REVIEW_POINTS = 3;
            Review review = new Review( userTest, productTest, REVIEW_DESCRIPTION, REVIEW_POINTS);
            Assert.AreEqual(review.Points, REVIEW_POINTS);
        }
    }
}
