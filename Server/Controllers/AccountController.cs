using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Transactions.Server.Service;
using Transactions.Shared.Model;

namespace Transactions.Server.Controllers
{
    [ApiController]
    [Route("account-api/v1")]
    public class AccountController : ControllerBase
    {
        private readonly IMapperService _mapperService;
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService,
            IMapperService mapperService,
            ILogger<AccountController> logger)
        {
            _mapperService = mapperService;
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet("accounts")]
        public ActionResult GetAccounts()
        {
            try
            {
                return Ok(_mapperService.ToAccountsResponse(_accountService.GetAccounts()));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while creating account");
                return BadRequest();
            }
        }

        [HttpPost("accounts")]
        public ActionResult CreateAccount(AccountRequest request)
        {
            try
            {
                _accountService.CreateAccount(_mapperService.ToAccountDto(request));
                return Ok();
            } catch(Exception e) {
                _logger.LogError(e, "Error while creating account");
                return BadRequest();
            }
        }

        [HttpPatch("accounts/{id}")]
        public ActionResult UpdateAccount([FromRoute] long id, AccountRequest request)
        {
            try
            {
                _accountService.UpdateAccount(id, _mapperService.ToAccountDto(request));
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while updating account");
                return BadRequest();
            }
        }

        [HttpDelete("accounts/{id}")]
        public ActionResult DeleteAccount([FromRoute] long id)
        {
            try
            {
                _accountService.DeleteAccount(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while deleting account");
                return BadRequest();
            }
        }

        [HttpGet("accounts/{id}")]
        public ActionResult GetAccount([FromRoute] long id)
        {
            try
            {
                return Ok(_mapperService.ToAccountResponse(_accountService.GetAccount(id)));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while getting account");
                return BadRequest();
            }
        }
    }
}
