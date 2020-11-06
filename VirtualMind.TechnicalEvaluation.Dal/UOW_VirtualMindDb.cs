using System;
using log4net;
using VirtualMind.TechnicalEvaluation.Dal.Interface;

namespace VirtualMind.TechnicalEvaluation.Dal.UnitOfWorks
{
    /// <summary>
    /// The unit of work class serves one purpose: to make sure that when you use multiple repositories,
    /// they share a single database context.
    /// </summary>
    public class UOW_VirtualMindDb : IDisposable, IUOW_VirtualMindDb
    {
        private readonly VirtualMindEntities _virtualMinDBContext;
        private readonly ILog Logger;

        public UOW_VirtualMindDb(VirtualMindEntities virtualMinDBContext)
        {
            _virtualMinDBContext = virtualMinDBContext;
            Logger = LogManager.GetLogger(GetType());
            _virtualMinDBContext.Database.Log = (dblog => Logger.Debug(dblog));
        }

        private IGenericRepository<UserInformation, VirtualMindEntities> _UserInformationRepository;
        public IGenericRepository<UserInformation, VirtualMindEntities> UserInformationRepository
        {
            get
            {
                if (_UserInformationRepository == null)
                {
                    _UserInformationRepository = new GenericRepository<UserInformation, VirtualMindEntities>(_virtualMinDBContext);
                }
                return _UserInformationRepository;
            }
        }

        private IGenericRepository<UserTransaction, VirtualMindEntities> _UserTransactionRepository;
        public IGenericRepository<UserTransaction, VirtualMindEntities> UserTransactionRepository
        {
            get
            {
                if (_UserTransactionRepository == null)
                {
                    _UserTransactionRepository = new GenericRepository<UserTransaction, VirtualMindEntities>(_virtualMinDBContext);
                }
                return _UserTransactionRepository;
            }
        }

        public void Save()
        {
            _virtualMinDBContext.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _virtualMinDBContext.Dispose();
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