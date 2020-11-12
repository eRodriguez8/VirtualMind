using System;
using System.Collections.Generic;
using VirtualMind.TechnicalEvaluation.Biz;
using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualMind.TechnicalEvaluation.Biz.Exceptions;

namespace VirtualMind.TechnicalEvaluation.Test.Biz
{
    [TestClass]
    public class CurrencyBizTest
    {
        private CurrencyBiz _servicio;
        private FakeUOW_VirtualMindEntities _FakeUOW_VirtualMindDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_VirtualMindDB = new FakeUOW_VirtualMindEntities();
            _FakeUOW_VirtualMindDB.UserInformation = UserList();
            _FakeUOW_VirtualMindDB.UserTransaction = new List<UserTransaction>();
            _servicio = new CurrencyBiz(_FakeUOW_VirtualMindDB);
        }

        private static List<UserInformation> UserList()
        {
            return new List<UserInformation>()
            {
                new UserInformation()
                {
                    id = 1,
                    age = 1,
                    birthdate = DateTime.Now,
                    dni = "12345678",
                    firstname = "Emanuel",
                    lastname = "Rodriguez",
                    ts = DateTime.Now,
                    UserTransaction = null
                }
            };
        }

        [TestMethod]
        public void GetCurrencyTest_OK()
        {
            var result = _servicio.GetCurrency(986);

            Assert.AreEqual(typeof(string), result.date.GetType());
            Assert.AreEqual(typeof(double), result.buy.GetType());
            Assert.AreEqual(typeof(double), result.sale.GetType());
        }

        [TestMethod]
        public void GetCurrencyTest_IsoFail()
        {
            try
            {
                var result = _servicio.GetCurrency(-1);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NotFoundException), e.GetType());
            }
        }

        [TestMethod]
        public void GetFactory_OK()
        {
            var result = _servicio.BuyCurrencies(1, "1000", 840);

            Assert.AreEqual(1, _FakeUOW_VirtualMindDB.AccessCounterSave, "FakeUOW_VirtualMindEntities.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_VirtualMindDB.AccessCounterDispose, "FakeUOW_VirtualMindEntities.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_VirtualMindDB.Fake_UserTransactionRepository.AccessCounterInsert, "FakeUOW_VirtualMindEntities.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_VirtualMindDB.Fake_UserTransactionRepository.AccessCounterGet, "FakeUOW_VirtualMindEntities.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_VirtualMindDB.Fake_UserTransactionRepository.AccessCounterQuery, "FakeUOW_VirtualMindEntities.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_VirtualMindDB.Fake_UserTransactionRepository.AccessCounterUpdate, "FakeUOW_VirtualMindEntities.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_VirtualMindDB.Fake_UserTransactionRepository.AccessCounterDelete, "FakeUOW_VirtualMindEntities.AccessCounterDelete");
        }

        [TestMethod]
        public void InsertTransacctionTest_IsoFail()
        {
            try
            {
                var result = _servicio.BuyCurrencies(-1, null, -1);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NotFoundException), e.GetType());
            }
        }

        [TestMethod]
        public void InsertTransacctionTest_AmountFail()
        {
            try
            {
                var result = _servicio.BuyCurrencies(1, "100000", 986);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(ConflictException), e.GetType());
            }
        }
    }

}
