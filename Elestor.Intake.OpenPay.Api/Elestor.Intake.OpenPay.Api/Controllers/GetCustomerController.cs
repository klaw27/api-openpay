using Elestor.Intake.OpenPay.Api.Handlers;
using Elestor.Intake.OpenPay.Api.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Openpay.Entities;
using System;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    //[Authorize]
    public class GetCustomerController : Controller
    {
        private readonly ILog _log;

        public GetCustomerController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        //[Authorize]
        [HttpPost("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCustomer([FromBody] string customer_id)
        {
            Customer customer = null;

            try
            {
                _log.Information("Getting Customer.");

                var openpayAPI = OpenPayHandler.GetOpenPayInstance();

                customer = openpayAPI.CustomerService.Get(customer_id);
            }
            catch (Exception ex)
            {
                _log.Error("Exception while getting customer." + ex.ToString());
                return NotFound();
            }

            return Ok(customer);
        }
    }
}