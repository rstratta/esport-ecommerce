using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Service;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Controllers;
using System.Net.Http;
using ESport.Data.Commons;
using ESport.Web.Api.Controllers;

namespace ESport.Web.Api.Test
{
    [TestClass]
    public class CartControllerTest
    {
        CartRequest cartRequest;
        public CartControllerTest()
        {
            LoginContext.GetInstance().Reset();
            cartRequest = new CartRequest { ProductId = "1", UserId = "1" };
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

        #endregion

        [TestMethod]
        public void TestAddProductOnCartWithoutToken()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.AddProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            IHttpActionResult response = controller.AddItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestAddProductWithoutLogin()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.AddProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAddProductWithLogin()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.AddProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestAddProductWithLoginData()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.AddProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestRemoveProductOnCartWithoutToken()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.RemoveProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);

            IHttpActionResult response = controller.RemoveItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestRemoveProductWithoutLogin()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.RemoveProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveProductWithLogin()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.RemoveProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestRemoveProductWithLoginData()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.RemoveProduct(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveItem(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestConfirmCartWithoutToken()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.ConfirmCart(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);

            IHttpActionResult response = controller.ConfirmCart(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestConfirmCartWithoutLogin()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.ConfirmCart(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.ConfirmCart(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestConfirmCartWithLogin()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.ConfirmCart(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.ConfirmCart(cartRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestCancelCartWithoutToken()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.CancelCart(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            IHttpActionResult response = controller.CancelCart();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestCancelCartWithoutLogin()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.CancelCart(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.CancelCart();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestCancelCartWithLogin()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.CancelCart(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.CancelCart();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestGetAllCartsByUserWithoutToken()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.GetAllCartsByUser(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            IHttpActionResult response = controller.GetAllCartsByUser();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }
        [TestMethod]
        public void TestGetAllCartsByUserWithoutLogin()
        {
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.GetAllCartsByUser(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllCartsByUser();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllCartsByUserIdWithLogin()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCartService = new Mock<ICartService>();
            var mockUserService = new Mock<IUserService>();
            mockCartService.Setup(x => x.GetAllCartsByUser(cartRequest));
            var controller = new CartController(mockCartService.Object, mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllCartsByUser();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }


        private UserContextDTO GetUserContextDTO(string token)
        {
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.CLIENT_ROLE });
            contextDTO.Token = token;
            return contextDTO;
        }
    }
}