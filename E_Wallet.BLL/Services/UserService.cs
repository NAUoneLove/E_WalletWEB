using E_Wallet.BLL.DTO;
using E_Wallet.BLL.Interfaces;
using E_Wallet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Wallet.DAL.Entities;
using E_Wallet.BLL.Infrastructure;

namespace E_Wallet.BLL.Services
{
    public class UserService : IUserService
    {

        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddAccount(AccountDTO account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountDTO> GetAccounts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>().ForMember(c=>c.AccountType,m=>m.MapFrom(c=>c.Type.Name))).CreateMapper();
            List<AccountDTO> accounts = mapper.Map<IEnumerable<Account>, List<AccountDTO>>(Database.Accounts.GetAll());
            if (accounts == null || accounts.Count == 0)
                throw new ValidationException("Accounts not found", "");
            return accounts;
        }

        public IEnumerable<TransactionDTO> GetTransactionsByAccount(int id)
        {
            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<Transaction, TransactionDTO>()).CreateMapper();
            return mapper2.Map<IEnumerable<Transaction>, List<TransactionDTO>>(Database.Transactions.GetAll().Where(c => c.RecipientAccountId == id||c.SenderAccountId==id));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void MakeTransaction(TransactionDTO t)
        {
            Account a1 = Database.Accounts.Get(t.RecipientAccountId);
            Account a2 = Database.Accounts.Get(t.SenderAccountId);
            if (a1 == null || a2 == null)
                throw new ValidationException("Account not found", "");
            a1.TotalAmount += t.AmountOfMoney;
            a2.TotalAmount -= t.AmountOfMoney;
            Database.Accounts.Update(a1);
            Database.Accounts.Update(a2);
            Transaction transaction = new Transaction { RecipientAccount = a1, SenderAccount = a2, AmountOfMoney = t.AmountOfMoney, Description = t.Description, Date = DateTime.Now };
            Database.Transactions.Create(transaction);
            Database.Save();
        }
    }
}
