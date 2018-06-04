using E_Wallet.BLL.Services;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using E_Wallet.DAL.EF;
using AutoMapper;
using E_Wallet.DAL.Interfaces;
using E_Wallet.DAL.Entities;
using E_Wallet.BLL.DTO;
using E_WalletBLL.Tests;

namespace E_Wallet.BLL.Services.Tests
{ 
    public class UserServiceTest
{
    private readonly IMapper mapper;
    private readonly Mock<IUnitOfWork> db;
    private readonly Mock<UserService> userService;

        public UserServiceTest() {
            userService = new Mock<UserService>();
            db = new Mock<IUnitOfWork>();
            mapper = new MapperConfiguration(c=>c.AddProfile<TestProfile>()).CreateMapper();
        }
    [Fact]
    public void AddAccountTest()
    {
        
    }

    [Fact]
    public void GetAccountsTest()
    {
            db.Setup(c => c.Accounts.GetAll()).Returns(AllAccounts);

            var result = userService.Object.GetAccounts() as List<AccountDTO>;

            Assert.Equal(20, result.Count);
    }

    [Fact]
    public void GetTransactionsByAccountTest()
    {
            var result = userService.Object.GetTransactionsByAccount(1);
            Assert.NotNull(result);
    }

    private IEnumerable<Account> AllAccounts()
    {
        var accounts = new List<Account>();

        for (int i = 0; i < 20; i++)
            accounts.Add(new Account { AccountTypeId = 1, Id = i, Name = "a" + i });

        return accounts;
    }
}
}