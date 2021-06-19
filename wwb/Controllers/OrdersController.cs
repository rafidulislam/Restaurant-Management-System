using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Data.Inrerfaces;
using wwb.Models;

namespace wwb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ShopingCart _shopingCart;

        public OrdersController(IOrdersRepository ordersRepository, ShopingCart shopingCart)
        {
            _ordersRepository = ordersRepository;
            _shopingCart = shopingCart;
        }


        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
      //  [Authorize]
        public IActionResult Checkout(Orders order)
        {
            var items = _shopingCart.GetShopingCartitems();
            _shopingCart.ShopingCartitems = items;
            if (_shopingCart.ShopingCartitems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some items first");
            }

            if (ModelState.IsValid)
            {
                _ordersRepository.CreateOrders(order);
                _shopingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }
        
       // [Authorize]
        public IActionResult CheckoutComplete()
        {
            return View();
        }

    }
}
