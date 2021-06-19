using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Models;

namespace wwb.Data.Inrerfaces
{
    public interface IOrdersRepository
    {
        void CreateOrders(Orders orders);
    }
}
