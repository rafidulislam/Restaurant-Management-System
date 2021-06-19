using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wwb.Models
{
    public class Orders
    {
        [Key]
        public int OrdersId { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public string Name { get; set; }
        public DateTime OrderPlaced { get; set; }
        public decimal OrderTotal { get; set; }

    }
}
