using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Elestor.Intake.OpenPay.Api.Handlers;
using Elestor.Intake.OpenPay.Api.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Openpay.Entities;
using Newtonsoft.Json;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/card")]
    //[Authorize]
    public class GetCarsCustomerController : Controller
    {
        private readonly ILog _log;
        public GetCarsCustomerController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        //[Authorize]
        [HttpPost("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetListCars([FromBody] string customer_id)
        {
            List<Card> cards = null;

            try
            {
                _log.Information("Getting List Cards.");

                var openpayAPI = OpenPayHandler.GetOpenPayInstance();
                cards = openpayAPI.CardService.List(customer_id, null);

            }
            catch (Exception ex)
            {
                _log.Error("Exception while getting Cards." + ex.ToString());
                return NotFound();
            }

            return Ok(cards);
        }

    }
}