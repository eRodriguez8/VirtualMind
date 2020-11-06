using System;
using System.Linq;
using System.Globalization;
using VirtualMind.TechnicalEvaluation.Biz.Factory;
using VirtualMind.TechnicalEvaluation.Biz.Helpers;
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
        public CurrencyBiz(IUOW_VirtualMindDb uOWCdsDB) : base(uOWCdsDB)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public ConvertionDetail GetCurrency(int isoCurrency)
        {
            var factory = GetFactory(isoCurrency);
            return factory.GetDetail();        
        }

        private CurrencyFactory GetFactory(int isoCurrency)
        {
            CurrencyFactory factory;

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

            return factory;
        }

        public ConvertionDetail BuyCurrencies(int idUser, string amount, int iso)
        {
            var factory = GetFactory(iso);
            var currency = factory.GetDetail();
            var amountToBuy = Double.Parse(amount, new CultureInfo("en-US")) / currency.sale;

            // valido el monto
            if (IsAValidAmount(amountToBuy, iso, idUser))
            {
                // llamo al servicio
                return new ConvertionDetail();
            }

            return new ConvertionDetail()
            {
                buy = 100,
                sale = 100,
                date = "100"
            };
        }

        private bool IsAValidAmount(double amountToBuy, int iso, int id)
        {
            var validate = true;
            var amountStore = getAmountBought(id);
            switch(iso)
            {
                case (int)Currency.USD:
                    validate = amountToBuy > 200 ? false : (amountToBuy + amountStore) > 200 ? false : true;
                    break;
                case (int)Currency.BRL:
                    validate = amountToBuy > 300 ? false : (amountToBuy + amountStore) > 300 ? false : true;
                    break;
                default:
                    throw new NotFoundException("Iso no valida");
            }

            return validate;
        }

        private double getAmountBought(int id)
        {
            var value = _uOWDB.UserTransactionRepository.Get(x => x.idUsuario == id && x.ts.Month == DateTime.Now.Month).AsEnumerable().ToDomain().FirstOrDefault();
            return Double.Parse(value.amount, new CultureInfo("en-US"));
        }
    }
}
