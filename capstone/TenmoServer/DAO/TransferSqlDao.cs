using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using System.Data.SqlClient;

namespace TenmoServer.DAO
{
    public class TransferSqlDao //: ITransferSqlDao
    {

        private readonly string connectionString;

        public TransferSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
    }

    //USE CASES
    //SendTransfer [Usecase4]
    //TransferLog [Usecase5] 
    //SearchByTransactionId [Usecase6]



    //    public Transfer GetTransfer(int transferId)
    //    {
    //        Transfer transfer = null;
    //        try
    //        {
    //            using (SqlConnection conn = new SqlConnection(connectionString))
    //            {
    //                conn.Open();

    //                SqlCommand cmd = new SqlCommand(
    //                    "SELECT * FROM transfer t " +
    //                    "JOIN transfer_type tt ON t.transfer_type_id = tt.transfer_type_id " +
    //                    "JOIN transfer_status ts ON t.transfer_status_id = ts.transfer_status_id;", conn);
    //                //"SELECT user_id, balance FROM account " +
    //                //  "WHERE account_id = @accountId; ", conn);
    //                cmd.Parameters.AddWithValue("@transfer_id", transferId);
    //                SqlDataReader reader = cmd.ExecuteReader();

    //                //need to Join tables above to pull username for Accounts object. Check! 

    //                if (reader.Read())
    //                {
    //                    returnTransfer = GetTransferFromReader(reader);
    //                }

    //            }

    //        catch (SqlException)
    //        {
    //            throw;
    //        }

    //        return returnTransfer;
    //    }
    //}


    //private Transfer GetTransferFromReader(SqlDataReader reader)
    //{
    //    Transfer a = new Transfer()
    //    {
    //        TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]),
    //        TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]),
    //        FromAccountId = Convert.ToInt32(reader["account_from"]),
    //        ToUserId = Convert.ToInt32(reader["account_to"]),
    //        TransferAmount = Convert.ToDecimal(reader["amount"]),
    //        TransferId = Convert.ToInt32(reader["transfer_id"]),
    //        TransferStatusId = Convert.ToInt32(reader["transfer_status_id"])

    //        //Below not needed but in the database if needed later
    //        //TransferTypeId? = Convert.ToInt32(reader["transfer_type_id"]),
    //        //TransferTypeDescription = Convert.ToChar(reader["transfer_type_desc"])
    //        //TransferStatusDescripton = Convert.ToChar(reader["transfer_status_desc"])

    //    };

    //    return a;
    //}
}
