using System;
using System.Collections.Generic;
using System.Text;

namespace E_Wallet.BLL.DTO
{
   public class AccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public double TotalAmount { get; set; }
        public int UserId { get; set; }
        public string AccountType { get; set; }
        //public IEnumerable<TransactionDTO> Transactions { get; set; }
    }
}
