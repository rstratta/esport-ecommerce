using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Repository.Stub.Test;
using ESport.Data.Entities;

namespace ESport.Data.Service.Test
{

    [TestClass]
    
    public class CartServiceTest
    {
        ICartService cartService;
        string USER_ID = "client";
        double PRODUCT_PRICE = 23.50;
        string PRODUCT_ID = "1";
        CartRequest request;
        public CartServiceTest()
        {
            ICartRepository cartRepository = new StubCartRepository();
            IProductRepository productRepository = new StubProductRepository();
            IUserRepository userRepository = new StubUserRepository();
            request = new CartRequest();
            request.UserId = USER_ID;
            request.ProductId = PRODUCT_ID;
            request.Quantity = 1;
            AddUserOnRepository(userRepository);
            AddProductOnRepository(productRepository);
            IPointSystemConfigurationRepository configurationRepository = new StubPointSystemConfigurationRepository();
            configurationRepository.AddEntity(new PointSystemConfiguration() { PropertyName = ESportUtils.LOYALTY_PROPERTY_NAME, PropertyValue = 100 });
            ICartManager cartManager = new CartManager(cartRepository,new StubCartItemRepository(),  productRepository, userRepository, configurationRepository);
            cartService = new CartServiceImpl(cartManager, new SimpleCartDTOBuilder(), new PendingReviewDTOBuilder());
        }

        private void AddProductOnRepository(IProductRepository productRepository)
        {
            string PRODUCT_DESC = "IPad";
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product= new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            product.AvailableStock = 100;
            productRepository.AddEntity(product);
        }

        private void AddUserOnRepository(IUserRepository userRepository)
        {
            string USER_ADDRESS = "Cuareim";
            string USER_PHONE = "099654321";
            string USER_NAME = "Cliente";
            string USER_LAST_NAME = "Compra";
            string USER_PASSWORD = "pass";
            string USER_MAIL = "client@esport.com.uy";
            User user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            userRepository.AddEntity(user);
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
        public void TestAddProductOnCart()
        {
            CartDTO cartDTO = cartService.AddProduct(request);
            Assert.AreEqual(cartDTO.Total, PRODUCT_PRICE);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddProductOnCartUserIdException()
        {
            request.UserId = " ";
            cartService.AddProduct(request);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddProductOnCartProductIdException()
        {
            request.ProductId = " ";
            cartService.AddProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddProductOnCartQuantityException()
        {
            request.Quantity = 0;
            cartService.AddProduct(request);
        }

        [TestMethod]
        public void TestRemoveProductOnCart()
        {
            cartService.AddProduct(request);
            CartDTO cartDTO = cartService.RemoveProduct(request);
            Assert.AreEqual(cartDTO.Total, ESportUtils.ZERO);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveProductOnCartUserIdException()
        {
            request.UserId = " ";
            cartService.RemoveProduct(request);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveProductOnCartProductIdException()
        {
            request.ProductId = " ";
            cartService.RemoveProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveProductOnCartQuantityException()
        {
            request.Quantity = 0;
            cartService.RemoveProduct(request);
        }

        [TestMethod]
        public void TestConfirmCart()
        {
            cartService.AddProduct(request);
            cartService.ConfirmCart(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestConfirmCartUserIdException()
        {
            request.UserId = " ";
            cartService.ConfirmCart(request);
        }

        [TestMethod]
        public void TestCancelCart()
        {
            cartService.AddProduct(request);
            cartService.CancelCart(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestCancelCartUserIdException()
        {
            request.UserId = " ";
            cartService.CancelCart(request);
        }

        [TestMethod]
        public void TestAllCartsByUser()
        {
            cartService.AddProduct(request);
            cartService.ConfirmCart(request);
            List<CartDTO> result=cartService.GetAllCartsByUser(request);
            Assert.AreNotEqual(ESportUtils.ZERO, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAllCartsByUserUserIdException()
        {
            request.UserId = " ";
            cartService.GetAllCartsByUser(request);
        }

    }
}
