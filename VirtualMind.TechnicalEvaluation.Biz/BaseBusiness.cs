using VirtualMind.TechnicalEvaluation.Dal.Interface;

namespace VirtualMind.TechnicalEvaluation.Biz
{
    public class BaseBusiness
    {
        protected IUOW_CDsEntities _uOWCdsDB { get; }

        protected BaseBusiness(IUOW_CDsEntities uOWCdsDB)
        {
            _uOWCdsDB = uOWCdsDB;
        }
    }
}
