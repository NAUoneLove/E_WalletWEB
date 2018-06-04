using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.BLL.DTO
{
   public class TransactionDTO
    {
        public int Id { get; set; }
        public int RecipientAccountId { get; set; }
        public int SenderAccountId { get; set; }

        public string Description { get; set; }
        public int AmountOfMoney { get; set; }
    }
}
