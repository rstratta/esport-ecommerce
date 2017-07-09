using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ESport.Data.Service;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Controllers;
using System.Net.Http;
using ESport.Web.Api.Controllers;
using ESport.Data.Commons;

namespace ESport.Web.Api.Test
{
    [TestClass]
    
    public class ReviewControllerTest
    {
        ReviewRequest reviewRequest;
        public ReviewControllerTest()
        {
            LoginContext.GetInstance().Reset();
            reviewRequest = new ReviewRequest { CartItemId = "1", ProductId="1", UserId="1" };
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
        public void TestAddReviewWithoutToken()
        {
            var mockReviewService = new Mock<IReviewService>();
            mockReviewService.Setup(x => x.AddReview(reviewRequest));
            var cartService = new Mock<ICartService>();
            var controller = new ReviewController(mockReviewService.Object, cartService.Object);
            IHttpActionResult response = controller.AddReview(reviewRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }


        [TestMethod]
        public void TestAddReviewWithoutLogin()
        {
            var mockReviewService = new Mock<IReviewService>();
            mockReviewService.Setup(x => x.AddReview(reviewRequest));
            var cartService = new Mock<ICartService>();
            var controller = new ReviewController(mockReviewService.Object, cartService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddReview(reviewRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestAddReviewWithLogin()
        {

            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO userContextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(userContextDTO);
            var mockReviewService = new Mock<IReviewService>();
            mockReviewService.Setup(x => x.AddReview(reviewRequest));
            var cartService = new Mock<ICartService>();
            var controller = new ReviewController(mockReviewService.Object, cartService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.AddReview(reviewRequest);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        private UserContextDTO GetUserContextDTO(string token)
        {
            UserContextDTO contextDTO = new UserContextDTO();
            contextDTO.UserDTO = new UserDTO();
            contextDTO.UserDTO.Roles.Add(new RoleDTO() { RoleId= ESportUtils.CLIENT_ROLE });
            contextDTO.Token = token;
            return contextDTO;
        }

        [TestMethod]
        public void TestGetReviewsByProductIdWithoutToken()
        {
            var mockReviewService = new Mock<IReviewService>();
            mockReviewService.Setup(x => x.GetReviewsByProductId(reviewRequest.ProductId)).Returns(new List<ReviewDTO>());
            var cartService = new Mock<ICartService>();
            var controller = new ReviewController(mockReviewService.Object, cartService.Object);
            IHttpActionResult response = controller.GetReviewsByProductId(reviewRequest.ProductId);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetReviewsByProductIdWithoutLogin()
        {
            var mockReviewService = new Mock<IReviewService>();
            mockReviewService.Setup(x => x.GetReviewsByProductId(reviewRequest.ProductId));
            var cartService = new Mock<ICartService>();
            var controller = new ReviewController(mockReviewService.Object, cartService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, new Guid().ToString());
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetReviewsByProductId(reviewRequest.ProductId);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Message);
        }

        [TestMethod]
        public void TestGetReviewsByProductIdWithLogin()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockReviewService = new Mock<IReviewService>();
            mockReviewService.Setup(x => x.GetReviewsByProductId(reviewRequest.ProductId));
            var cartService = new Mock<ICartService>();
            var controller = new ReviewController(mockReviewService.Object, cartService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetReviewsByProductId(reviewRequest.ProductId);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsTrue(contentResult.Content.Success);
        }

        [TestMethod]
        public void TestGetReviewsByProductIdWithLoginData()
        {
            string token = LoginContext.GetInstance().GenerateNewToken("1");
            UserContextDTO contextDTO = GetUserContextDTO(token);
            LoginContext.GetInstance().SaveContext(contextDTO);
            var mockReviewService = new Mock<IReviewService>();
            mockReviewService.Setup(x => x.GetReviewsByProductId(reviewRequest.ProductId)).Returns(new List<ReviewDTO>());
            var cartService = new Mock<ICartService>();
            var controller = new ReviewController(mockReviewService.Object, cartService.Object);
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            request.Headers.Add(ControllerHelper.TOKEN_NAME, token);
            controllerContext.Request = request;
            controller.ControllerContext = controllerContext;
            IHttpActionResult response = controller.GetReviewsByProductId(reviewRequest.ProductId);
            var contentResult = response as OkNegotiatedContentResult<ControllerResponse>;
            Assert.IsNotNull(contentResult.Content.Data);
        }

    }
}
