using ESport.Data.Commons;
using ESport.Data.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http;
using ESport.Data.Entities;

namespace ESport.Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CartController : ApiController
    {
        private ICartService cartService { get; set; }
        private IUserService userService { get; set; }

        public CartController(ICartService cartService, IUserService userService)
        {
            this.cartService = cartService;
            this.userService = userService;
        }

        [Route("esport/addItem")]
        [HttpPost]
        public IHttpActionResult AddItem(CartRequest cartRequest)
        {
            try
            {
                ControllerHelper.ValidateAndSetUserInCartRequest(Request, cartRequest);
                CartDTO cartResult = cartService.AddProduct(cartRequest);
                UserContextDTO userContext = GetUserContextFromRequest(Request);
                userContext.PendingCart = cartResult;
                LoginContext.GetInstance().SaveContext(userContext);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("El producto se agrego al carrito satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar producto al carrito");
            }
        }

        private UserContextDTO GetUserContextFromRequest(HttpRequestMessage request)
        {
            return LoginContext.GetInstance().GetUserContextByToken(ControllerHelper.GetTokenFromRequest(Request));            
        }

        [Route("esport/removeItem")]
        [HttpPost]
        public IHttpActionResult RemoveItem(CartRequest cartRequest)
        {
            try
            {
                ControllerHelper.ValidateAndSetUserInCartRequest(Request, cartRequest);
                CartDTO cartResult = cartService.RemoveProduct(cartRequest);
                UserContextDTO userContext = GetUserContextFromRequest(Request);
                userContext.PendingCart = cartResult;
                LoginContext.GetInstance().SaveContext(userContext);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("El producto se eliminó del carrito satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al eliminar producto del carrito");
            }
        }

        [Route("esport/confirmCart")]
        [HttpPost]
        public IHttpActionResult ConfirmCart(CartRequest cartRequest)
        {
            try
            {
                ControllerHelper.ValidateAndSetUserInCartRequest(Request, cartRequest);
                cartService.ConfirmCart(cartRequest);
                List<PendingReviewDTO> pendingReviews = cartService.GetPendingReviewsForUser(cartRequest.UserId);
                UserContextDTO userContext = GetUserContextFromRequest(Request);
                userContext.PendingCart = null;
                userContext.PendingsReviewDTO = pendingReviews;
                UserDTO userDTO = userService.GetUserById(new UserRequest() { UserId = cartRequest.UserId });
                userContext.UserDTO = userDTO;
                LoginContext.GetInstance().SaveContext(userContext);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("El carrito se confirmó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al confirmar carrito");
            }
        }

        [Route("esport/cancelCart")]
        [HttpGet]
        public IHttpActionResult CancelCart()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.CLIENT_ROLE });
                string token = ControllerHelper.GetTokenFromRequest(Request);
                CartRequest cartRequest = new CartRequest( ){ UserId = ControllerHelper.GetUserIdFromToken(token) };
                cartService.CancelCart(cartRequest);
                UserContextDTO userContext = GetUserContextFromRequest(Request);
                userContext.PendingCart = null;
                LoginContext.GetInstance().SaveContext(userContext);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("El carrito se cancelo satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al cancelar carrito");
            }
        }


        private IHttpActionResult CreateBadResponse(string message)
        {
            return Ok(ControllerHelper.CreateBadResponse(message));
        }


       

        [Route("esport/allCartsByUser")]
        [HttpGet]
        public IHttpActionResult GetAllCartsByUser()
        {
            try
            {
                string token = ControllerHelper.GetTokenFromRequest(Request);
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.CLIENT_ROLE });
                UserContextDTO userContext = LoginContext.GetInstance().GetUserContextByToken(token);
                CartRequest cartRequest = new CartRequest { UserId = userContext.UserDTO.UserId };
                List<CartDTO> cartsDTOResult = cartService.GetAllCartsByUser(cartRequest);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Carritos");
                response.Data = cartsDTOResult;
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
                return CreateBadResponse("Ocurrió un error al obtener carritos");
            }
        }
    }
}