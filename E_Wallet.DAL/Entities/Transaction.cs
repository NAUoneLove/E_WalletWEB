using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Wallet.DAL.Entities
{
   public class Transaction
    {
        public int Id { get; set; }

        public int? RecipientAccountId { get; set; }
        public int? SenderAccountId { get; set; }

        public string Description { get; set; }
        public int AmountOfMoney { get; set; }

        [ForeignKey("RecipientAccountId")]
        public Account RecipientAccount { get; set; }

        [ForeignKey("SenderAccountId")]
        public Account SenderAccount { get; set; }

        public DateTime Date { get; set; }
      
    }
}
