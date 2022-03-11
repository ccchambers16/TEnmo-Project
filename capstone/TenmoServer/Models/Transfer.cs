using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TenmoServer.Models
{
    public class Transfer
    {
        //[Range(3000, double.PositiveInfinity, ErrorMessage = "The field `TransferId` must not be negative.")]
        public int TransferId { get; set; }

        [Range(1, 2, ErrorMessage = "The field `TransferTypeId` must not be negative.")]
        public int TransferTypeId { get; set; }

        public int TransferStatusId { get; set; }

        [Range(2000, double.PositiveInfinity, ErrorMessage = "The field 'AccountId' must be a valid id.")]
        public int FromAccountId { get; set; }

        [Range(2000, double.PositiveInfinity, ErrorMessage = "The field 'ToAccountId' must be a valid id.")]
        public int ToAccountId { get; set; }

        [Range(0.00, double.PositiveInfinity, ErrorMessage = "The field 'TransferAmount' must not be negative.")]
        public decimal TransferAmount { get; set; }

    }
}
