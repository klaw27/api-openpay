﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elestor.Intake.OpenPay.Api.Models
{
    public class OktaSettings
    {
        public string TokenUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
