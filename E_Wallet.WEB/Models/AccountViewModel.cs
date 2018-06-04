using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Wallet.WEB.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public double TotalAmount { get; set; }
    }
}