using E_Wallet.DAL.EF;
using E_Wallet.DAL.Entities;
using E_Wallet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Wallet.DAL.Repositories
{
   public class EFUnitOfWork: IUnitOfWork
    {
        private AccountContext db;
        private AccountRepository accountRepository;
        private TransactionRepository transactionRepository;

        public EFUnitOfWork(string connectionString) {
            db = new AccountContext(connectionString);
        }

        public IRepository<Account> Accounts {
            get {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(db);
                return accountRepository;
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                if (transactionRepository == null)
                    transactionRepository = new TransactionRepository(db);
                return transactionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    db.Dispose();
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}
