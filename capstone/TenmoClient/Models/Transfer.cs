using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Models
{
    public class Transfer
    {
        public int TransferId { get; set; }
        public int TransferTypeId { get; set; }
        public int TransferStatusId { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal TransferAmount { get; set; }

        public Transfer(int fromAccountId, int toAccountId, decimal transferAmount)
        {
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
            TransferAmount = transferAmount;
        }
    }

}
