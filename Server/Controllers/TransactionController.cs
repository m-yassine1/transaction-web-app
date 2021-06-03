using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Transactions.Server.Service;
using Transactions.Shared.Model;

namespace Transactions.Server.Controllers
{
    [ApiController]
    [Route("transaction-api/v1")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;
        private readonly IMapperService _mapperService;

        public TransactionController(ITransactionService transactionService,
            IMapperService mapperService,
            ILogger<TransactionController> logger)
        {
            _mapperService = mapperService;
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpPost("transactions")]
        public ActionResult CreateTransaction(TransactionRequest request)
        {
            try
            {
                _transactionService.CreateTransaction(_mapperService.ToTransactionDto(request));
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while creating transaction");
                return BadRequest();
            }
        }

        [HttpPatch("transactions/{id}")]
        public ActionResult UpdateTransaction([FromRoute] long id, TransactionRequest request)
        {
            try
            {
                _transactionService.UpdateTransaction(id, _mapperService.ToTransactionDto(request));
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while updating transaction");
                return BadRequest();
            }
        }

        [HttpDelete("accounts/{id}")]
        public ActionResult DeleteTransaction([FromRoute] long id)
        {
            try
            {
                _transactionService.DeleteTransaction(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while deleting transasction");
                return BadRequest();
            }
        }

        [HttpGet("transactions/{id}")]
        public ActionResult GetTransaction(long id)
        {
            try
            {
                return Ok(_transactionService.GetTransaction(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while getting transaction");
                return BadRequest();
            }
        }

        [HttpGet("transactions/{accountId}")]
        public ActionResult GetTransactions(long accountId)
        {
            try
            {
                return Ok(_transactionService.GetTransactions(accountId));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while getting transactions");
                return BadRequest();
            }
        }
    }
}
