using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Wallet.DAL.Entities
{
   public class Account
    {
        public int Id { get; set; }
        public int? AccountTypeId { get; set; }
        public string Name { get; set; }
        public double TotalAmount { get; set; }
        public int UserId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType Type { get; set; }
        public ICollection<Transaction> ConfirmedTransactions { get; set; }
        public ICollection<Transaction> SendedTransactions { get; set; }
    }
}
