using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger.Annotations;
using VirtualMind.TechnicalEvaluation.Biz.Interface;
using VirtualMind.TechnicalEvaluation.Entities.Domain;

namespace VirtualMind.TechnicalEvaluation.Api.Controllers
{
    [RoutePrefix("api/v1/BuyCurrencies")]
    public class BuyCurrenciesController : ApiController
    {
        private readonly ICurrencyBiz _service;

        public BuyCurrenciesController() { }

        public BuyCurrenciesController(ICurrencyBiz service)
        {
            _service = service;
        }
        
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("{idUser}/{amount}/{iso}", Name = "GetVolumenDeArticulos"), ResponseType(typeof(ConvertionDetail))]
        public IHttpActionResult Buy(int idUser, string amount, int iso)
        {
            var result = _service.BuyCurrencies(idUser, amount, iso);
            return Ok(result);
        }
    }
}
