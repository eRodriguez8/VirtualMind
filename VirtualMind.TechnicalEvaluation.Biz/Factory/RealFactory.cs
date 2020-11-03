using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using VirtualMind.TechnicalEvaluation.Entities.Domain;
using VirtualMind.TechnicalEvaluation.Biz.Factory.Abstract;

namespace VirtualMind.TechnicalEvaluation.Biz.Factory
{
    public class RealFactory : CurrencyFactory
    {
        public RealFactory() { }

        public override ConvertionDetail GetDetail()
        {
            var client = new WebClient();
            client.UseDefaultCredentials = true;
            var url = ConfigurationManager.AppSettings["apiDolar"];
            var text = client.DownloadString(url);

            var wclients = JsonConvert.DeserializeObject<List<string>>(text);         

            client.Dispose();

            return new ConvertionDetail()
            {
                buy = float.Parse(wclients[0], new CultureInfo("en-US")) / 4,
                sale = float.Parse(wclients[1], new CultureInfo("en-US")) / 4,
                date = wclients[2]
            };
        }
    }
}
