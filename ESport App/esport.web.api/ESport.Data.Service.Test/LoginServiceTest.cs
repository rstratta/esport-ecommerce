using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Repository.Stub.Test;
using ESport.Data.Entities;
using ESport.Logger.Manager;

namespace ESport.Data.Service.Test
{

    [TestClass]
    
    public class LoginServiceTest
    {
        string USER_ID = "userId";
        string USER_PASSWORD = "C45%d.a";
        string ROLE_ID = "admin";
        string PRODUCT_ID = "1";
        string USER_NAME = "Juan";
        string USER_LASTNAME = "Perez";
        ICartManager cartManager;
        ILoginService loginService;
        public LoginServiceTest()
        {
            IUserRepository userRepository = new StubUserRepository();
            IRoleRepository roleRepository = GetRoleRepository();
            UserRequest request = GetUserRequest();
            IUserManager userManager = new UserManager(userRepository, roleRepository);
            userManager.AddUser(request);
            ICartRepository cartRepository = new StubCartRepository();
            IPointSystemConfigurationRepository configurationRepository = new StubPointSystemConfigurationRepository();
            ILoggerManager loggerManager = new LoggerManager(new StubLoggerRepository());
            configurationRepository.AddEntity(new PointSystemConfiguration() { PropertyName = ESportUtils.LOYALTY_PROPERTY_NAME, PropertyValue = 100 });
            cartManager = new CartManager(cartRepository, new StubCartItemRepository(), GetProductRepository(), userRepository, configurationRepository);
            loginService = new LoginService(userManager, cartManager, new PendingReviewDTOBuilder(), new SimpleCartDTOBuilder(new SimpleCartItemDTOBuilder()), new UserDTOBuilder(),loggerManager);
        }

        private IProductRepository GetProductRepository()
        {
            IProductRepository productRepository = new StubProductRepository();
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            product.AvailableStock = 100;
            productRepository.AddEntity(product);
            return productRepository;
        }
        private IRoleRepository GetRoleRepository()
        {
            IRoleRepository roleRepository = new StubRoleRepository();
            string ROLE_DESCRIPTION = "Administrador de Sistema";
            Role role = new Role(ROLE_ID, ROLE_DESCRIPTION);
            roleRepository.AddEntity(role);
            return roleRepository;
        }

        private UserRequest GetUserRequest()
        {
            UserRequest request=new UserRequest();
            
            string USER_LASTNAME = "Perez";
            string USER_ADDRESS = "Ejido 1928";
            string USER_EMAIL = "juanperez@gmail.com";
            request.UserId = USER_ID;
            request.Address = USER_ADDRESS;
            request.UserLastName = USER_LASTNAME;
            request.UserName = USER_NAME;
            request.EMail = USER_EMAIL;
            request.Password = USER_PASSWORD;
            request.RoleId = ROLE_ID;
            return request;
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
        public void TestLogin()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            loginService.LoginUser(request);
        }

        [TestMethod]
        public void TestLoginToken()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response=loginService.LoginUser(request);
            Assert.IsNotNull(response.Token);
        }

        [TestMethod]
        public void TestLoginTokenTwo()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            string fisrtToken = response.Token;
            response= loginService.LoginUser(request);
            Assert.AreEqual(fisrtToken, response.Token);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestLogout()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            string token = response.Token;
            loginService.Logout(token);
            UserContextDTO context = LoginContext.GetInstance().GetUserContextByToken(token);
            if (context == null)
            {
                throw new BadRequestException("Debe estar logueado para esta operación");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestLogoutException()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            string token = response.Token;
            loginService.Logout(token);
            loginService.Logout(token);
        }

        [TestMethod]
        public void TestLoginTokenThree()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            UserContextDTO contextInMemory = LoginContext.GetInstance().GetUserContextByToken(response.Token);
            UserDTO userInContext = contextInMemory.UserDTO;
            Assert.AreEqual(USER_ID,userInContext.UserId);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestLoginUserNotExist()
        {
            string USER_NOT_EXIST = "notExist";
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_NOT_EXIST;
            request.UserPassword = USER_PASSWORD;
            loginService.LoginUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestLoginPasswordError()
        {
            string ERROR_PASSWORD = "error";
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = ERROR_PASSWORD;
            loginService.LoginUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestLoginBadRequestUserId()
        {
            USER_ID = " ";
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            loginService.LoginUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestLoginBadRequestUserPassword()
        {
            USER_PASSWORD = " ";
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            loginService.LoginUser(request);
        }

        [TestMethod]
        public void TestLoginResponseUserName()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response=loginService.LoginUser(request);
            Assert.AreEqual(USER_NAME, response.UserDTO.UserName);
        }

        [TestMethod]
        public void TestLoginResponseUserLastName()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            Assert.AreEqual(USER_LASTNAME, response.UserDTO.UserLastName);
        }

        [TestMethod]
        public void TestLoginResponsePendingReviews()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            Assert.AreEqual(ESportUtils.EMPTY_LIST, response.PendingsReviewDTO.Count);
        }

        [TestMethod]
        public void TestLoginResponsePendingCart()
        {
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            Assert.IsNull(response.PendingCart);
        }

        [TestMethod]
        public void TestLoginResponsePendingCartNotNull()
        {
            int QUANTITY = 2;
            CartRequest productRequest  = new CartRequest();
            productRequest.UserId = USER_ID;
            productRequest.ProductId = PRODUCT_ID;
            productRequest.Quantity = QUANTITY;
            cartManager.AddProduct(productRequest);
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            Assert.IsNotNull(response.PendingCart);
        }

        [TestMethod]
        public void TestLoginResponseWithPendingReviews()
        {
            int QUANTITY = 2;
            CartRequest cartRequest = new CartRequest();
            cartRequest.UserId = USER_ID;
            cartRequest.ProductId = PRODUCT_ID;
            cartRequest.Quantity = QUANTITY;
            cartManager.AddProduct(cartRequest);
            cartManager.ConfirmCart(cartRequest);
            LoginUserRequest request = new LoginUserRequest();
            request.UserId = USER_ID;
            request.UserPassword = USER_PASSWORD;
            UserContextDTO response = loginService.LoginUser(request);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, response.PendingsReviewDTO.Count);
        }
    }
}
