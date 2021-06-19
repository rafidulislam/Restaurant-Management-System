using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wwb.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "metarials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metarials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopingCart",
                columns: table => new
                {
                    ShopingCartId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingCart", x => x.ShopingCartId);
                });

            migrationBuilder.CreateTable(
                name: "shopingCartitems",
                columns: table => new
                {
                    ShopingCartitemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShopingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopingCartitems", x => x.ShopingCartitemId);
                    table.ForeignKey(
                        name: "FK_shopingCartitems_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shopingCartitems_ShopingCart_ShopingCartId",
                        column: x => x.ShopingCartId,
                        principalTable: "ShopingCart",
                        principalColumn: "ShopingCartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shopingCartitems_MenuId",
                table: "shopingCartitems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_shopingCartitems_ShopingCartId",
                table: "shopingCartitems",
                column: "ShopingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "metarials");

            migrationBuilder.DropTable(
                name: "shopingCartitems");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "ShopingCart");
        }
    }
}
