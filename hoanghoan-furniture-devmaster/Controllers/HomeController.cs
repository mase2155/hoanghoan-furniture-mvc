using System.Diagnostics;
using hoanghoan_furniture_devmaster.Models;
using hoanghoan_furniture_devmaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace hoanghoan_furniture_devmaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _email;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger ,IEmailService email , IWebHostEnvironment env)
        {
            _logger = logger;
            _email = email;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> TestEmail(CancellationToken cancellationToken)
        {
            if (!_env.IsDevelopment())
                return NotFound();

            try
            {
                await _email.SendAsync("dev.hung.utc@gmail.com", "Test SMTP", "<p>Trạng thái : Đã hoàn tất chứuc năng gửi email thông báo</p>", cancellationToken);
                return Content("Đã gửi — xem inbox/spam.");
            }
            catch (Exception ex)
            {
                var detail = ex.InnerException?.Message ?? ex.Message;
                _logger.LogError(ex, "SMTP fail");
                return Content("Lỗi: " + ex.Message + " | Chi tiết: " + detail);
            }
        }
    }
}
