using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Office.Interop.Excel;
using NPoco.Expressions;
using wwb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FizzWare.NBuilder.Dates;

namespace wwb.Models
{
    public class ShopingCart
    {
        private readonly DataContext _dataContext;
        public readonly DataContext _dataContext1;
       
        private ShopingCart(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string ShopingCartId { get; set; }

        public List<ShopingCartitem> ShopingCartitems { get; set; }

        
        public  static ShopingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DataContext>();
            string cartId = session.GetString("CartId")
                            ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShopingCart(context) { ShopingCartId = cartId };
        }

        public void AddToCart(Menu menu,int amount)
        {
            var shopingCartItem = _dataContext.shopingCartitems.SingleOrDefault(s => s.Menu.Id == menu.Id && s.ShopingCartId == ShopingCartId);

            //var shopingcart = _dataContext.ShopingCart.Find(ShopingCartId);
            //_dataContext.ShopingCart.Add(shopingcart);
            
            if (shopingCartItem == null)
            {
                shopingCartItem = new ShopingCartitem
                {
                    ShopingCartId = ShopingCartId,
                    Menu = menu,
                    Amount = 1,
                };
                _dataContext.shopingCartitems.Add(shopingCartItem);
               
            }
            else
            {
                shopingCartItem.Amount++;
            }
            _dataContext.SaveChanges();
        }   

        public int RemoveCart(Menu menu)
        {
            var ShopingCartItem = _dataContext.shopingCartitems.SingleOrDefault(s => s.Menu.Id == menu.Id && s.ShopingCartId == ShopingCartId);
            var localAmount = 0;
            if (ShopingCartItem != null)
            {
                if (ShopingCartItem.Amount > 1)
                {
                    ShopingCartItem.Amount--;
                    localAmount = ShopingCartItem.Amount;
                }
                else
                {
                    _dataContext.shopingCartitems.Remove(ShopingCartItem);
                }
            }
            _dataContext.SaveChanges();
            return localAmount;
        }

        public List<ShopingCartitem> GetShopingCartitems()
        {
    
            return ShopingCartitems ??
                (ShopingCartitems=_dataContext.shopingCartitems
                .Where(c=>c.ShopingCartId == ShopingCartId)
                .Include(s=> s.Menu).ToList());
        }

        public void ClearCart()
        {
            var shopingCartItem = _dataContext.shopingCartitems.Where(s => s.ShopingCartId == ShopingCartId);
            _dataContext.shopingCartitems.RemoveRange(shopingCartItem);
            _dataContext.SaveChanges();
        }

        public decimal GetShopingCartTotal()
        {
            var total = _dataContext.shopingCartitems.Where(s => s.ShopingCartId == ShopingCartId)
                .Select(s => s.Menu.Price * s.Amount).Sum();
            var a = _dataContext.shopingCartitems.Where(s => s.Amount == 23);
            
            return total;
        }
    }
}
