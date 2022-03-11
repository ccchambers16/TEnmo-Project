using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferSqlDao
    {
        Transfer GetTransfer(int transferId);

        List<Transfer> GetAllTransfers(int accountId);

        Transfer SendTransfer(Transfer transferToSql);

    }
}
