using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Transfer
    {
        int TransferId { get; set; }

        int SenderUserId { get; set; }

        int TransferTypeId { get; set; }

        int TransferStatusId { get; set; }


        int FromAccountId { get; set; }

        decimal FromBalance { get; set; }

        decimal TransferAmount { get; set; }

        
        int ToUserId { get; set; }

        int ToAccountId { get; set; }

        decimal ToBalance { get; set; }


    }
}
