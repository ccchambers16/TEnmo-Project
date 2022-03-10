using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferSqlDAO
    {
        Transfer GetTransfer(int transferId);

        List<Transfer> GetAllTransfers(int userId);
        Transfer SendTransfer(int userId, int TouserId, double TransferAmount);

    }
}
