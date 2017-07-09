using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Data.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ESport.Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IUserService userService { get; set; }

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("esport/addUser")]
        [HttpPost]
        public IHttpActionResult AddUser([FromBody] UserRequest userRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                userService.AddUser(userRequest);
                return CreateSuccessResponse("El usuario se dió de alta satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar usuario");
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
        [Route("esport/editUser")]
        [HttpPut]
        public IHttpActionResult EditUser(UserRequest userRequest)
        {
            try
            {
                ControllerHelper.ValidateIsTheSameUser(Request, userRequest.UserId);
                userService.EditUser(userRequest);
                return CreateSuccessResponse("El usuario se actualizó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar usuario");
            }
        }
        [Route("esport/allUsers")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                List<UserDTO> usersResult = userService.GetAllUsers();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Usuarios");
                response.Data = usersResult;
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
                return CreateBadResponse("Ocurrió un error al obtener usuarios");
            }
        }
        [Route("esport/allActiveUsers")]
        [HttpGet]
        public IHttpActionResult GetAllActiveUsers()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                List<UserDTO> usersResult = userService.GetAllActiveUsers();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Usuarios activos");
                response.Data = usersResult;
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
                return CreateBadResponse("Ocurrió un error al obtener usuarios");
            }
        }

        [Route("esport/removeUser")]
        [HttpDelete]
        public IHttpActionResult RemoveUser(UserRequest userRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                userService.RemoveUser(userRequest);
                return CreateSuccessResponse("El usuario se dió de baja satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al eliminat usuario");
            }
        }

        [Route("esport/addRoleOnUser")]
        [HttpPost]
        public IHttpActionResult AddRoleOnUser(UserRequest userRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                userService.AddRoleOnUser(userRequest);
                return CreateSuccessResponse("El rol se agrego al usuario satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar rol al usuario");
            }
        }


        [Route("esport/removeRoleFromUser")]
        [HttpDelete]
        public IHttpActionResult RemoveRoleFromUser(UserRequest userRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                userService.RemoveRoleFromUser(userRequest);
                return CreateSuccessResponse("El rol se eliminó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al eliminar producto");
            }
        }

        [Route("esport/updatePassword")]
        [HttpPut]
        public IHttpActionResult UpdatePassowrd(UserRequest userRequest)
        {
            try
            {
                ControllerHelper.ValidateIsTheSameUser(Request, userRequest.UserId);
                userService.UpdatePassword(userRequest);
                return CreateSuccessResponse("El password se actualizó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar usuario");
            }
        }
    }
}