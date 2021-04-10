using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardId { get; set; }
        public string NameOnTheCart{ get; set; }
        public int CardNumber { get; set; }
        public int SecurityNumber { get; set; }
        public DateTime CardExpiryDate { get; set; }

    }
}