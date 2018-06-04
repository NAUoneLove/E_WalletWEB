using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Wallet.BLL.DTO;
using E_Wallet.DAL.Entities;

namespace E_WalletBLL.Tests
{
   public class TestProfile:Profile
    {
        public TestProfile() {
            CreateMap<AccountDTO, Account>().ReverseMap().MaxDepth(2);
            CreateMap<TransactionDTO, Transaction>().ReverseMap().MaxDepth(2);
            CreateMap<AccountTypeDTO, AccountType>().ReverseMap().MaxDepth(2);
        }
    }
}
