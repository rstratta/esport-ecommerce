using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Data.Service;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ESport.Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReporterController : ApiController
    {
        private ICartService cartService { get; set; }

        public ReporterController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [Route("esport/productReport")]
        [HttpGet]
        public IHttpActionResult ProductReport(int quantity)
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                AbstractReportDTO reportDTO = cartService.GetMaxProductSaled(quantity);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Reporte solicitado");
                response.Data = reportDTO;
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
                return CreateBadResponse("Ocurrió un error al emitir reporte de productos");
            }
        }

        [Route("esport/categoryReport")]
        [HttpGet]
        public IHttpActionResult CategoryReport([FromUri]string startDate="", [FromUri]string finishDate="")
        {
            try
            {
                ControllerHelper.ValidateUserRole(Request, new string[] { ESportUtils.ADMIN_ROLE });
                AbstractReportDTO reportDTO = cartService.GetCategoryReport(startDate, finishDate);
                ControllerResponse response = ControllerHelper.CreateSuccessResponse("Reporte solicitado");
                response.Data = reportDTO;
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
                return CreateBadResponse("Ocurrió un error al emitir reporte de categorias");
            }
        }

        private IHttpActionResult CreateBadResponse(string message)
        {
            return Ok(ControllerHelper.CreateBadResponse(message));
        }


    }
}
