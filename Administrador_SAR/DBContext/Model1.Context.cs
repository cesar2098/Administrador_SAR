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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RSDBEntities : DbContext
    {
        public RSDBEntities()
            : base("name=RSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Alerts> Alerts { get; set; }
        public virtual DbSet<AlertStatus> AlertStatus { get; set; }
        public virtual DbSet<AlertTypes> AlertTypes { get; set; }
        public virtual DbSet<AlertUsers> AlertUsers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventTypes> EventTypes { get; set; }
        public virtual DbSet<Evidences> Evidences { get; set; }
        public virtual DbSet<Factors> Factors { get; set; }
        public virtual DbSet<Killers> Killers { get; set; }
        public virtual DbSet<QuestionSecurityVisit> QuestionSecurityVisit { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<ReportFollowUp> ReportFollowUp { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<SecurityVisit> SecurityVisit { get; set; }
        public virtual DbSet<SecurityVisitQuestionsReport> SecurityVisitQuestionsReport { get; set; }
        public virtual DbSet<Situations> Situations { get; set; }
        public virtual DbSet<StatusReports> StatusReports { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserWorkPlaces> UserWorkPlaces { get; set; }
        public virtual DbSet<VisitManagersCommitment> VisitManagersCommitment { get; set; }
        public virtual DbSet<VisitManagersCommitmentReport> VisitManagersCommitmentReport { get; set; }
        public virtual DbSet<VisitManagersCommitmentResults> VisitManagersCommitmentResults { get; set; }
        public virtual DbSet<VisitSecurityReport> VisitSecurityReport { get; set; }
        public virtual DbSet<WorkPlaces> WorkPlaces { get; set; }
    }
}
