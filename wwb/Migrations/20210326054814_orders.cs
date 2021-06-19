using Microsoft.EntityFrameworkCore.Migrations;

namespace wwb.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "OrdersId");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderDetails",
                newName: "OrderDetailsId");

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrdersId",
                table: "OrderDetails",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrdersId",
                table: "OrderDetails",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "OrdersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrdersId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrdersId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsId",
                table: "OrderDetails",
                newName: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
