﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elestor.Intake.OpenPay.Api.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}
