using E_Wallet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Wallet.DAL.Interfaces
{
   public interface IUnitOfWork:IDisposable
    {
        IRepository<Account> Accounts { get; }
        IRepository<Transaction> Transactions { get; }
        void Save();
    }
}
