using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace Webapp3.Entites
{
    [Table("Users")]
    public class User
    {   [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string ?FullName { get; set; }
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required]
       [StringLength(100)]
        public string Password { get; set; }
        public Boolean Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        [StringLength(255)]
        public string ? ProfileImageFilename { get; set; } = "No_Image.jpg";
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";
    }
}
