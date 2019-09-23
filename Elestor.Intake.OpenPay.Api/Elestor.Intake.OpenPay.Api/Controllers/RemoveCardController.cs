using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elestor.Intake.OpenPay.Api.Handlers;
using Elestor.Intake.OpenPay.Api.Log;
using Elestor.Intake.OpenPay.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/card")]
    //[Authorize]
    public class RemoveCardController : Controller
    {
        private readonly ILog _log;

        public RemoveCardController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult RemoveCardCustomer([FromBody] DeleteCard DeleteCard)
        {

            
            if (DeleteCard == null)
            {
                _log.Error(nameof(DeleteCard).ToString() + "Cannot be null.");
                throw new ArgumentNullException(nameof(DeleteCard), "Cannot be null.");
            }

  
            try
            {
                _log.Information("Deleting Card to customer.");

                var openpayAPI = OpenPayHandler.GetOpenPayInstance();
                openpayAPI.CardService.Delete(DeleteCard.customer_id, DeleteCard.card_id);

            }
            catch (Exception ex)
            {
                _log.Error("Exception while deleting card." + ex.ToString());
                return NotFound();
            }

            return Ok();
        }
    }
}