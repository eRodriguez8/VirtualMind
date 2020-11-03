using System;
using System.Collections.Generic;
using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Dal.Interface;

namespace VirtualMind.TechnicalEvaluation.Test.Fakes
{
    public class FakeUOW_CDsEntities : IDisposable, IUOW_CDsEntities
    {
        public FakeUOW_CDsEntities()
        {
            AccessCounterSave = 0;
            AccessCounterDispose = 0;
        }

        public IList<AUD_dContenedores> AUD_dContenedores { get; set; }
        public IList<AUD_dLimpieza> AUD_dLimpieza { get; set; }
        public IList<AUD_dPosiciones> AUD_dPosiciones { get; set; }
        public IList<AUD_dSectores> AUD_dSectores { get; set; }
        public IList<AUD_sTiposAuditoria> AUD_sTiposAuditoria { get; set; }
        public IList<AUD_dIncidencias> AUD_dIncidencias { get; set; }
        public IEnumerable<PosicionDeArticulos> ArticulosyUbicaciones { get; set; }
        public IEnumerable<DatosVolumetricos> VolumenArticulos { get; set; }

        public int AccessCounterSave { get; private set; }
        public int AccessCounterDispose { get; private set; }

        public FakeRepository<AUD_dContenedores, CDsEntities> Fake_AUD_dContenedoresRepository { get; set; }
        IGenericRepository<AUD_dContenedores, CDsEntities> IUOW_CDsEntities.AUD_dContenedoresRepository
        {
            get
            {
                Fake_AUD_dContenedoresRepository = Fake_AUD_dContenedoresRepository ??
                    new FakeRepository<AUD_dContenedores, CDsEntities>(AUD_dContenedores);
                return Fake_AUD_dContenedoresRepository;
            }
        }

        public FakeRepository<AUD_dIncidencias, CDsEntities> Fake_AUD_dIncidenciasRepository { get; set; }
        IGenericRepository<AUD_dIncidencias, CDsEntities> IUOW_CDsEntities.AUD_dIncidenciasRepository
        {
            get
            {
                Fake_AUD_dIncidenciasRepository = Fake_AUD_dIncidenciasRepository ??
                    new FakeRepository<AUD_dIncidencias, CDsEntities>(AUD_dIncidencias);
                return Fake_AUD_dIncidenciasRepository;
            }
        }

        public FakeRepository<AUD_dLimpieza, CDsEntities> Fake_AUD_dLimpiezaRepository { get; set; }
        IGenericRepository<AUD_dLimpieza, CDsEntities> IUOW_CDsEntities.AUD_dLimpiezaRepository
        {
            get
            {
                Fake_AUD_dLimpiezaRepository = Fake_AUD_dLimpiezaRepository ??
                    new FakeRepository<AUD_dLimpieza, CDsEntities>(AUD_dLimpieza);
                return Fake_AUD_dLimpiezaRepository;
            }
        }

        public FakeRepository<AUD_dSectores, CDsEntities> Fake_AUD_dSectoresRepository { get; set; }
        IGenericRepository<AUD_dSectores, CDsEntities> IUOW_CDsEntities.AUD_dSectoresRepository
        {
            get
            {
                Fake_AUD_dSectoresRepository = Fake_AUD_dSectoresRepository ??
                    new FakeRepository<AUD_dSectores, CDsEntities>(AUD_dSectores);
                return Fake_AUD_dSectoresRepository;
            }
        }

        public FakeRepository<AUD_dPosiciones, CDsEntities> Fake_AUD_dPosicionesRepository { get; set; }
        IGenericRepository<AUD_dPosiciones, CDsEntities> IUOW_CDsEntities.AUD_dPosicionesRepository
        {
            get
            {
                Fake_AUD_dPosicionesRepository = Fake_AUD_dPosicionesRepository ??
                    new FakeRepository<AUD_dPosiciones, CDsEntities>(AUD_dPosiciones);
                return Fake_AUD_dPosicionesRepository;
            }
        }

        public FakeRepository<AUD_sTiposAuditoria, CDsEntities> Fake_AUD_sTiposAuditoria { get; set; }
        IGenericRepository<AUD_sTiposAuditoria, CDsEntities> IUOW_CDsEntities.AUD_sTiposAuditoria
        {
            get
            {
                Fake_AUD_sTiposAuditoria = Fake_AUD_sTiposAuditoria ??
                    new FakeRepository<AUD_sTiposAuditoria, CDsEntities>(AUD_sTiposAuditoria);
                return Fake_AUD_sTiposAuditoria;
            }
        }

        public IEnumerable<PosicionDeArticulos> AUD_dArticulosyUbicaciones(string valor, int? region)
        {
            var lista = new List<PosicionDeArticulos>()
            {
                new PosicionDeArticulos()
                {
                    Articulo = "Rodri",
                    ETIQUETA = "26",
                    Ubicacion = "BsAs"
                }
            };
            if (valor == lista[0].Articulo)
            {
                return lista;
            }
            else
            {
                if (valor == "exe")
                {
                    throw new Exception();
                }
                return new List<PosicionDeArticulos>();
            }
        }

        public IEnumerable<DatosVolumetricos> AUD_dVolumenDeArticulos(string valor, int? region)
        {
            var lista = new List<DatosVolumetricos>()
            {
                new DatosVolumetricos()
                {
                    Articulo = "Rodri",
                    Caja = "1",
                    CxH = 4.5m,
                    HxP = 3.5m,
                    PosicionPicking = "1",
                    UMD = "1",
                    Unidad = "2",
                    UxB = 3m
                }
            };
            if (valor == lista[0].Articulo)
            {
                return lista;
            }
            else
            {
                if (valor == "exe")
                {
                    throw new Exception();
                }
                return  new List<DatosVolumetricos>();
            }
        }


        public void Save()
        {
            AccessCounterSave++;
        }

        private bool _disposed = false;

        public void Dispose()
        {
            AccessCounterDispose++;
        }
    }
}