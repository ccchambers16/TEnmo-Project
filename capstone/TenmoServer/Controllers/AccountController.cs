
using System.Collections.Generic;
using TenmoServer.Models;
using TenmoServer.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TenmoServer.Controllers
{
    [Route("account")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase 
    {
        private readonly IAccountSqlDao accountSqlDao;

        public AccountController(IAccountSqlDao accountSqlDao)
        {
            this.accountSqlDao = accountSqlDao;
        }
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccounts(int id)
        {
            Account account = accountSqlDao.GetAccount(id);
            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
