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
    
    public partial class WorkPlaces
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkPlaces()
        {
            this.Reports = new HashSet<Reports>();
            this.UserWorkPlaces = new HashSet<UserWorkPlaces>();
            this.VisitManagersCommitmentReport = new HashSet<VisitManagersCommitmentReport>();
            this.VisitSecurityReport = new HashSet<VisitSecurityReport>();
        }
    
        public int WorkPlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.TimeSpan CreatedTime { get; set; }
        public int CountryId { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Countries Countries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reports> Reports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWorkPlaces> UserWorkPlaces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitManagersCommitmentReport> VisitManagersCommitmentReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitSecurityReport> VisitSecurityReport { get; set; }
    }
}
