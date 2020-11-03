using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMind.TechnicalEvaluation.Test.Fakes;
using VirtualMind.TechnicalEvaluation.Biz;
using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Entities.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VirtualMind.TechnicalEvaluation.Test.Biz
{
    [TestClass]
    public class DatosVolumetricosBizTest
    {
        private DatosVolumetricosBiz _servicio;
        private FakeUOW_CDsEntities _FakeUOW_CDsDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_CDsDB = new FakeUOW_CDsEntities();
            _servicio = new DatosVolumetricosBiz(_FakeUOW_CDsDB);
        }
        [TestMethod]
        public void volumenDeArticulosTest_OK()
        {
            var result = _servicio.volumenDeArticulos("Rodri", 1);
            Assert.AreNotEqual(null,result);
        }
        [TestMethod]
        public void volumenDeArticulosTest_NotFound()
        {
            var result = _servicio.volumenDeArticulos("Test", 1);
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void volumenDeArticulosTest_Exe()
        {
            try
            {
                var result = _servicio.volumenDeArticulos("exe", 1);
                Assert.AreNotEqual(null, result);
            }
            catch (Exception ex)
            {
               Assert.AreEqual(typeof(Exception),ex.GetType());
            }

        }
    }
}
