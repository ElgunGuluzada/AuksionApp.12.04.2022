using AuksionApp._12._04._2022;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class BuyerPtoduct
    {
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
