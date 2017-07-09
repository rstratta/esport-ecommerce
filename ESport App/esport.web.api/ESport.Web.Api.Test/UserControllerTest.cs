using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using ESport.Web.Api.Controllers;
using System.Web.Http.Controllers;
using System.Net.Http;

using ESport.Data.Service;
using ESport.Data.Commons;

namespace ESport.Web.Api.Test
{
    [TestClass]
    
    public class UserControllerTest
    {
        UserRequest userRequest;
        public UserControllerTest()
        {
            LoginContext.GetInstance().Reset();
            userRequest = new UserRequest();
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
        public void TestAddUserWithoutToken()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.AddUser(new UserRequest()));
            var controller = new UserController(mockUserService.Object);
            IHttpActionResult response = controller.AddUser(new UserRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAddUserWithoutLogin()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.AddUser(new UserRequest()));
            var controller = new UserController(mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddUser(new UserRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditUserWithoutToken()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.EditUser(new UserRequest()));
            var controller = new UserController(mockUserService.Object);
            IHttpActionResult response = controller.EditUser(userRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditUserWithoutLogin()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.EditUser(new UserRequest()));
            var controller = new UserController(mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.EditUser(userRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveUserWithoutToken()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.RemoveUser(new UserRequest()));
            var controller = new UserController(mockUserService.Object);
            IHttpActionResult response = controller.RemoveUser(userRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveUserWithoutLogin()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.RemoveUser(new UserRequest()));
            var controller = new UserController(mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveUser(userRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllUserWithoutToken()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetAllUsers()).Returns(new List<UserDTO>());
            var controller = new UserController(mockUserService.Object);
            IHttpActionResult response = controller.GetAllUsers();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAllUserWithoutLogin()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetAllUsers()).Returns(new List<UserDTO>());
            var controller = new UserController(mockUserService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllUsers();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllActiveUsersWithoutToken()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetAllActiveUsers()).Returns(new List<UserDTO>());
            var controller = new UserController(mockUserService.Object);
            IHttpActionResult response = controller.GetAllActiveUsers();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }
       
    }
}
