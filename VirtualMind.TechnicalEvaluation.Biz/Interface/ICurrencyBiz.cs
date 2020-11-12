using VirtualMind.TechnicalEvaluation.Entities.Domain;

namespace VirtualMind.TechnicalEvaluation.Biz.Interface
{
    public interface ICurrencyBiz
    {
        ConvertionDetail GetCurrency(int isoCurrency);
        string BuyCurrencies(int idUser, string amount, int iso);
    }
}
