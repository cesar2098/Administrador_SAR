//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Administrador_SAR.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reports
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reports()
        {
            this.Comments = new HashSet<Comments>();
            this.Events = new HashSet<Events>();
            this.Evidences = new HashSet<Evidences>();
            this.ReportFollowUp = new HashSet<ReportFollowUp>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.TimeSpan CreatedTime { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }
        public int WorkPlaceId { get; set; }
        public int SituationId { get; set; }
        public string Comment { get; set; }
        public int KillerId { get; set; }
        public int FatorId { get; set; }
        public string CorrectiveComment { get; set; }
    
        public virtual Accounts Accounts { get; set; }
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Events> Events { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evidences> Evidences { get; set; }
        public virtual Factors Factors { get; set; }
        public virtual Killers Killers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportFollowUp> ReportFollowUp { get; set; }
        public virtual Situations Situations { get; set; }
        public virtual StatusReports StatusReports { get; set; }
        public virtual WorkPlaces WorkPlaces { get; set; }
    }
}
