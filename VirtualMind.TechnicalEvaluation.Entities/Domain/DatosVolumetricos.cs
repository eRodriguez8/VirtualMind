using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMind.TechnicalEvaluation.Entities.Domain
{
    public class DatosVolumetricos
    {
        public string Articulo { get; set; }
        public string PosicionPicking { get; set; }
        public string Unidad { get; set; }
        public string Caja { get; set; }
        public decimal? UxB { get; set; }
        public string UMD { get; set; }
        public decimal? CxH { get; set; }
        public decimal? HxP { get; set; }
    }
}
