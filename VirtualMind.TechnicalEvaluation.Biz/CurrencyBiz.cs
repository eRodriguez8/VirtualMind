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

        public string BuyCurrencies(int idUser, string amount, int iso)
        {
            var factory = GetFactory(iso);
            var currency = factory.GetDetail();
            var amountToBuy = Double.Parse(amount, new CultureInfo("en-US")) / currency.sale;

            if (IsAValidAmount(amountToBuy, iso, idUser))
            {
                _uOWDB.UserTransactionRepository.Insert(
                    new UserTransac()
                    {
                        idUsuario = idUser,
                        amount = amountToBuy.ToString(),
                        isoCurrency = iso.ToString(),
                        price = currency.sale.ToString(),
                        ts = DateTime.Now
                    }.ToEntity());

                _uOWDB.Save();
                return "OK";
            }
            else
            {
                throw new ConflictException("Monto no permitido");
            }
        }

        private bool IsAValidAmount(double amountToBuy, int iso, int id)
        {
            var validate = true;
            var amountStore = getAmountBought(id, iso);
            switch(iso)
            {
                case (int)Currency.USD:
                    validate = amountToBuy > 200 ? false : (amountToBuy + amountStore) > 200 ? false : true;
                    break;
                case (int)Currency.BRL:
                    validate = amountToBuy > 300 ? false : (amountToBuy + amountStore) > 300 ? false : true;
                    break;
            }

            return validate;
        }

        private double getAmountBought(int id, int iso)
        {
            var user = _uOWDB.UserTransactionRepository.Get(x => x.idUsuario == id).AsEnumerable().ToDomain();
            var sum = user.Where(x => x.isoCurrency == iso.ToString() && x.ts.Month == DateTime.Now.Month).Sum(x => Double.Parse(x.amount));
            return sum;
        }
    }
}
