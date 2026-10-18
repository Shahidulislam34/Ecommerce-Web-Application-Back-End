using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.DTO
{
    public class SignUpDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
