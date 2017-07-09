using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Controllers;
using System.Net.Http;
using ESport.Data.Service;
using ESport.Data.Commons;
using ESport.Web.Api.Controllers;

namespace ESport.Web.Api.Test
{
    [TestClass]
    
    public class CategoryControllerTest
    {
        CategoryRequest categoryRequest;
        public CategoryControllerTest()
        {
            LoginContext.GetInstance().Reset();
            categoryRequest = new CategoryRequest { CategoryId = "1" };
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
        public void TestAddCategoryWithoutToken()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.AddCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryService.Object);
            IHttpActionResult response = controller.AddCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestAddCategoryWithoutLogin()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.AddCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAddCategoryWithLogin()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.AddCategory(categoryRequest));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddCategory(categoryRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        private UserContextDTO GetUserContextDTO(string token)
        {
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId = ESportUtils.ADMIN_ROLE });
            contextDTO.Token = token;
            return contextDTO;
        }

        [TestMethod]
        public void TestEditCategoryWithoutToken()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.EditCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryService.Object);
            IHttpActionResult response = controller.UpdateCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditCategoryWithoutLogin()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.EditCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.UpdateCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestEditCategoryWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.EditCategory(categoryRequest));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.UpdateCategory(categoryRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestRemoveCategoryWithoutToken()
        {
            var mockCategoryController = new Mock<ICategoryService>();
            mockCategoryController.Setup(x => x.RemoveCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryController.Object);
            IHttpActionResult response = controller.RemoveCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestRemoveCateforyWithoutLogin()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.RemoveCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }
        [TestMethod]
        public void TestRemoveCategoryWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.RemoveCategory(categoryRequest));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.RemoveCategory(categoryRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }


        [TestMethod]
        public void TestGetAllCategoryWithoutToken()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            IHttpActionResult response = controller.GetAllCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllCategoryWithoutLogin()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetAllCategoryWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestGetAllCategoryWithLoginData()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllActiveCategoryWithoutToken()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllActiveCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            IHttpActionResult response = controller.GetAllActiveCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllActiveCategoryWithoutLogin()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllActiveCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllActiveCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllActiveCategoryWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllActiveCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllActiveCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestGetAllActiveCategoryWithLoginData()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllActiveCategories()).Returns(new List<CategoryDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetAllActiveCategories();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllProductsByCategoryIdWithoutToken()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetProductsByCategoryId(categoryRequest)).Returns(new List<FullProductDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            IHttpActionResult response = controller.GetProductsByCategoryId("1");
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllProductsByCategoryWithoutLogin()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetProductsByCategoryId(categoryRequest)).Returns(new List<FullProductDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetProductsByCategoryId("1");
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

        [TestMethod]
        public void TestGetAllProductsByCategoryWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            CategoryRequest categoryRequest = new CategoryRequest { CategoryId = "1" };
            mockCategoryService.Setup(x => x.GetProductsByCategoryId(categoryRequest)).Returns(new List<FullProductDTO>());
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetProductsByCategoryId("1");
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        
        [TestMethod]
        public void TestAddProductOnCategoryWithoutToken()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.AddProductOnCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryService.Object);
            IHttpActionResult response = controller.AddProductOnCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestAddProductOnCategoryWithoutLogin()
        {
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.AddProductOnCategory(new CategoryRequest()));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddProductOnCategory(new CategoryRequest());
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAddProductOnCategoryWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.AddProductOnCategory(categoryRequest));
            var controller = new CategoryController(mockCategoryService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddProductOnCategory(categoryRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }


    }
}
