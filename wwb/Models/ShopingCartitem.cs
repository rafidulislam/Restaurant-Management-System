using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wwb.Models
{
    public class ShopingCartitem
    {
        [Key]
        public int ShopingCartitemId { get; set; }
        public Menu Menu { get; set; }
        public int Amount { get; set; }

        public ShopingCart ShopingCart { get; set; }
        public string ShopingCartId { get; set; }
    }
}
