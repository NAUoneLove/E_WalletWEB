using System;
using System.Collections.Generic;
using System.Text;
using E_Wallet.DAL.EF;
using E_Wallet.DAL.Entities;
using E_Wallet.DAL.Interfaces;
using System.Data.Entity;

namespace E_Wallet.DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private AccountContext db;

        public TransactionRepository(AccountContext context)
        {
            db = context;
        }

        public void Create(Transaction item)
        {
            db.Transactions.Add(item);
        }

        public void Delete(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction != null)
                db.Transactions.Remove(transaction);
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return db.Transactions;
        }

        public void Update(Transaction item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
