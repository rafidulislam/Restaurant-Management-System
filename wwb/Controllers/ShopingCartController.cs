using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Data.Interface;
using wwb.Models;

namespace wwb.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly IMenuRepository _IMenuRepository;
        private readonly ShopingCart _ShopingCart;


        public ShopingCartController(IMenuRepository IMenuRepositry, ShopingCart ShopingCart)
        {
            _IMenuRepository = IMenuRepositry;
            _ShopingCart = ShopingCart;
        }
        public ViewResult Index()
        {
            var item = _ShopingCart.GetShopingCartitems();
            _ShopingCart.ShopingCartitems = item;

            var sVM = new ShopingCartViewModel
            {
                ShopingCart = _ShopingCart,
                ShopingCartTotal = _ShopingCart.GetShopingCartTotal(),
            };
            return View(sVM);
        }

        public RedirectToActionResult AddToShoopingCart(int Id)
        {
            var selectItem = _IMenuRepository.Menu.FirstOrDefault(p=>p.Id== Id);
            if(selectItem != null)
            {
                _ShopingCart.AddToCart(selectItem, 1);
                 
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemovefromShoopingCart(int Id)
        {
            int a = Id;
            var selectItem = _IMenuRepository.Menu.FirstOrDefault(p => p.Id == a);
            Console.WriteLine(a);
            if (selectItem != null)
            {
                _ShopingCart.RemoveCart(selectItem);

            }
            return RedirectToAction("Index");
        }
    }
}
