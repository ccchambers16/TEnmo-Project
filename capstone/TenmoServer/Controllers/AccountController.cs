
using System.Collections.Generic;
using TenmoServer.Models;
using TenmoServer.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TenmoServer.Controllers
{
    [Route("accounts")]
    [ApiController]
    [Authorize]
    //will need to change the authorizationn

    public class AccountController : ControllerBase 
    {
        private readonly IAccountSqlDao accountSqlDao;

        public AccountController(IAccountSqlDao accountSqlDao)  
            //remember: leverage dependency injection here.  
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

        [HttpGet()]
        public ActionResult<List<Account>> GetAllAccounts()
        {
            List<Account> accounts = accountSqlDao.GetAllAccounts();
            if (accounts != null)
            {
                return Ok(accounts); 
            }
            else
            {
                return NotFound();
            }
        }

    }
}
