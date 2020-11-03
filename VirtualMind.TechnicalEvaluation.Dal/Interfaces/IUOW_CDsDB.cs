
using System.Collections.Generic;

namespace VirtualMind.TechnicalEvaluation.Dal.Interface
{
    public interface IUOW_CDsEntities
    {
        IGenericRepository<AUD_dContenedores, CDsEntities> AUD_dContenedoresRepository { get; }
        IGenericRepository<AUD_dIncidencias, CDsEntities> AUD_dIncidenciasRepository { get; }
        IGenericRepository<AUD_dLimpieza, CDsEntities> AUD_dLimpiezaRepository { get; }
        IGenericRepository<AUD_dSectores, CDsEntities> AUD_dSectoresRepository { get; }
        IGenericRepository<AUD_dPosiciones, CDsEntities> AUD_dPosicionesRepository { get; }
        IGenericRepository<AUD_sTiposAuditoria, CDsEntities> AUD_sTiposAuditoria { get; }
        IEnumerable<PosicionDeArticulos> AUD_dArticulosyUbicaciones(string valor, int? region);
        IEnumerable<DatosVolumetricos> AUD_dVolumenDeArticulos(string valor, int? region);
        void Dispose();
        void Save();
    }
}
