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
    
    public partial class AUD_dContenedores
    {
        public int id { get; set; }
        public string etiqueta { get; set; }
        public string codigoarticulo { get; set; }
        public int idAuditoriaSector { get; set; }
        public int idAuditoriaIncidencia { get; set; }
        public int legajo { get; set; }
        public System.DateTime fecharegistro { get; set; }
        public Nullable<int> idregion { get; set; }
    
        public virtual AUD_dSectores AUD_dSectores { get; set; }
        public virtual AUD_dIncidencias AUD_dIncidencias { get; set; }
    }
}