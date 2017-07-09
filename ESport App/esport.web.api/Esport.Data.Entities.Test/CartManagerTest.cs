using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Entities;
using ESport.Data.Commons;

using ESport.Repository.Stub.Test;

namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class CartManagerTest
    {
        CartRequest request;
        ICartManager cartManager;
        IUserRepository userRepository;
        ICartRepository cartRepository;
        ICartItemRepository cartItemRepository;
        IProductRepository productRepository;
        string USER_ID = "client";
        string PRODUCT_ID = "1";
        Product product;
        User user;
        string USER_ADDRESS = "Cuareim";
        string USER_PHONE = "099654321";
        public CartManagerTest()
        {
            request = new CartRequest();
            request.UserId = USER_ID;
            request.ProductId = PRODUCT_ID;
            userRepository = new StubUserRepository();
            productRepository = new StubProductRepository();
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 230.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            product.AvailableStock = 100;
            string USER_NAME = "Cliente";
            string USER_LAST_NAME = "Compra";
            string USER_PASSWORD = "pass";

            string USER_MAIL = "client@esport.com.uy";
            user = new User(USER_ID, USER_NAME, USER_LAST_NAME, USER_PASSWORD, USER_ADDRESS, USER_MAIL, USER_PHONE);
            userRepository.AddEntity(user);
            productRepository.AddEntity(product);
            cartRepository = new StubCartRepository();
            cartItemRepository = new StubCartItemRepository();
            IPointSystemConfigurationRepository configurationRepository = new StubPointSystemConfigurationRepository();
            configurationRepository.AddEntity(new PointSystemConfiguration() { PropertyName=ESportUtils.LOYALTY_PROPERTY_NAME, PropertyValue=100});
            cartManager = new CartManager(cartRepository, cartItemRepository, productRepository, userRepository,configurationRepository);
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
        public void TestInitializeCartAndAddProduct()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            Cart currentCart = cartRepository.GetCurrentCartByUser(user);
            Assert.AreEqual(product.Price, currentCart.Total);
        }

        [TestMethod]
        public void TestInitializeCartAndAddProductTwo()
        {
            int QUANTITY = 2;
            request.Quantity = QUANTITY;
            cartManager.AddProduct(request);
            Cart currentCart = cartRepository.GetCurrentCartByUser(user);
            Assert.AreEqual(product.Price * QUANTITY, currentCart.Total);
        }

        [TestMethod]
        public void TestTotalCart()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.CancelProduct(request);
            Cart currentCart = cartRepository.GetCurrentCartByUser(user);
            Assert.AreEqual(ESportUtils.ZERO, currentCart.Total);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddProductEliminated()
        {
            request.Quantity = 1;
            product.Eliminated = true;
            productRepository.UpdateEntity(product);
            cartManager.AddProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestCancelProductTwo()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.CancelProduct(request);
            cartManager.CancelProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestGetCartByUser()
        {
            cartManager.GetCurrentCartByUserId(request.UserId);
        }

        [TestMethod]
        public void TestGetCartByUserTwo()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            Cart currentCart = cartRepository.GetCurrentCartByUser(user);
            Assert.IsNotNull(currentCart);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestConfirmCart()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
            cartRepository.GetCurrentCartByUser(user);
        }

        [TestMethod]
        public void TestConfirmCartWithLoyalty()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
            Assert.AreNotEqual(ESportUtils.ZERO, user.Points);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestConfirmCartWithoutStock()
        {
            product.AvailableStock = 0;
            productRepository.UpdateEntity(product);
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestCancelCart()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.CancelCart(request);
            cartRepository.GetCurrentCartByUser(user);
        }

        [TestMethod]
        public void TestCartItemsPendingReview()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
            List<CartItem> items = cartManager.GetItemsPendingOfReview(USER_ID);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, items.Count);
        }

        [TestMethod]
        public void TestConfirmCartDeliveryAddress()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
            List<Cart> allCarts = cartManager.GetAllCartsByUser(USER_ID);
            Cart lastCart = allCarts[0];
            Assert.AreEqual(USER_ADDRESS, lastCart.DeliveryAddress);
        }

        [TestMethod]
        public void TestConfirmCartDeliveryAddressTwo()
        {
            request.Quantity = 1;
            string ADDRESS = "DeliveryAddress";
            request.DeliveryAddress = ADDRESS;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
            List<Cart> allCarts = cartManager.GetAllCartsByUser(USER_ID);
            Cart lastCart = allCarts[0];
            Assert.AreEqual(ADDRESS, lastCart.DeliveryAddress);
        }

        [TestMethod]
        public void TestConfirmCartDeliveryPhone()
        {
            request.Quantity = 1;
            string PHONE = "099123456";
            request.DeliveryPhone = PHONE;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
            List<Cart> allCarts = cartManager.GetAllCartsByUser(USER_ID);
            Cart lastCart = allCarts[0];
            Assert.AreEqual(PHONE, lastCart.DeliveryPhone);
        }

        [TestMethod]
        public void TestConfirmCartDeliveryPhoneTwo()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.ConfirmCart(request);
            List<Cart> allCarts = cartManager.GetAllCartsByUser(USER_ID);
            Cart lastCart = allCarts[0];
            Assert.AreEqual(USER_PHONE, lastCart.DeliveryPhone);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestConfirmCartWithTotalZero()
        {
            request.Quantity = 1;
            cartManager.AddProduct(request);
            cartManager.CancelProduct(request);
            cartManager.ConfirmCart(request);
        }
    }
}
