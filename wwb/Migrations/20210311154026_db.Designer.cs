// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wwb.Models;

namespace wwb.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210311154026_db")]
    partial class db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("wwb.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("menus");
                });

            modelBuilder.Entity("wwb.Models.Metarials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("metarials");
                });

            modelBuilder.Entity("wwb.Models.ShopingCart", b =>
                {
                    b.Property<string>("ShopingCartId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ShopingCartId");

                    b.ToTable("ShopingCart");
                });

            modelBuilder.Entity("wwb.Models.ShopingCartitem", b =>
                {
                    b.Property<int>("ShopingCartitemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("MenuId");

                    b.Property<string>("ShopingCartId");

                    b.HasKey("ShopingCartitemId");

                    b.HasIndex("MenuId");

                    b.HasIndex("ShopingCartId");

                    b.ToTable("shopingCartitems");
                });

            modelBuilder.Entity("wwb.Models.ShopingCartitem", b =>
                {
                    b.HasOne("wwb.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId");

                    b.HasOne("wwb.Models.ShopingCart")
                        .WithMany("ShopingCartitems")
                        .HasForeignKey("ShopingCartId");
                });
#pragma warning restore 612, 618
        }
    }
}
