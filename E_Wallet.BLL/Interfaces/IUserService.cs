using E_Wallet.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.BLL.Interfaces
{
   public interface IUserService
    {
        IEnumerable<TransactionDTO> GetTransactionsByAccount(int id);
        void AddAccount(AccountDTO account);
        IEnumerable<AccountDTO> GetAccounts();
        void Dispose();
        void MakeTransaction(TransactionDTO transaction);
    }
}
