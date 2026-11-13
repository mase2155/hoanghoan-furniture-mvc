using System.ComponentModel.DataAnnotations;
namespace hoanghoan_furniture_devmaster.Areas.Admin.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        public string email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string password { get; set; }
        public bool remember { get; set; }
    }
}
