using Elestor.Intake.OpenPay.Api.Handlers;
using Elestor.Intake.OpenPay.Api.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Openpay.Entities;
using System;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class AddCustomerController : Controller
    {
        private readonly ILog _log;

        public AddCustomerController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCustomer([FromBody] Customer customer)

        {
            if (customer == null)
            {
                _log.Error(nameof(customer).ToString() + "Cannot be null.");
                throw new ArgumentNullException(nameof(customer), "Cannot be null.");
            }

            Customer customerCreated = null;

            try
            {
                _log.Information("Adding Customer.");
                var openpayAPI = OpenPayHandler.GetOpenPayInstance();
                customerCreated = openpayAPI.CustomerService.Create(customer);


            }
            catch (Exception ex)
            {
                _log.Error("Exception while adding customer." + ex.ToString());
                return NotFound();
            }

            return Ok(customerCreated);
        }
    }
}