using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightApp.Backend.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_FoodId",
                table: "OrderLine",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Foods_FoodId",
                table: "OrderLine",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Foods_FoodId",
                table: "OrderLine");

            migrationBuilder.DropIndex(
                name: "IX_OrderLine_FoodId",
                table: "OrderLine");
        }
    }
}
