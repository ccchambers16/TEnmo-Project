using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public double Balance { get; set; }


        public Account(int userId, string username, double balance)
        {
            UserId = userId;
            Username = username;
            Balance = balance;
        }
        public Account() { }

        public bool IsValid
        {
            get
            {
                return Username != null && Balance >= 0;

            }
        }

        
    }
}
