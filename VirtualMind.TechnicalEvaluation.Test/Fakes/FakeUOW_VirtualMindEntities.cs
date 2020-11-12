using System;
using System.Collections.Generic;
using VirtualMind.TechnicalEvaluation.Dal;
using VirtualMind.TechnicalEvaluation.Dal.Interface;

namespace VirtualMind.TechnicalEvaluation.Test.Fakes
{
    public class FakeUOW_VirtualMindEntities : IDisposable, IUOW_VirtualMindDb
    {
        public FakeUOW_VirtualMindEntities()
        {
            AccessCounterSave = 0;
            AccessCounterDispose = 0;
        }

        public IList<UserTransaction> UserTransaction { get; set; }
        public IList<UserInformation> UserInformation { get; set; }

        public int AccessCounterSave { get; private set; }
        public int AccessCounterDispose { get; private set; }

        public FakeRepository<UserTransaction, VirtualMindEntities> Fake_UserTransactionRepository { get; set; }
        IGenericRepository<UserTransaction, VirtualMindEntities> IUOW_VirtualMindDb.UserTransactionRepository
        {
            get
            {
                Fake_UserTransactionRepository = Fake_UserTransactionRepository ??
                    new FakeRepository<UserTransaction, VirtualMindEntities>(UserTransaction);
                return Fake_UserTransactionRepository;
            }
        }

        public FakeRepository<UserInformation, VirtualMindEntities> Fake_UserInformationRepository { get; set; }
        IGenericRepository<UserInformation, VirtualMindEntities> IUOW_VirtualMindDb.UserInformationRepository
        {
            get
            {
                Fake_UserInformationRepository = Fake_UserInformationRepository ??
                    new FakeRepository<UserInformation, VirtualMindEntities>(UserInformation);
                return Fake_UserInformationRepository;
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