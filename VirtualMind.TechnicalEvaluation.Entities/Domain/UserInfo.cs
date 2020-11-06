using System;
using System.Collections.Generic;

namespace VirtualMind.TechnicalEvaluation.Entities.Domain
{
    public class UserInfo
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthdate { get; set; }
        public int age { get; set; }
        public string dni { get; set; }
        public DateTime ts { get; set; }

        public virtual IList<UserTransac> UserTransaction { get; set; }
    }
}
