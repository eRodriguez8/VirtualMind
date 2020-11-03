using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Dal.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualMind.TechnicalEvaluation.Dal.UnitOfWorks
{
    /// <summary>
    /// The unit of work class serves one purpose: to make sure that when you use multiple repositories,
    /// they share a single database context.
    /// </summary>
    public class UOW_CDsDB : IDisposable, IUOW_CDsEntities
    {

        private readonly CDsEntities _cdsDBContext;
        private readonly ILog Logger;

        public UOW_CDsDB(CDsEntities cdsDBContext)
        {
            _cdsDBContext = cdsDBContext;
            Logger = LogManager.GetLogger(GetType());
            _cdsDBContext.Database.Log = (dblog => Logger.Debug(dblog));
        }

        private IGenericRepository<AUD_dContenedores, CDsEntities> _AUD_dContenedoresRepository;
        public IGenericRepository<AUD_dContenedores, CDsEntities> AUD_dContenedoresRepository
        {
            get
            {
                if (_AUD_dContenedoresRepository == null)
                {
                    _AUD_dContenedoresRepository = new GenericRepository<AUD_dContenedores, CDsEntities>(_cdsDBContext);
                }
                return _AUD_dContenedoresRepository;
            }
        }

        private IGenericRepository<AUD_dIncidencias, CDsEntities> _AUD_dIncidenciasRepository;
        public IGenericRepository<AUD_dIncidencias, CDsEntities> AUD_dIncidenciasRepository
        {
            get
            {
                if (_AUD_dIncidenciasRepository == null)
                {
                    _AUD_dIncidenciasRepository = new GenericRepository<AUD_dIncidencias, CDsEntities>(_cdsDBContext);
                }
                return _AUD_dIncidenciasRepository;
            }
        }

        private IGenericRepository<AUD_dLimpieza, CDsEntities> _AUD_dLimpiezaRepository;
        public IGenericRepository<AUD_dLimpieza, CDsEntities> AUD_dLimpiezaRepository
        {
            get
            {
                if (_AUD_dLimpiezaRepository == null)
                {
                    _AUD_dLimpiezaRepository = new GenericRepository<AUD_dLimpieza, CDsEntities>(_cdsDBContext);
                }
                return _AUD_dLimpiezaRepository;
            }
        }

        private IGenericRepository<AUD_dSectores, CDsEntities> _AUD_dSectoresRepository;
        public IGenericRepository<AUD_dSectores, CDsEntities> AUD_dSectoresRepository
        {
            get
            {
                if (_AUD_dSectoresRepository == null)
                {
                    _AUD_dSectoresRepository = new GenericRepository<AUD_dSectores, CDsEntities>(_cdsDBContext);
                }
                return _AUD_dSectoresRepository;
            }
        }

        private IGenericRepository<AUD_dPosiciones, CDsEntities> _AUD_dPosicionesRepository;
        public IGenericRepository<AUD_dPosiciones, CDsEntities> AUD_dPosicionesRepository
        {
            get
            {
                if (_AUD_dPosicionesRepository == null)
                {
                    _AUD_dPosicionesRepository = new GenericRepository<AUD_dPosiciones, CDsEntities>(_cdsDBContext);
                }
                return _AUD_dPosicionesRepository;
            }
        }

        private IGenericRepository<AUD_sTiposAuditoria, CDsEntities> _AUD_sTiposAuditoria;
        public IGenericRepository<AUD_sTiposAuditoria, CDsEntities> AUD_sTiposAuditoria
        {
            get
            {
                if (_AUD_sTiposAuditoria == null)
                {
                    _AUD_sTiposAuditoria = new GenericRepository<AUD_sTiposAuditoria, CDsEntities>(_cdsDBContext);
                }
                return _AUD_sTiposAuditoria;
            }
        }

        public IEnumerable<PosicionDeArticulos> AUD_dArticulosyUbicaciones(string valor, int? region)
        {
           return _cdsDBContext.AUD_dArticulosyUbicaciones(valor, region);
        }

        public IEnumerable<DatosVolumetricos> AUD_dVolumenDeArticulos(string valor, int? region)
        {
            return _cdsDBContext.AUD_dVolumenArticulos(valor, region);
        }

        public void Save()
        {
            _cdsDBContext.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _cdsDBContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}