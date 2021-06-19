using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Data.Inrerfaces;
using wwb.Models;

namespace wwb.Data.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        public readonly DataContext _dataContext;
        public readonly ShopingCart _shopingCart;

        public OrdersRepository(DataContext dataContext, ShopingCart shopingCart)
        {
            _dataContext = dataContext;
            _shopingCart = shopingCart;
        }



        public void CreateOrders(Orders orders)
        {
            orders.OrderPlaced = DateTime.Now;
            _dataContext.Orders.Add(orders);
            var shoppingcartitem = _shopingCart.ShopingCartitems;
            foreach(var shoppingcartitems in shoppingcartitem)
            {
                var orderdetail = new OrderDetails()
                {
                    Amount = shoppingcartitems.Amount,
                    MenuId = shoppingcartitems.Menu.Id,
                    OrderId = orders.OrdersId,
                    Price = shoppingcartitems.Menu.Price,
                };
                _dataContext.OrderDetails.Add(orderdetail);
            }
            _dataContext.SaveChanges();
        }

        
    }
}
