using System.ComponentModel.DataAnnotations;

namespace Administrador_SAR.Models.WorkPlace
{
    public class CreateWorkPlaceRequestModel
    {
        [Required(ErrorMessage = "Ingrese un nombre para la obra")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(250, ErrorMessage = "La descripción es demasiado larga.")]
        public string Description { get; set; }
        [Display(Name = "País")]
        [Required(ErrorMessage = "Seleccione un país")]
        public int CountryId { get; set; }
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        [Display(Name = "Latitud")]
        public double Latitude { get; set; }
        [Display(Name = "Longitud")]
        public double Longitude { get; set; }
        [Required(ErrorMessage = "Seleccione un supervisor")]
        [Display(Name = "Supervisor")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Ingrese un código para la obra")]
        [Display(Name = "Código")]
        [MaxLength(50, ErrorMessage = "Solo puede ingresar 50 carácteres como máximo.")]
        public string Code { get;set; }
    }
}