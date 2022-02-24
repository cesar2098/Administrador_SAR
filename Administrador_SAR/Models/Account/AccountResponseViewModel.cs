using System.ComponentModel.DataAnnotations;

namespace Administrador_SAR.Models.Account
{
    public class AccountResponseViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "País")]
        public string Country { get; set; }
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Display(Name = "Genero")]
        public string GenderDescription { get; set; }
        public int Gender { get; set; }
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [Display(Name = "Estado")]
        public string StatusDescription { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Rol")]
        public string Rol { get; set; }
        public int Role { get; set; }
    }
}