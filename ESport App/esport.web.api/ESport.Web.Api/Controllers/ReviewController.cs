using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Data.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ESport.Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReviewController : ApiController
    {
        private IReviewService reviewService { get; set; }
        private ICartService cartService { get; set; }

        public ReviewController(IReviewService reviewService, ICartService cartService)
        {
            this.reviewService = reviewService;
            this.cartService = cartService;
        }

        [Route("esport/addReview")]
        [HttpPost]
        public IHttpActionResult AddReview(ReviewRequest reviewRequest)
        {
            try
            {
                ControllerHelper.CalidateAndSetUserInReviewRequest(Request, reviewRequest);
                reviewService.AddReview(reviewRequest);
                List<PendingReviewDTO> pendingReviews = cartService.GetPendingReviewsForUser(reviewRequest.UserId);
                UserContextDTO userContext = GetUserContextFromRequest(Request);
                userContext.PendingsReviewDTO = pendingReviews;
                LoginContext.GetInstance().SaveContext(userContext);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("La review se dió de alta satisfactoriamente");
                response.Data = userContext;
                return Ok(response);
            }
            catch (BadRequestException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (RepositoryException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (OperationException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (Exception)
            {
                return CreateBadResponse("Ocurrió un error al agregar review");
            }
        }

        [Route("esport/allReviewsByProduct/{productId}")]
        [HttpGet]
        public IHttpActionResult GetReviewsByProductId(string productId)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.CLIENT_ROLE });
                List<ReviewDTO> result = reviewService.GetReviewsByProductId(productId);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Reviews");
                response.Data = result;
                return Ok(response);
            }
            catch (BadRequestException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (RepositoryException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (OperationException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (Exception)
            {
                return CreateBadResponse("Ocurrió un error al acutalizar la categoría");
            }
        }

        private IHttpActionResult CreateBadResponse(string message)
        {
            return Ok(ControllerHelper.CreateBadResponse(message));
        }


        private IHttpActionResult CreateSuccessResponse(string message)
        {
            return Ok(ControllerHelper.CreateSuccessResponse(message));
        }

        private UserContextDTO GetUserContextFromRequest(HttpRequestMessage request)
        {
            return LoginContext.GetInstance().GetUserContextByToken(ControllerHelper.GetTokenFromRequest(Request));
        }
    }
}