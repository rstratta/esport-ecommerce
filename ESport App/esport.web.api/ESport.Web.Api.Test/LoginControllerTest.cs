using Microsoft.VisualStudio.TestTools.UnitTesting;

using ESport.Data.Service;
using System.Web.Http;
using ESport.Data.Commons;
using ESport.Web.Api.Controllers;
using System.Web.Http.Results;
using Moq;

namespace ESport.Web.Api.Test
{
    [TestClass]
    
    public class LoginControllerTest
    {
        public LoginControllerTest()
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
        public void TestLoginUserState()
        {
            LoginUserRequest userRequest = new LoginUserRequest { UserId = "1", UserPassword = "1" };
            var mockLoginService = new Mock<ILoginService>();
            mockLoginService.Setup(x => x.LoginUser(userRequest)).Returns(new UserContextDTO());
            var mockUserService = new Mock<IUserService>();
            var controller = new LoginController(mockLoginService.Object, mockUserService.Object);
            IHttpActionResult response = controller.LoginUser(userRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestLoginUserData()
        {
            LoginUserRequest userRequest = new LoginUserRequest { UserId = "1", UserPassword = "1" };
            var mockLoginService = new Mock<ILoginService>();
            UserContextDTO userContextDTO = new UserContextDTO();
            mockLoginService.Setup(x => x.LoginUser(userRequest)).Returns(new UserContextDTO());
            var mockUserService = new Mock<IUserService>();
            var controller = new LoginController(mockLoginService.Object, mockUserService.Object);
            IHttpActionResult response = controller.LoginUser(userRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
            //TODO
        }

        [TestMethod]
        public void TestLogout()
        {
            var mockLoginService = new Mock<ILoginService>();
            UserContextDTO userContextDTO = new UserContextDTO();
            mockLoginService.Setup(x => x.Logout(""));
            var mockUserService = new Mock<IUserService>();
            var controller = new LoginController(mockLoginService.Object, mockUserService.Object);
            IHttpActionResult response = controller.LogoutUser();
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

    }
}
