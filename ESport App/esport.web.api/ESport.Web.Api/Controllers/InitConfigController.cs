using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Data.Service;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ESport.Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InitConfigController : ApiController
    {
        private static string MAN_CATEGORY_ID = "vestH.";
        private static string WOMAN_CATEGORY_ID = "vestM.";
        private IRoleService roleService { get; set; }
        private IUserService userService { get; set; }
        private ICategoryService categoryService { get; set; }
        private IProductService productService { get; set; }

        public InitConfigController(IRoleService roleService, IUserService userService, ICategoryService categoryService, IProductService productService)
        {
            this.roleService = roleService;
            this.userService = userService;
            this.categoryService = categoryService;
            this.productService = productService;
        }

        [Route("esport/initConfig/addRoles")]
        [HttpGet]
        public IHttpActionResult AddRoles()
        {
            try
            {
                RoleRequest roleRequest = CreateRoleRequest( ESportUtils.ADMIN_ROLE , "Administrador de sistema");
                roleService.AddRole(roleRequest);
                roleRequest = CreateRoleRequest(ESportUtils.CLIENT_ROLE, "Cliente de ESport");
                roleService.AddRole(roleRequest);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Roles agregados correctamente");
                response.Data = roleService.GetAllRoles();
                return Ok(response);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (RepositoryException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (OperationException e)
            {
                return InternalServerError(e);
            }
            catch (Exception)
            {
                return CreateBadResponse("Ocurrió un error al realizar operación");
            }
        }


        [Route("esport/initConfig/addUsers")]
        [HttpGet]
        public IHttpActionResult AddUsers()
        {
            try
            {
                UserRequest userRequest = CreateUserClientRequest();
                userService.AddUser(userRequest);
                userRequest = CreateUserAdminRequest();
                userService.AddUser(userRequest);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Usuarios agregados correctamente");
                response.Data = userService.GetAllActiveUsers();
                return Ok(response);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (RepositoryException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (OperationException e)
            {
                return InternalServerError(e);
            }
            catch (Exception)
            {
                return CreateBadResponse("Ocurrió un error al realizar operación");
            }
        }

        [Route("esport/initConfig/addCategories")]
        [HttpGet]
        public IHttpActionResult AddCategory()
        {
            try
            {
                CategoryRequest categoryRequest = CreateCategoryRequest(MAN_CATEGORY_ID,"Vestimenta Hombre");
                categoryService.AddCategory(categoryRequest);
                categoryRequest = CreateCategoryRequest(WOMAN_CATEGORY_ID, "Vestimenta Mujer");
                categoryService.AddCategory(categoryRequest);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Categorías agregadas correctamente");
                response.Data = categoryService.GetAllActiveCategories();
                return Ok(response);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (RepositoryException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (OperationException e)
            {
                return InternalServerError(e);
            }
            catch (Exception)
            {
                return CreateBadResponse("Ocurrió un error al realizar operación");
            }
        }

        [Route("esport/initConfig/addProducts")]
        [HttpGet]
        public IHttpActionResult AddProduct()
        {
            try
            {
                ProductRequest productRequest = CreateProductRequest("1","Campera","Nike",1000,"Campera hombre");
                productService.AddProduct(productRequest);
                productRequest = CreateProductRequest("2","Remera", "Puma", 700, "Remera dama");
                productService.AddProduct(productRequest);
                CategoryRequest categoryRequest = new CategoryRequest() { CategoryId = MAN_CATEGORY_ID, ProductId = "1" };
                categoryService.AddProductOnCategory(categoryRequest);
                categoryRequest = new CategoryRequest() { CategoryId = WOMAN_CATEGORY_ID, ProductId = "2" };
                categoryService.AddProductOnCategory(categoryRequest);
                productRequest = CreateProductRequest("3", "Pantalon","Nike", 475, "Pantalon");
                productService.AddProduct(productRequest);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Productos  agregados correctamente");
                response.Data = categoryService.GetAllActiveCategories();
                return Ok(response);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (RepositoryException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (OperationException e)
            {
                return InternalServerError(e);
            }
            catch (Exception)
            {
                return CreateBadResponse("Ocurrió un error al realizar operación");
            }
        }

        private ProductRequest CreateProductRequest(string productId, string productName,string factory, double price, string description)
        {
            return new ProductRequest() { ProductId = productId, ProductName = productName, Factory = factory, Price = price, Description = description };
        }

        private CategoryRequest CreateCategoryRequest(string categoryId, string categoryDesc)
        {
            return new CategoryRequest() { CategoryId = categoryId, Description = categoryDesc };
        }

        private UserRequest CreateUserClientRequest()
        {
            return new UserRequest() { UserId = "client", Address = "clientAddress", EMail = "client@esport.com.uy", Password = "clientPass", Phone = "+59899043474", UserName = "clientName", UserLastName = "clientLastName", RoleId =  ESportUtils.CLIENT_ROLE };
        }

        private UserRequest CreateUserAdminRequest()
        {
            return new UserRequest() { UserId = "admin", Address = "adminAddress", EMail = "admin@esport.com.uy", Password = "adminPass", Phone = "+59899043474", UserName = "adminName", UserLastName = "adminLastName", RoleId =  ESportUtils.ADMIN_ROLE };
        }

        private RoleRequest CreateRoleRequest(string roleId, string roleDescription)
        {
            return new RoleRequest() { RoleId = roleId, Description = roleDescription };
        }
        private IHttpActionResult CreateBadResponse(string message)
        {
            return Ok(ControllerHelper.CreateBadResponse(message));
        }

    }
}
