using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Openpay.Entities;

namespace Elestor.Intake.OpenPay.Api.Models
{
    public class ChargeToken
    {
        public string Method { get; set; } = string.Empty;
        public string SourceId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string DeviceSessionId { get; set; } = string.Empty;
        public int Amount { get; set; } 
        public string CustomerId { get; set; } = string.Empty;
    }
}
