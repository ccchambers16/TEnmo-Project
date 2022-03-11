using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using System.Data.SqlClient;

namespace TenmoServer.DAO
{
    public class TransferSqlDao : ITransferSqlDao
    {

        private readonly string connectionString;

        public TransferSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public Transfer GetTransfer(int transferId)
        {
            Transfer transfer = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM transfer WHERE transfer_id = @transferID", conn);
                    cmd.Parameters.AddWithValue("@transfer_id", transferId);
                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        transfer = GetTransferFromReader(reader);
                    }
                }
            }

            catch (SqlException)
            {
                throw;
            }

            return transfer;
        }

        public List<Transfer> GetAllTransfers(int accountId)
        {
            List<Transfer> allTransfers = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                         "SELECT * FROM transfer WHERE account_from = @account_id OR account_to = @account_id; ", conn);
                    cmd.Parameters.AddWithValue("@account_id", accountId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Transfer b = GetTransferFromReader(reader);
                        allTransfers.Add(b);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return allTransfers;
        }

        public Transfer SendTransfer(Transfer transferToSql)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO transfer (transfer_type_id, transfer_status_id, account_from, account_to, amount" +
                        "VALUES (2, 2, @accountFrom, @accountTo, @amount;", conn);
                    cmd.Parameters.AddWithValue("@accountFrom", transferToSql.FromAccountId);
                    cmd.Parameters.AddWithValue("@accountTo", transferToSql.ToAccountId);
                    cmd.Parameters.AddWithValue("@amount", transferToSql.TransferAmount);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT @@IDENTITY", conn);
                    int transferId = Convert.ToInt32(cmd.ExecuteScalar());
                    transferToSql = GetTransfer(transferId);

                    cmd = new SqlCommand("UPDATE account SET balance = (balance + '@amount') WHERE account_id = @accountTo; " +
                        "UPDATE account SET balance = (balance - '@amount') WHERE account_id = accountFrom;", conn);
                    cmd.Parameters.AddWithValue("@accountFrom", transferToSql.FromAccountId);
                    cmd.Parameters.AddWithValue("@accountTo", transferToSql.ToAccountId);
                    cmd.Parameters.AddWithValue("@amount", transferToSql.TransferAmount);
                    cmd.ExecuteNonQuery(); 
                }
            }

            catch (SqlException)
            {
                throw;
            }

            return transferToSql;
        }



        private Transfer GetTransferFromReader(SqlDataReader reader)
        {
            Transfer b = new Transfer()
            {
                TransferId = Convert.ToInt32(reader["transfer_id"]),
                TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]),
                TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]),
                FromAccountId = Convert.ToInt32(reader["account_from"]),
                ToAccountId = Convert.ToInt32(reader["account_to"]),
                TransferAmount = Convert.ToDecimal(reader["amount"]),
            };

            return b;
        }



    }
}





        

