using System.ComponentModel.DataAnnotations;

namespace NZWalkz.API.Models.DTOs.Register
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Role { get; set; }
    }
}
