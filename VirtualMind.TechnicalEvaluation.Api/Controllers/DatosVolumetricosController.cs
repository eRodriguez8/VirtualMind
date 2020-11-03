using VirtualMind.TechnicalEvaluation.Biz.Interface;
using VirtualMind.TechnicalEvaluation.Entities.Domain;
using log4net;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace VirtualMind.TechnicalEvaluation.Api.Controllers
{
    [RoutePrefix("api/v1/DatosVolumetricos")]
    public class DatosVolumetricosController : ApiController
    {
        private readonly IDatosVolumetricosBiz _service;
        private readonly ILog Logger;

        public DatosVolumetricosController()
        {
            Logger = LogManager.GetLogger(GetType());
        }

        public DatosVolumetricosController(IDatosVolumetricosBiz service)
        {
            _service = service;
        }
        
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("{valor}/{idregion}", Name = "GetVolumenDeArticulos"), ResponseType(typeof(DatosVolumetricos))]

        public IHttpActionResult GetVolumenDeArticulos(string valor, int idregion)
        {
            try
            {
                var result = _service.volumenDeArticulos(valor, idregion);
                return Ok(result);
            }
            catch (Exception Exception)
            {
                Logger.Error(Exception);
                throw;
            }
        }
    }
}
