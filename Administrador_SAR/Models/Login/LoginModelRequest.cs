using System.ComponentModel.DataAnnotations;

namespace Administrador_SAR.Models
{
    public class LoginModelRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}