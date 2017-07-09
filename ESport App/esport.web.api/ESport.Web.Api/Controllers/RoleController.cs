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
    public class RoleController : ApiController
    {
        private IRoleService roleService { get; set; }

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [Route("esport/addRole")]
        [HttpPost]
        public IHttpActionResult AddRole(RoleRequest roleRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                roleService.AddRole(roleRequest);
                return CreateSuccessResponse("El rol se dió de alta satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar rol");
            }
        }

        [Route("esport/editRole")]
        [HttpPut]
        public IHttpActionResult EditRole(RoleRequest roleRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                roleService.UpdateRole(roleRequest);
                return CreateSuccessResponse("El rol se actualizó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar rol");
            }
        }

        [Route("esport/removeRole")]
        [HttpDelete]
        public IHttpActionResult RemoveRole(RoleRequest roleRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                roleService.RemoveRole(roleRequest);
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
                return CreateBadResponse("Ocurrió un error al agregar rol");
            }
        }

        [Route("esport/allRoles")]
        [HttpGet]
        public IHttpActionResult GetAllRoles()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                List<RoleDTO> roles = roleService.GetAllRoles();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Roles");
                response.Data = roles;
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
                return CreateBadResponse("Ocurrió un error al agregar rol");
            }
        }


        [Route("esport/allActiveRoles")]
        [HttpGet]
        public IHttpActionResult GetAllActiveRoles()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                List<RoleDTO> roles = roleService.GetAllActiveRoles();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Roles");
                response.Data = roles;
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
                return CreateBadResponse("Ocurrió un error al agregar rol");
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


    }
}