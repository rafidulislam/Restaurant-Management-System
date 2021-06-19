
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wwb.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }

        public  int OrderId { get; set; }
        public int MenuId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual Orders Orders { get; set; }

    }
}
