using E_Wallet.BLL.DTO;
using E_Wallet.BLL.Interfaces;
using E_Wallet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.BLL.Services
{
    public class AccountService : IAccountService
    {
        IUnitOfWork Database { get; set; }

        public AccountService(IUnitOfWork uow) {
            Database = uow;
        }
        public IEnumerable<TransactionDTO> GetTransactions(int accountId){
            throw new NotImplementedException();
        }

        public void RefundAccount(int? sum, int accountId){
            throw new NotImplementedException();
        }

        public void Dispose(){
            Database.Dispose();
        }
    }
}
