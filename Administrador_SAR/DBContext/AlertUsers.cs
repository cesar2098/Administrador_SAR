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
    
    public partial class AlertUsers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AlertId { get; set; }
        public int AlertStatusId { get; set; }
    
        public virtual Accounts Accounts { get; set; }
        public virtual Alerts Alerts { get; set; }
        public virtual AlertStatus AlertStatus { get; set; }
    }
}