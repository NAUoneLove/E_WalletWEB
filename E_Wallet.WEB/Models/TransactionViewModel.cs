using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Wallet.WEB.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public int RecipientAccountId { get; set; }
        public int SenderAccountId { get; set; }

        public string Description { get; set; }
        public int AmountOfMoney { get; set; }
    }
}