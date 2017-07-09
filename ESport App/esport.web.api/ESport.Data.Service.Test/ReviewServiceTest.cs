using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ESport.Data.Commons;
using ESport.Repository.Stub.Test;
using System.Linq;
using ESport.Data.Entities;

namespace ESport.Data.Service.Test
{

    [TestClass]
    
    public class ReviewServiceTest
    {
        string USER_ID = "client";
        string PRODUCT_ID = "1";
        IReviewService reviewService;
        ReviewRequest request;
        CartItem itemTest;

        public ReviewServiceTest()
        {
            IReviewRepository reviewRepository = new StubReviewRepository();
            IProductRepository productRepository = GetProductRepository();
            IUserRepository userRepository = GetUserOnRepository();
            IReviewManager reviewManager = new ReviewManager(reviewRepository, userRepository, productRepository);
            ICartManager cartManager = GetCartManager(productRepository, userRepository);
            reviewService = new ReviewServiceImpl(reviewManager, cartManager, new ReviewDTOBuilder());
            request = GetReviewRequest(cartManager);
        }

        private ReviewRequest GetReviewRequest(ICartManager cartmanager)
        {
            
            ReviewRequest request=new ReviewRequest();
            request.UserId = USER_ID;
            request.ProductId = PRODUCT_ID;
            request.CartItemId = itemTest.CartItemId.ToString();
            request.Description = "Test";
            request.Points = 3;
            return request;
        }

        private ICartManager GetCartManager(IProductRepository productRepository, IUserRepository userRepository)
        {
            ICartRepository cartRepository = new StubCartRepository();
            ICartItemRepository cartItemRepository = new StubCartItemRepository();
            IPointSystemConfigurationRepository configurationRepository = new StubPointSystemConfigurationRepository();
            configurationRepository.AddEntity(new PointSystemConfiguration() { PropertyName = ESportUtils.LOYALTY_PROPERTY_NAME, PropertyValue = 100 });
            ICartManager cartManager=new CartManager(cartRepository,cartItemRepository, productRepository, userRepository, configurationRepository);
            CartRequest cartRequest = GetCartRequest();
            Cart currentCart=cartManager.AddProduct(cartRequest);
            itemTest = currentCart.Items.Where(item => item.Product.ProductId.Equals(cartRequest.ProductId)).First();
            cartManager.ConfirmCart(cartRequest);
            return cartManager;
        }

        private CartRequest GetCartRequest()
        {
            CartRequest cartRequest = new CartRequest();
            cartRequest.UserId = USER_ID;
            cartRequest.ProductId = PRODUCT_ID;
            cartRequest.Quantity = 1;
            return cartRequest;
        }

        private IProductRepository GetProductRepository()
        {
            IProductRepository productRepository = new StubProductRepository();
            string PRODUCT_DESC = "IPad";
            string PRODUCT_FACTORY = "Apple";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            product.AvailableStock = 100;
            productRepository.AddEntity(product);
            return productRepository;
        }

        private IUserRepository GetUserOnRepository()
        {
            IUserRepository userRepository = new StubUserRepository();
            string USER_ADDRESS = "Cuareim";
            string USER_PHONE = "099654321";
            string USER_NAME = "Cliente";
            string USER_LAST_NAME = "Compra";
            string USER_PASSWORD = "pass";
            string USER_MAIL = "client@esport.com.uy";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            userRepository.AddEntity(user);
            return userRepository;
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
            reviewService.AddReview(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddReviewProductIdException()
        {
            request.ProductId = "";
            reviewService.AddReview(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddReviewUserIdException()
        {
            request.UserId = "";
            reviewService.AddReview(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddReviewCartItemIdException()
        {
            request.CartItemId = "";
            reviewService.AddReview(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddReviewPointsException()
        {
            request.Points = 0;
            reviewService.AddReview(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddReviewDescriptionException()
        {
            request.Description = "";
            reviewService.AddReview(request);
        }

        [TestMethod]
        public void TestGetReviewByProductId()
        {
            reviewService.AddReview(request);
            List<ReviewDTO> reviewsDTO = reviewService.GetReviewsByProductId(request.ProductId);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, reviewsDTO.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestGetReviewByProductIdException()
        {
            request.ProductId = "";
            List<ReviewDTO> reviewsDTO = reviewService.GetReviewsByProductId(request.ProductId);
        }
    }
}
