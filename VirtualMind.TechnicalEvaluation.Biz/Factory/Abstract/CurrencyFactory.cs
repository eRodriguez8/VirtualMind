using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using VirtualMind.TechnicalEvaluation.Entities.Domain;
using VirtualMind.TechnicalEvaluation.Entities.Domain.Enums;

namespace VirtualMind.TechnicalEvaluation.Biz.Factory.Abstract
{
    public abstract class CurrencyFactory
    {
        public abstract ConvertionDetail GetDetail();
    }
}
