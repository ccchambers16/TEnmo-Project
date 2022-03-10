using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TenmoServer.Models
{
    public class Transfer
    {
        [Range(3000, double.PositiveInfinity, ErrorMessage = "The field `TransferId` must not be negative.")]
        int TransferId { get; set; }
        [Range(1000, double.PositiveInfinity, ErrorMessage = "The field 'UserId' must be a valid id.")]

        int SenderUserId { get; set; }
        [Range(1,2, ErrorMessage = "The field `Balance` must not be negative.")]
        int TransferTypeId { get; set; }

        int TransferStatusId { get; set; }

        [Range(2000, double.PositiveInfinity, ErrorMessage = "The field 'AccountId' must be a valid id.")]

        int FromAccountId { get; set; }
        [Range(0.00, double.PositiveInfinity, ErrorMessage = "The field `FromBalance` must not be negative.")]
        decimal FromBalance { get; set; }
        [Range(0.00, double.PositiveInfinity, ErrorMessage = "The field 'TransferAmount' must not be negative.")]
        decimal TransferAmount { get; set; }

        [Range(1000, double.PositiveInfinity, ErrorMessage = "The field 'ToUserId' must be a valid id.")]

        int ToUserId { get; set; }
        [Range(2000, double.PositiveInfinity, ErrorMessage = "The field 'ToAccountId' must be a valid id.")]

        int ToAccountId { get; set; }
        [Range(0.00, double.PositiveInfinity, ErrorMessage = "The field `ToBalance` must not be negative.")]
        decimal ToBalance { get; set; }


    }
}
