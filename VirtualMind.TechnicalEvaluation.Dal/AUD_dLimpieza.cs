//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualMind.TechnicalEvaluation.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUD_dLimpieza
    {
        public int id { get; set; }
        public int idregion { get; set; }
        public string ubicacion { get; set; }
        public int idAuditoriaIncidencia { get; set; }
        public int legajo { get; set; }
        public System.DateTime fecharegistro { get; set; }
    
        public virtual AUD_dIncidencias AUD_dIncidencias { get; set; }
    }
}
