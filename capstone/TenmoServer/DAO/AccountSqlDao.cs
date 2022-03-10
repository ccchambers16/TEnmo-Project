using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using System.Data.SqlClient;

namespace TenmoServer.DAO
{
    public class AccountSqlDao : IAccountSqlDao
    {

        private readonly string connectionString;

        public AccountSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString; 
        }


        public Account GetAccount(int accountId)
        {
            Account returnAccount = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, balance FROM account WHERE account_id = @accountId", conn);
                    cmd.Parameters.AddWithValue("@accountId", accountId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //need to Join tables above to pull username for Accounts object

                    if (reader.Read())
                    {
                        returnAccount = GetAccountFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnAccount;
        }


        public List<Account> GetAllAccounts()
        {
            List<Account> allAccounts = new List<Account>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, balance FROM account", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Account a = GetAccountFromReader(reader);
                        allAccounts.Add(a);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return allAccounts;
        }

        private Account GetAccountFromReader(SqlDataReader reader)
        {
            Account a = new Account()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Balance= Convert.ToDouble(reader["balance"])
            };

            return a;
        }



    }
}
