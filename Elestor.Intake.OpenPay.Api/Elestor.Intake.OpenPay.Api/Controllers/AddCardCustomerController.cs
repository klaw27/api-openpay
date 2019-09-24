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

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/card")]
    //[Authorize]
    public class AddCardCustomerController : Controller
    {
        private readonly ILog _log;

        public AddCardCustomerController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        [HttpPost("add")]

        public IActionResult AddCardCustomer([FromBody] CardToken cardData)
        {
            if (cardData == null)
            {
                _log.Error(nameof(cardData).ToString() + "Cannot be null.");
                throw new ArgumentNullException(nameof(cardData), "Cannot be null.");
            }

            Card cardCreated = null;

            try
            {
                _log.Information("Adding Card to customer.");

                var openpayAPI = OpenPayHandler.GetOpenPayInstance();

                Card request = new Card();
                request.TokenId = cardData.token_id;
                request.DeviceSessionId = cardData.device_session_id;

                cardCreated = openpayAPI.CardService.Create(cardData.id, request);

            }
            catch (Exception ex)
            {
                _log.Error("Exception while adding card." + ex.ToString());
                return NotFound();
            }

            return Ok(cardCreated);
        }

    }
}