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
    public class ProductController : ApiController
    {
        private IProductService productService { get; set; }

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [Route("esport/addProduct")]
        [HttpPost]
        public IHttpActionResult AddProduct(ProductRequest productRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                productService.AddProduct(productRequest);
                return CreateSuccessResponse("El producto se dió de alta satisfactoriamente");
            }
            catch (BadRequestException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (OperationException e)
            {
                return CreateBadResponse(e.Message);
            }
            catch (Exception)
            {
                return CreateBadResponse("Ocurrió un error al agregar product");
            }
        }

        [Route("esport/updateProduct")]
        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductRequest productRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                productService.UpdateProduct(productRequest);
                return CreateSuccessResponse("El producto se actualizó satisfactoriamente");
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
            catch (Exception )
            {
                return CreateBadResponse("Ocurrió un error al acutalizar producto");
            }
        }

        [Route("esport/removeProduct")]
        [HttpDelete]
        public IHttpActionResult RemoveProduct(ProductRequest productRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                productService.RemoveProduct(productRequest);
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

        [Route("esport/allSimpleProduct")]
        [HttpGet]
        public IHttpActionResult GetAllSimpleProducts()
        {
            try
            {
                List<SimpleProductDTO> result = productService.GetAllSimpleProducts();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Lista de Productos");
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
                return CreateBadResponse("Ocurrió un error al obtener productos");
            }
        }

        [Route("esport/allFullProduct")]
        [HttpGet]
        public IHttpActionResult GetAllFullProducts()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                List<FullProductDTO> result = productService.GetAllFullProducts();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Lista de Productos");
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
                return CreateBadResponse("Ocurrió un error al obtener productos");
            }
        }
        [Route("esport/allActiveFullProduct")]
        [HttpGet]
        public IHttpActionResult GetAllActiveFullProducts()
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.CLIENT_ROLE, ESportUtils.ADMIN_ROLE });
                List<FullProductDTO> result = productService.GetAllActiveFullProducts();
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Lista de Productos");
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
                return CreateBadResponse("Ocurrió un error al obtener productos");
            }
        }

        [Route("esport/addFieldOnProduct")]
        [HttpPost]
        public IHttpActionResult AddFieldOnProduct(ProductRequest productRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                productService.AddFieldOnProduct(productRequest);
                return CreateSuccessResponse("El campo se dió de alta satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al agregar campo");
            }
        }

        [Route("esport/updateFieldOnProduct")]
        [HttpPut]
        public IHttpActionResult UpdateFieldOnProduct(ProductRequest productRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                productService.EditFieldOnProduct(productRequest);
                return CreateSuccessResponse("El campo se actualizó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al acutalizar campo");
            }
        }

        [Route("esport/simpleProductByFilter")]
        [HttpPost]
        public IHttpActionResult GetSimpleProductsByFilters(ProductRequest productRequest)
        {
            try
            {
                List<FullProductDTO> result=productService.GetProductsByFilters(productRequest);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Lista de Productos");
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
                return CreateBadResponse("Ocurrió un error al acutalizar campo");
            }
        }

        [Route("esport/removeFieldOnProduct")]
        [HttpDelete]
        public IHttpActionResult RemoveFieldOnProduct(ProductRequest productRequest)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                productService.RemoveFieldOnProduct(productRequest);
                return CreateSuccessResponse("El campo se eliminó satisfactoriamente");
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
                return CreateBadResponse("Ocurrió un error al eliminar campo");
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