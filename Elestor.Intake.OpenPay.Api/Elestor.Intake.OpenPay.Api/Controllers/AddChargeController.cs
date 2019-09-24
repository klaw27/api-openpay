using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Elestor.Intake.OpenPay.Api.Handlers;
using Elestor.Intake.OpenPay.Api.Log;
using Microsoft.AspNetCore.Authorization;
using Openpay.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Elestor.Intake.OpenPay.Api.Models;
using Openpay.Entities.Request;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/charge")]
    //[Authorize]
    public class AddChargeController : Controller
    {
        private readonly ILog _log;

        public AddChargeController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        [HttpPost("add")]

        public IActionResult AddCharge([FromBody] ChargeToken ChargeData)
        {
            if (ChargeData == null)
            {
                _log.Error(nameof(ChargeData).ToString() + "Cannot be null.");
                throw new ArgumentNullException(nameof(ChargeData), "Cannot be null.");
            }

            Charge charge = null;
            ChargeRequest request = new ChargeRequest();

            try
            {
                _log.Information("Adding charge to customer.");

                var openpayAPI = OpenPayHandler.GetOpenPayInstance();
                request.Method = ChargeData.Method;
                request.SourceId = ChargeData.SourceId;
                request.Amount = new Decimal(ChargeData.Amount);
                request.Description = ChargeData.Description;
                request.DeviceSessionId = ChargeData.DeviceSessionId;
                //request.Customer = customerCargo;

                charge = openpayAPI.ChargeService.Create(ChargeData.CustomerId,request);

            }


            
            catch (Exception ex)
            {
                _log.Error("Exception while adding charge." + ex.ToString());
                return NotFound();
            }

            return Ok(charge);
        }

    }
}