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
    public class DolarFactory : CurrencyFactory
    {
        public DolarFactory() { }

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
                buy = Double.Parse(wclients[0], new CultureInfo("en-US")),
                sale = Double.Parse(wclients[1], new CultureInfo("en-US")),
                date = wclients[2]
            };
        }
    }
}
