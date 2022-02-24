using System.ComponentModel.DataAnnotations;

namespace Administrador_SAR.Models.UserWorkPlace
{
    public class UserWorkPlaceResponse
    {
        public int WorkPlaceId { get; set; }
        public int UserId { get; set; }
        public int UserType { get; set; }
        public bool IsActive { get; set; }

        [Display(Name="Empleado")]
        public string UserName { get; set; }
        [Display(Name = "Obra")]
        public string WorkPlace { get; set; }
        [Display(Name = "Tipo Empleado")]
        public string Type { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; }
    }
}