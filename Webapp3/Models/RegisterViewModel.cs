using System.ComponentModel.DataAnnotations;

namespace Webapp3.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters")]
        public string UserName { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password can be min 6 characters")]
        [MaxLength(16, ErrorMessage = "Password can be max 16 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Re-Password is required")]
        [MinLength(6, ErrorMessage = "Re-Password can be min 6 characters")]
        [MaxLength(16, ErrorMessage = "Re-Password can be max 16 characters")]
        [Compare(nameof(Password))] // 2 şifreyi karşılaştırır.
        public string RePassword { get; set; }
    }
}
