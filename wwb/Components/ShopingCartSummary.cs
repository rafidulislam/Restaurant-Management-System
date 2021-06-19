using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Models;

namespace wwb.Components
{
    public class ShopingCartSummary:ViewComponent
    {
        private readonly ShopingCart _shopingCart;
        public ShopingCartSummary(ShopingCart shopingCart)
        {
            _shopingCart = shopingCart;
        }

        public IViewComponentResult Invoke()
        {
            var Item =_shopingCart.GetShopingCartitems(); ;//_shopingCart.GetShopingCartitems();
            _shopingCart.ShopingCartitems = Item;
            var ShopingCartviewmodel = new ShopingCartViewModel
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShopingCartTotal(),
            } ;
            return View(ShopingCartviewmodel);
        }
    }
}
