using E_Wallet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.DAL.EF
{
    public class AccountsDbInitializer:CreateDatabaseIfNotExists<AccountContext>
    {
        protected override void Seed(AccountContext db)
        {
            AccountType type = new AccountType { Name = "Копілка" };
            db.AccountTypes.Add(type);
            db.SaveChanges();
            Account a1 = new Account {AccountTypeId = 1, Name = "Стипендія", TotalAmount = 1280.0 };
            Account a2 = new Account {AccountTypeId = 1, Name = "Privat", TotalAmount = 15000.16 };
            db.Accounts.Add(a1);
            db.Accounts.Add(a2);
            db.SaveChanges();
        }
    }
}
