using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using ESport.Web.Api.Controllers;
using System.Net.Http;
using System;
using System.Web.Http.Controllers;
using ESport.Data.Service;
using System.Collections.Generic;
using ESport.Data.Commons;

namespace ESport.Web.Api.Test
{
    [TestClass]
    
    public class RoleControllerTest
    {
        RoleRequest roleRequest;
        string USER_ID = "1";
        string CURRENT_TOKEN;
        public RoleControllerTest()
        {
            LoginContext.GetInstance().Reset();
            roleRequest = new RoleRequest { RoleId = "Admin", Description = "Administrador" };
            CURRENT_TOKEN= LoginContext.GetInstance().GenerateNewToken(USER_ID);
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
        public void TestAddRoleWithoutToken()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.AddRole(new RoleRequest {RoleId="Admin",Description="Administrador"}));
            var controller = new RoleController(mockRoleService.Object);
            IHttpActionResult response=controller.AddRole(roleRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAddRoleWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.ADMIN_ROLE });
            contextDTO.Token = token;
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.AddRole(new RoleRequest { RoleId = "Admin", Description = "Administrador" }));
            var controller = new RoleController(mockRoleService.Object);
            var controllerContext = new HttpControllerContext();
            var httpRequest = new HttpRequestMessage();
            httpRequest.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = httpRequest;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddRole(roleRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestEditRoleWithoutToken()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.UpdateRole(new RoleRequest { RoleId = "Admin", Description = "Administrador" }));
            var controller = new RoleController(mockRoleService.Object);
            IHttpActionResult response = controller.EditRole(roleRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditRoleWithoutLogin()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.UpdateRole(new RoleRequest { RoleId = "Admin", Description = "Administrador" }));
            var controller = new RoleController(mockRoleService.Object);
            var controllerContext = new HttpControllerContext();
            var httpRequest = new HttpRequestMessage();
            httpRequest.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = httpRequest;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.EditRole(roleRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveRoleWithoutToken()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.RemoveRole(new RoleRequest { RoleId = "Admin", Description = "Administrador" }));
            var controller = new RoleController(mockRoleService.Object);
            IHttpActionResult response = controller.RemoveRole(roleRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveRoleWithoutLogin()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.RemoveRole(new RoleRequest { RoleId = "Admin", Description = "Administrador" }));
            var controller = new RoleController(mockRoleService.Object);
            var controllerContext = new HttpControllerContext();
            var httpRequest = new HttpRequestMessage();
            httpRequest.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = httpRequest;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveRole(roleRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllRoleWithoutToken()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.GetAllRoles()).Returns(new List<RoleDTO>());
            var controller = new RoleController(mockRoleService.Object);
            IHttpActionResult response = controller.GetAllRoles();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAllRolesWithoutLogin()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.GetAllRoles()).Returns(new List<RoleDTO>());
            var controller = new RoleController(mockRoleService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllRoles();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllActiveRolesWithoutToken()
        {
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.Setup(x => x.GetAllActiveRoles()).Returns(new List<RoleDTO>());
            var controller = new RoleController(mockRoleService.Object);
            var controllerContext = new HttpControllerContext();
            IHttpActionResult response = controller.GetAllActiveRoles();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }
        
   
    }
}
