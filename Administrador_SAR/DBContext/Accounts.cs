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
    
    public partial class Accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accounts()
        {
            this.Alerts = new HashSet<Alerts>();
            this.AlertUsers = new HashSet<AlertUsers>();
            this.Comments = new HashSet<Comments>();
            this.Events = new HashSet<Events>();
            this.Evidences = new HashSet<Evidences>();
            this.RefreshToken = new HashSet<RefreshToken>();
            this.Reports = new HashSet<Reports>();
            this.UserWorkPlaces = new HashSet<UserWorkPlaces>();
            this.VisitManagersCommitmentReport = new HashSet<VisitManagersCommitmentReport>();
            this.VisitSecurityReport = new HashSet<VisitSecurityReport>();
            this.FlashVisitReport = new HashSet<FlashVisitReport>();
            this.VisitFlashReports = new HashSet<VisitFlashReports>();
        }
    
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Role { get; set; }
        public string VerificationToken { get; set; }
        public Nullable<System.DateTime> Verified { get; set; }
        public string ResetToken { get; set; }
        public Nullable<System.DateTime> ResetTokenExpires { get; set; }
        public Nullable<System.DateTime> PasswordReset { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
    
        public virtual Countries Countries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alerts> Alerts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlertUsers> AlertUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Events> Events { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evidences> Evidences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reports> Reports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWorkPlaces> UserWorkPlaces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitManagersCommitmentReport> VisitManagersCommitmentReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitSecurityReport> VisitSecurityReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlashVisitReport> FlashVisitReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitFlashReports> VisitFlashReports { get; set; }
    }
}
