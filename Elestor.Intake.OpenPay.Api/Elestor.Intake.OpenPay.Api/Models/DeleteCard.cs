using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elestor.Intake.OpenPay.Api.Models
{
    public class DeleteCard
    {
        public string customer_id { get; set; } = string.Empty;
        public string card_id { get; set; } = string.Empty;
    }
}
