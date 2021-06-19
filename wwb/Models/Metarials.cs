using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wwb.Models
{
    public class Metarials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}
