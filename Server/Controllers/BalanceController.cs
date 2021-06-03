using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using Transactions.Server.Service;

namespace Transactions.Server.Controllers
{
    [ApiController]
    [Route("balance-api/v1")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;
        private readonly IMapperService _mapperService;
        private readonly ILogger<BalanceController> _logger;

        public BalanceController(IBalanceService balanceService,
            IMapperService mapperService,
            ILogger<BalanceController> logger)
        {
            _mapperService = mapperService;
            _balanceService = balanceService;
            _logger = logger;
        }

        [HttpGet("accounts/{accountId}")]
        public ActionResult GetBalance([FromRoute] long accountId, [Required][FromQuery(Name = "date")] DateTime dateTime)
        {
            try
            {
                return Ok(_mapperService.ToBalanceResponse(_balanceService.GetBalance(accountId, dateTime.Date)));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while creating balance");
                return BadRequest();
            }
        }
    }
}
