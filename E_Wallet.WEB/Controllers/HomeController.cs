using E_Wallet.BLL.DTO;
using E_Wallet.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using E_Wallet.WEB.Models;
using E_Wallet.BLL.Infrastructure;

namespace E_Wallet.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;
        public HomeController(IUserService serv) {
            userService = serv;
        }
        public ActionResult Index()
        {
            
            IEnumerable<AccountDTO> accountsDTO = userService.GetAccounts();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccountDTO,AccountViewModel>().ForMember(c=>c.Type,m=>m.MapFrom(c=>c.AccountType)).MaxDepth(2)).CreateMapper();
            var accounts = mapper.Map<IEnumerable<AccountDTO>, List<AccountViewModel>>(accountsDTO);
            return View(accounts);
        }
        public ActionResult ShowTransactions(int id)
        {
            IEnumerable<TransactionDTO> transactions = userService.GetTransactionsByAccount(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TransactionDTO, TransactionViewModel>().MaxDepth(2)).CreateMapper();
            var trs = mapper.Map<IEnumerable<TransactionDTO>, List<TransactionViewModel>>(transactions);

            return View(trs);
        }
        public ActionResult MakeTransaction() {
            TransactionViewModel transaction = new TransactionViewModel { };
            return View(transaction);
        }
        [HttpPost]
        public ActionResult MakeTransaction(TransactionViewModel transaction) {
            try
            {
                var transactionDTO = new TransactionDTO
                {
                    AmountOfMoney = transaction.AmountOfMoney, RecipientAccountId = transaction.RecipientAccountId,
                    SenderAccountId = transaction.SenderAccountId, Description = transaction.Description
                };

                userService.MakeTransaction(transactionDTO);
                return Content("<h2>Транзакція успішно проведена</h2>");
            }
            catch (ValidationException ex) {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(transaction);
        }
    }
}