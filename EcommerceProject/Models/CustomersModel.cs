using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Models
{
    public class CustomersModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Give The Full Name")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public string? CustomerID { get; set; }
        public string? Address { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}


