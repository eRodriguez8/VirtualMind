using System.Collections.Generic;

namespace VirtualMind.TechnicalEvaluation.Dal.Interface
{
    public interface IUOW_VirtualMindDb
    {
        IGenericRepository<UserInformation, VirtualMindEntities> UserInformationRepository { get; }
        IGenericRepository<UserTransaction, VirtualMindEntities> UserTransactionRepository { get; }
        void Dispose();
        void Save();
    }
}
