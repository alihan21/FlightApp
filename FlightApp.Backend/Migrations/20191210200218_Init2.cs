using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightApp.Backend.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerFlights_Users_PassengerId",
                table: "PassengerFlights");

            migrationBuilder.DropTable(
                name: "StaffFlight");

            migrationBuilder.RenameColumn(
                name: "Seatnumber",
                table: "Seats",
                newName: "SeatNumber");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "PassengerFlights",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerFlights_PassengerId",
                table: "PassengerFlights",
                newName: "IX_PassengerFlights_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerFlights_Users_UserId",
                table: "PassengerFlights",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerFlights_Users_UserId",
                table: "PassengerFlights");

            migrationBuilder.RenameColumn(
                name: "SeatNumber",
                table: "Seats",
                newName: "Seatnumber");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PassengerFlights",
                newName: "PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerFlights_UserId",
                table: "PassengerFlights",
                newName: "IX_PassengerFlights_PassengerId");

            migrationBuilder.CreateTable(
                name: "StaffFlight",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false),
                    FlightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffFlight", x => new { x.StaffId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_StaffFlight_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffFlight_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffFlight_FlightId",
                table: "StaffFlight",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerFlights_Users_PassengerId",
                table: "PassengerFlights",
                column: "PassengerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
