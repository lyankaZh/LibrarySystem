using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
