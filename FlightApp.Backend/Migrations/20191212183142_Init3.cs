using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightApp.Backend.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerFlights_Flights_FlightId",
                table: "PassengerFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerFlights_Users_UserId",
                table: "PassengerFlights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassengerFlights",
                table: "PassengerFlights");

            migrationBuilder.RenameTable(
                name: "PassengerFlights",
                newName: "UserFlights");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerFlights_UserId",
                table: "UserFlights",
                newName: "IX_UserFlights_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFlights",
                table: "UserFlights",
                columns: new[] { "FlightId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlights_Flights_FlightId",
                table: "UserFlights",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlights_Users_UserId",
                table: "UserFlights",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFlights_Flights_FlightId",
                table: "UserFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlights_Users_UserId",
                table: "UserFlights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFlights",
                table: "UserFlights");

            migrationBuilder.RenameTable(
                name: "UserFlights",
                newName: "PassengerFlights");

            migrationBuilder.RenameIndex(
                name: "IX_UserFlights_UserId",
                table: "PassengerFlights",
                newName: "IX_PassengerFlights_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassengerFlights",
                table: "PassengerFlights",
                columns: new[] { "FlightId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerFlights_Flights_FlightId",
                table: "PassengerFlights",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerFlights_Users_UserId",
                table: "PassengerFlights",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
