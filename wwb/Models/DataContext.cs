using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Models;


namespace wwb.Models
{
    public class DataContext:DbContext
    {
        public DataContext (DbContextOptions<DataContext>options) : base(options)
        {

        }
        public DbSet<Menu> menus { get; set; }
        public  DbSet<Metarials> metarials { get; set; }
        public DbSet<ShopingCartitem> shopingCartitems { get; set; }
        public DbSet<ShopingCart> ShopingCart { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ShopingCartitem>()
        //        .HasOne(e => e.ShopingCart)
        //        .WithOne(c => c.ShopingCartId)
        //        .HasForeignKey(e => e.ShopingCartId);
        //}
    }
}

