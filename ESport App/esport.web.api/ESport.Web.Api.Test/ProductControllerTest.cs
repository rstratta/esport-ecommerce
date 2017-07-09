using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Controllers;
using System.Net.Http;
using ESport.Web.Api.Controllers;
using ESport.Data.Service;
using ESport.Data.Commons;

namespace ESport.Web.Api.Test
{
    [TestClass]
    
    public class ProductControllerTest
    {
        public ProductControllerTest()
        {
            LoginContext.GetInstance().Reset();
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
        public void TestAddProductWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.AddProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.AddProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestAddProductWithoutLogin()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.AddProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAddProductWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.ADMIN_ROLE });
            contextDTO.Token = token;
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.AddProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestEditProductWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.UpdateProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.UpdateProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditProductWithoutLogin()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.UpdateProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.UpdateProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditProductWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.ADMIN_ROLE });
            contextDTO.Token = token;
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.UpdateProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.UpdateProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestRemoveProductWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.RemoveProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.RemoveProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveProductWithoutLogin()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.RemoveProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }
        [TestMethod]
        public void TestRemoveProductWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.ADMIN_ROLE });
            contextDTO.Token = token;
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.RemoveProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }
        

        [TestMethod]
        public void TestGetAllProduct()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllSimpleProducts()).Returns(new List<SimpleProductDTO>());
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.GetAllSimpleProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestGetAllProductData()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllSimpleProducts()).Returns(new List<SimpleProductDTO>());
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.GetAllSimpleProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllFullProductWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllFullProducts()).Returns(new List<FullProductDTO>());
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.GetAllFullProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllFullProductWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.ADMIN_ROLE });
            contextDTO.Token = token;
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllFullProducts());
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllFullProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestGetAllFullProducts()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.ADMIN_ROLE });
            contextDTO.Token = token;
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllFullProducts()).Returns(new List<FullProductDTO>());
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllFullProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllActiveFullProductsWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllActiveFullProducts()).Returns(new List<FullProductDTO>());
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.GetAllActiveFullProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllFullActiveProductWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.CLIENT_ROLE });
            contextDTO.Token = token;
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllActiveFullProducts());
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllActiveFullProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        public void TestAllFullActiveProducts()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllActiveFullProducts()).Returns(new List<FullProductDTO>());
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllActiveFullProducts();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestAddFieldOnProductWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.AddFieldOnProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.AddFieldOnProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestAddFieldWithoutLogin()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.AddFieldOnProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddFieldOnProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditFieldOnProductWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.EditFieldOnProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.UpdateFieldOnProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditFieldProductWithoutLogin()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.EditFieldOnProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.UpdateFieldOnProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveFieldOnProductWithoutToken()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.RemoveFieldOnProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            IHttpActionResult response = controller.RemoveFieldOnProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveFieldProductWithoutLogin()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.RemoveFieldOnProduct(new ProductRequest()));
            var controller = new ProductController(mockProductService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveFieldOnProduct(new ProductRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }
    }
}
