using System;
using System.ComponentModel.DataAnnotations;

namespace Administrador_SAR.Models.WorkPlace
{
    public class WorkPlaceResponseViewModel
    {
        public int WorkPlaceId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "País")]
        public string Country { get; set; }
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; }
    }
}