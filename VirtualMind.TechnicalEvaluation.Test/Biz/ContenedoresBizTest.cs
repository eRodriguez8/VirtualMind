using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualMind.TechnicalEvaluation.Test.Fakes;
using VirtualMind.TechnicalEvaluation.Biz;
using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Entities.Domain;

namespace VirtualMind.TechnicalEvaluation.Test.Biz
{
    [TestClass]
    public class ContenedoresBizTest
    {
        private CurrencyBiz _servicio;
        private FakeUOW_CDsEntities _FakeUOW_CDsDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_CDsDB = new FakeUOW_CDsEntities();
            _FakeUOW_CDsDB.AUD_dSectores = SectoresList();
            _FakeUOW_CDsDB.AUD_dIncidencias = IncidenciasList();
            _FakeUOW_CDsDB.AUD_dContenedores = new List<AUD_dContenedores>();
            _servicio = new CurrencyBiz(_FakeUOW_CDsDB);
        }

        private static List<AUD_dSectores> SectoresList()
        {
            return new List<AUD_dSectores>()
            {
                new AUD_dSectores()
                {
                    id = 1,
                    AUD_dContenedores = new List<AUD_dContenedores>(),
                    descripcion = "Test",
                    ts = DateTime.Now,
                    usuario = "Rodri Test"
                }
            };
        }

        private static List<AUD_dIncidencias> IncidenciasList()
        {
            return new List<AUD_dIncidencias>()
            {
                new AUD_dIncidencias()
                {
                    AUD_dContenedores = new List<AUD_dContenedores>(),
                    AUD_dLimpieza = new List<AUD_dLimpieza>(),
                    AUD_dPosiciones = new List<AUD_dPosiciones>(),
                    AUD_sTiposAuditoria = new AUD_sTiposAuditoria(),
                    id = 1,
                    idTipoAuditoria = null,
                    incidencia = "Test",
                    ts = DateTime.Now,
                    usuario = "Rodri"
                }
            };
        }

        [TestMethod]
        public void InsertContenedorTest_OK()
        {
            var result = _servicio.InsertContenedor(new ConvertionDetail()
            {
                idregion = 1,
                etiqueta = "a",
                codigoarticulo = "b",
                idAuditoriaSector = 1,
                idAuditoriaIncidencia = 1,
                legajo = "3872",
                fecharegistro = DateTime.Now
            });
            Assert.AreEqual(1, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsEntities.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsEntities.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_CDsDB.Fake_AUD_dContenedoresRepository.AccessCounterInsert, "Fake_AUD_dContenedoresRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_CDsDB.Fake_AUD_dContenedoresRepository.AccessCounterGet, "Fake_AUD_dContenedoresRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.Fake_AUD_dContenedoresRepository.AccessCounterQuery, "Fake_AUD_dContenedoresRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.Fake_AUD_dContenedoresRepository.AccessCounterUpdate, "Fake_AUD_dContenedoresRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.Fake_AUD_dContenedoresRepository.AccessCounterDelete, "Fake_AUD_dContenedoresRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void InsertContenedorTest_exep()
        {
            try
            {
                _FakeUOW_CDsDB.AUD_dContenedores = null;
                var result = _servicio.InsertContenedor(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NullReferenceException), e.GetType());
            }
        }
    }

}
