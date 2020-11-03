using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger.Annotations;
using VirtualMind.TechnicalEvaluation.Biz.Interface;
using VirtualMind.TechnicalEvaluation.Entities.Domain;

namespace VirtualMind.TechnicalEvaluation.Api.Controllers
{
    [RoutePrefix("api/v1/Currency")]
    public class CurrencyController : ApiController
    {
        private readonly ICurrencyBiz _service;

        public CurrencyController() { }

        public CurrencyController(ICurrencyBiz service)
        {
            _service = service;
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("{isoCurrency}", Name = "GetCurrency"), ResponseType(typeof(ConvertionDetail))]
        public IHttpActionResult GetContenedores(int isoCurrency)
        {
            var result = _service.GetCurrency(isoCurrency);
            return Ok(result);
        }
    }
}
