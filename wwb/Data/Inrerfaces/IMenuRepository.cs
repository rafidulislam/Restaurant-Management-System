using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Models;

namespace wwb.Data.Interface
{
   public interface IMenuRepository
    {
         IEnumerable<Menu> Menu { get; }
         //IEnumerable<Menu> PrefardMenu { get; set; }
         Menu GetMenuByID(int MenuId);
       
    }
}
