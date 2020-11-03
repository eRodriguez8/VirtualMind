using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using VirtualMind.TechnicalEvaluation.Biz.Exceptions;

namespace VirtualMind.TechnicalEvaluation.Api.Helpers
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                throw new BadRequestException();
            }
        }
    }
}