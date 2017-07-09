using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Data.Service;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ESport.Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        private ILoginService loginService { get; set; }
        private IUserService userService { get; set; }


        public LoginController(ILoginService loginService, IUserService userService)
        {
            this.loginService = loginService;
            this.userService = userService;
        }


        [Route("esport/signUp")]
        [HttpPost]
        public IHttpActionResult SignUp(UserRequest signInRequest)
        {
            try
            {
                ValidateLoginRequest(signInRequest);
                userService.AddUser(signInRequest);
                return LoginUser(new LoginUserRequest { UserId = signInRequest.UserId, UserPassword = signInRequest.Password });
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
                return CreateBadResponse("Ocurrió un error al realizar login");
            }
        }

        private void ValidateLoginRequest(UserRequest signInRequest)
        {
            if (String.IsNullOrWhiteSpace(signInRequest.RoleId))
            {
                throw new OperationException("Verifique los datos enviados");
            }

            if (!signInRequest.RoleId.Equals(ESportUtils.CLIENT_ROLE))

            {
                throw new OperationException("Operación valida solo para clientes");
            }

        }

        [Route("esport/loginUser")]
        [HttpPost]
        public IHttpActionResult LoginUser(LoginUserRequest loginRequest)
        {
            try
            {
                UserContextDTO contextDTO = loginService.LoginUser(loginRequest);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Login");
                response.Data = contextDTO;
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
            catch (Exception e)
            {
                return CreateBadResponse("Ocurrió un error al realizar login");
            }
        }
        private IHttpActionResult CreateBadResponse(string message)
        {
            return Ok(ControllerHelper.CreateBadResponse(message));
        }

        [Route("esport/logoutUser")]
        [HttpGet]
        public IHttpActionResult LogoutUser()
        {
            try
            {
                string token = ControllerHelper.GetTokenFromRequest(Request);
                ControllerHelper.ValidateToken(token);
                loginService.Logout(token);
                return CreateSuccessResponse("Logout");
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
            catch (Exception e)
            {
                return CreateBadResponse("Ocurrió un error al realizar logout");
            }
        }

        private IHttpActionResult CreateSuccessResponse(string message)
        {
            return Ok(ControllerHelper.CreateSuccessResponse(message));
        }
    }
}