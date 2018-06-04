using E_Wallet.DAL.EF;
using E_Wallet.DAL.Entities;
using E_Wallet.DAL.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;
using System.Text;

namespace E_Wallet.DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private AccountContext db;

        public AccountRepository(AccountContext context)
        {
            db = context;
        }

        public void Create(Account item)
        {
            db.Accounts.Add(item);
        }

        public void Delete(int id)
        {
            Account account = db.Accounts.Find(id);
            if (account != null) {
                db.Accounts.Remove(account);
            }
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return db.Accounts;
        }

        public void Update(Account item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
