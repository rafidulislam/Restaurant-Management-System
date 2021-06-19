using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Data.Interface;
using wwb.Models;

namespace wwb.Data.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DataContext _dataContext;
        public MenuRepository (DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Menu> Menu => _dataContext.menus;
        // public IEnumerable<Menu> PrefardMenu { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Menu GetMenuByID(int MenuId) => _dataContext.menus.FirstOrDefault(p => p.Id == MenuId);
    }
}

