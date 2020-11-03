using VirtualMind.TechnicalEvaluation.Biz.Factory;
using VirtualMind.TechnicalEvaluation.Biz.Interface;
using VirtualMind.TechnicalEvaluation.Dal.Interface;
using VirtualMind.TechnicalEvaluation.Biz.Exceptions;
using VirtualMind.TechnicalEvaluation.Entities.Domain;
using VirtualMind.TechnicalEvaluation.Biz.Factory.Abstract;
using VirtualMind.TechnicalEvaluation.Entities.Domain.Enums;

namespace VirtualMind.TechnicalEvaluation.Biz
{
    public class CurrencyBiz : BaseBusiness, ICurrencyBiz
    {
        private CurrencyFactory factory;

        public CurrencyBiz(IUOW_CDsEntities uOWCdsDB) : base(uOWCdsDB)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public ConvertionDetail GetCurrency(int isoCurrency)
        {
            switch (isoCurrency)
            {
                case (int)Currency.USD:
                    factory = new DolarFactory();
                    break;
                case (int)Currency.BRL:
                    factory = new RealFactory();
                    break;
                default:
                    throw new NotFoundException("Iso no valida");
            }

            return factory.GetDetail();
        }
    }
}
