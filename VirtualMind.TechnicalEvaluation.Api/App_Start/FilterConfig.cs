using System.Web.Mvc;

namespace VirtualMind.TechnicalEvaluation.Api.App_Start
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}