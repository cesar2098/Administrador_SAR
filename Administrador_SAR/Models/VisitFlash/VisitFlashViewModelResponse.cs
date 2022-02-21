using System;
using System.ComponentModel.DataAnnotations;

namespace Administrador_SAR.Models.VisitFlash
{
    public class VisitFlashViewModelResponse
    {
        public int Id { get; set; }
        [Display(Name = "Bu")]
        public string Bu { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Display(Name = "F Nacimiento")]
        public string BirthDay { get; set; }
        [Display(Name = "Antiguedad")]
        public Nullable<int> Antiquity { get; set; }
        [Display(Name = "Tipo Empleado")]
        public string TypeEmployee { get; set; }
        [Display(Name = "Cateoría Empleado")]
        public string CategoryEmployee { get; set; }
        [Display(Name = "Genero")]
        public string Gender { get; set; }
        [Display(Name = "Nacionalidad")]
        public string Nationality { get; set; }
        [Display(Name = "Posición")]
        public string Position { get; set; }
        [Display(Name = "Accidente Tipo")]
        public string AccidentType { get; set; }
        [Display(Name = "Horario")]
        public string Schedule { get; set; }
        [Display(Name = "Fecha Accidente")]
        public string AccidentDate { get; set; }
        [Display(Name = "Hora Accidente")]
        public TimeSpan? AccidentTime { get; set; }
        [Display(Name = "Obra")]
        public string WorkPlace { get; set; }
        [Display(Name = "Actividad Desarrollada")]
        public string DevelopedActivity { get; set; }
        [Display(Name = "Causa Directa")]
        public string DirectCause { get; set; }
        [Display(Name = "Partes del cuerpo afectadas")]
        public string AffectedBodyPart { get; set; }
        [Display(Name = "Naturaleza de la lesión")]
        public string NatureOfInjury { get; set; }
        [Display(Name = "Accidente Grave")]
        public string IsSeriousAccident { get; set; }
        [Display(Name = "Probable Accidente Fatal")]
        public string CouldBeSeriousAccident { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Fecha Creación")]
        public string CreatedDate { get; set; }
        [Display(Name = "Hora Creación")]
        public TimeSpan? CreatedTime { get; set; }
        [Display(Name = "Usuario")]
        public string Account { get; set; }
        [Display(Name = "Tipo Reporte")]
        public int FlashAlertType { get; set; }
    }
}