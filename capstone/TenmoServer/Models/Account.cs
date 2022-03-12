using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TenmoServer.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        //there was no auto-incrementing function in the SQL lecture files.  

        [Range(1000, double.PositiveInfinity, ErrorMessage = "The field 'UserId' must be a valid id.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field `Username` must not be blank.")]
        public string Username { get; set; }

        [Range(0.00, double.PositiveInfinity, ErrorMessage = "The field `Balance` must not be negative.")]
        public double Balance { get; set; }

    }
}
