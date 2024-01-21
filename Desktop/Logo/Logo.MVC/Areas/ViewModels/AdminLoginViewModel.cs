using System.ComponentModel.DataAnnotations;

namespace Logo.MVC.Areas.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [MaxLength(10)]
        public string UserName { get; set;}
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
