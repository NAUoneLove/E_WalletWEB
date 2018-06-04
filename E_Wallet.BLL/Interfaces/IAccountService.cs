using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Wallet.BLL.DTO;

namespace E_Wallet.BLL.Interfaces
{
   public interface IAccountService
    {
        void RefundAccount(int? sum, int accountId);
        IEnumerable<TransactionDTO> GetTransactions(int accountId);
        void Dispose();
    }
}
