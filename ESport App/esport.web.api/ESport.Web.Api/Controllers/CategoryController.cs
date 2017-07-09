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
    public class CategoryController : ApiController
    {
        private ICategoryService categoryService { get; set; }

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Route("esport/addCategory")]
        [HttpPost]
        public IHttpActionResult AddCategory(CategoryRequest categoryRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                categoryService.AddCategory(categoryRequest);
                return CreateSuccessResponse("La categoria se dió de alta satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar la categoría");
            }
        }

        [Route("esport/updateCategory")]
        [HttpPut]
        public IHttpActionResult UpdateCategory(CategoryRequest categoryRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                categoryService.EditCategory(categoryRequest);
                return CreateSuccessResponse("La categoría se actualizó satisfactoriamente");
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

        [Route("esport/removeCategory")]
        [HttpDelete]
        public IHttpActionResult RemoveCategory(CategoryRequest categoryRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                categoryService.RemoveCategory(categoryRequest);
                return CreateSuccessResponse("La categoría se eliminó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al eliminar la categoría");
            }
        }

        [Route("esport/allActiveCategories")]
        [HttpGet]
        public IHttpActionResult GetAllActiveCategories()
        {
            try
            {
                List<CategoryDTO> result = categoryService.GetAllActiveCategories();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Lista de Categorías");
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
                return CreateBadResponse("Ocurrió un error al obtener categorías");
            }
        }

        [Route("esport/allCategories")]
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                List<CategoryDTO> result = categoryService.GetAllCategories();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Lista de Categorias");
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
                return CreateBadResponse("Ocurrió un error al obtener categorias");
            }
        }


        [Route("esport/addProductOnCategory")]
        [HttpPost]
        public IHttpActionResult AddProductOnCategory(CategoryRequest categoryRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                categoryService.AddProductOnCategory(categoryRequest);
                return CreateSuccessResponse("El producto se agrego a la categoria satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar producto en categoría");
            }
        }


        [Route("esport/removeProductFromCategory")]
        [HttpDelete]
        public IHttpActionResult RemoveProductFromCategory(CategoryRequest categoryRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                categoryService.RemoveProductFromCategory(categoryRequest);
                return CreateSuccessResponse("El producto se eliminó satisfactoriamente");
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

        [Route("esport/productsByCategory/{categoryId}")]
        [HttpGet]
        public IHttpActionResult GetProductsByCategoryId(string categoryId)
        {
            try
            {
                CategoryRequest request = new CategoryRequest();
                request.CategoryId = categoryId;
                List<FullProductDTO> result = categoryService.GetProductsByCategoryId(request);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Productos para categoria");
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
                return CreateBadResponse("Ocurrió un error al eliminar producto");
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