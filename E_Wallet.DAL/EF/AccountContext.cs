using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using E_Wallet.DAL.Entities;

namespace E_Wallet.DAL.EF
{
    public class AccountContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }

        static AccountContext() {
            Database.SetInitializer(new AccountsDbInitializer());
        }

        public AccountContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasRequired(c => c.Type).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Transaction>().HasRequired(c => c.RecipientAccount).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Transaction>().HasRequired(c => c.SenderAccount).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<AccountType>().HasMany(c => c.Accounts).WithRequired(c => c.Type).WillCascadeOnDelete();
        }
    }
}
