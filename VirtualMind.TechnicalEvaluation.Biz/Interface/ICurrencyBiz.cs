using VirtualMind.TechnicalEvaluation.Entities.Domain;

namespace VirtualMind.TechnicalEvaluation.Biz.Interface
{
    public interface ICurrencyBiz
    {
        ConvertionDetail GetCurrency(int isoCurrency);
    }
}
