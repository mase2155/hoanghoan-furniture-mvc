using hoanghoan_furniture_devmaster.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace hoanghoan_furniture_devmaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }
            HttpContext.Session.SetString("AdminLogin", login.email);
            return RedirectToAction("Index" , "Dashboard");
        }
    }
}
