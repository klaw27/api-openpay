using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elestor.Intake.OpenPay.Api.Models
{
    public class CardToken
    {
        public string id { get; set; } = string.Empty;
        public string token_id  { get; set; } = string.Empty;
        public string device_session_id { get; set; } = string.Empty;     
    }
}
