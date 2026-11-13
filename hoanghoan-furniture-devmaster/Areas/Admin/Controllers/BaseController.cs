using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hoanghoan_furniture_devmaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller ,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("AdminLogin") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Login", Action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(context);
        }
    }
}
