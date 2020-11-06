using VirtualMind.TechnicalEvaluation.Dal.Interface;

namespace VirtualMind.TechnicalEvaluation.Biz
{
    public class BaseBusiness
    {
        protected IUOW_VirtualMindDb _uOWDB { get; }

        protected BaseBusiness(IUOW_VirtualMindDb uOWDB)
        {
            _uOWDB = uOWDB;
        }
    }
}
