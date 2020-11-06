using System;

namespace VirtualMind.TechnicalEvaluation.Entities.Domain
{
    public class UserTransac
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public string amount { get; set; }
        public string isoCurrency { get; set; }
        public string price { get; set; }
        public DateTime ts { get; set; }

        public virtual UserInfo UserInformation { get; set; }
    }
}
