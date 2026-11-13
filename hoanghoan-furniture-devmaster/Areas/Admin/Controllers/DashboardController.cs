using Microsoft.AspNetCore.Mvc;

namespace hoanghoan_furniture_devmaster.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
