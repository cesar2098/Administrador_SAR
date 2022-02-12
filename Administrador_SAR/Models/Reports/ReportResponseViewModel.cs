using Administrador_SAR.Models.Evidences;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Administrador_SAR.Models.Reports
{
    public class ReportResponseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Hora Creación")]
        public TimeSpan CreatedTime { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Comentario")]
        public string Comment { get; set; }
        [Display(Name = "Corrección")]
        public string CorrectiveComment { get; set; }
        [Display(Name = "Creador")]
        public  string Account { get; set; }
        [Display(Name = "Factor")]
        public string Factor { get; set; }
        [Display(Name = "Killer")]
        public string Killer { get; set; }
        [Display(Name = "Situación")]
        public string Situation { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; }
        [Display(Name = "Obra")]
        public string WorkPlace { get; set; }

        public List<EvidenceResponseViewModel> Evidences { get; set; }
    }
}