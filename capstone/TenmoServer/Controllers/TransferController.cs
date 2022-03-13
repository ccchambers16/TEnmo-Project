
using System.Collections.Generic;
using TenmoServer.Models;
using TenmoServer.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TenmoServer.Controllers
{
    [Route("transfers")]
    [ApiController]
    [Authorize]
    //will need to change the authorizationn

    public class TransferController : ControllerBase
    {

        private readonly ITransferSqlDao transferSqlDao;

        public TransferController(ITransferSqlDao transferSqlDao)
        //remember: leverage dependency injection here.  
        {
            this.transferSqlDao = transferSqlDao;
        }

        [HttpGet("{id}")]
        public ActionResult<Transfer> GetTransfer(int id)
        {
            Transfer transfer = transferSqlDao.GetTransfer(id);
            if (transfer != null)
            {
                return Ok(transfer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("filter")]
        public ActionResult<List<Transfer>> GetAllTransfers(int accountId)
        {
           
            List<Transfer> transfers = transferSqlDao.GetAllTransfers(accountId);
            if (transfers != null)
            {
                return Ok(transfers);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public ActionResult<Transfer> SendTransfer(Transfer transfer)
        {
            Transfer added = transferSqlDao.SendTransfer(transfer);
            return Created($"/transfers/{added.TransferId}", added);
        }


    }
}
