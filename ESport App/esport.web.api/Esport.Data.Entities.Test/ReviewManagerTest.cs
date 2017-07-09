using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Repository.Stub.Test;
using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{

    [TestClass]
    
    public class ReviewManagerTest
    {
        IReviewManager reviewManager;
        ReviewRequest request;
        IReviewRepository reviewRepository;
        IProductRepository productRepository;
        IUserRepository userRepository;
        string PRODUCT_ID = "123";
        string PRODUCT_DESC = "IPad";
        double PRODUCT_PRICE = 23.50;
        string PRODUCT_FACTORY = "Apple";
        string DESCRIPTION = "Excelente";
        string PRODUCT_NAME = "Tablet";
        int POINTS = 5;
        string USER_ID = "admin";
        string USER_NAME = "Administrador";
        string USER_LAST_NAME = "Sistema";
        string USER_PASSWORD = "pass";
        string USER_ADDRESS = "Cuareim";
        string USER_MAIL = "admin@esport.com.uy";
        string USER_PHONE = "09912346";


        public ReviewManagerTest()
        {
            reviewRepository = new StubReviewRepository();
            productRepository = new StubProductRepository();
            userRepository = new StubUserRepository();
            reviewManager = new ReviewManager(reviewRepository, userRepository, productRepository);
            request = new ReviewRequest();
            request.ProductId = PRODUCT_ID;
            request.Description = DESCRIPTION;
            request.Points = POINTS;
            request.UserId = USER_ID;
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
        public void TestAddReview()
        {
            userRepository.AddEntity(BuildUser());
            productRepository.AddEntity(BuildProduct());
            reviewManager.AddReview(request);
        }

        [TestMethod]
        public void TestGetAllReviewByProduct()
        {
            Product productForReview = BuildProduct();
            userRepository.AddEntity(BuildUser());
            productRepository.AddEntity(productForReview);
            reviewManager.AddReview(request);
            Assert.AreNotEqual(reviewManager.GetReviewsByProduct(productForReview.ProductId).Count, ESportUtils.EMPTY_LIST);
        }

        [TestMethod]
        public void TestGetAllReviewByUser()
        {
            User userForReview = BuildUser();
            userRepository.AddEntity(userForReview);
            productRepository.AddEntity(BuildProduct());
            reviewManager.AddReview(request);
            Assert.AreNotEqual(reviewManager.GetReviewsByUser(userForReview).Count, ESportUtils.EMPTY_LIST);
        }

        [TestMethod]
        public void TestProductRate()
        {
            userRepository.AddEntity(BuildUser());
            productRepository.AddEntity(BuildProduct());
            Product productUpdated = productRepository.GetProductById(PRODUCT_ID);
            reviewManager.AddReview(request);
            Assert.AreEqual(productUpdated.ReviewAverage, POINTS);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddReviewUserNotExist()
        {
            productRepository.AddEntity(BuildProduct());
            reviewManager.AddReview(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddReviewProductNotExist()
        {
            userRepository.AddEntity(BuildUser());
            reviewManager.AddReview(request);
        }

        private Product BuildProduct()
        {
            return new Product(PRODUCT_ID,PRODUCT_NAME, PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
        }

        private User BuildUser()
        {
            return new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
        }
    }
}
