using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addmodelsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occupant",
                columns: table => new
                {
                    TenatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idno = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupant", x => x.TenatId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantTenatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Book_Occupant_TenantTenatId",
                        column: x => x.TenantTenatId,
                        principalTable: "Occupant",
                        principalColumn: "TenatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    RoomNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentCost = table.Column<double>(type: "float", nullable: false),
                    Deposit = table.Column<double>(type: "float", nullable: false),
                    RoomCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingsBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_Book_BookingsBookingId",
                        column: x => x.BookingsBookingId,
                        principalTable: "Book",
                        principalColumn: "BookingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_TenantTenatId",
                table: "Book",
                column: "TenantTenatId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BookingsBookingId",
                table: "Room",
                column: "BookingsBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Occupant");
        }
    }
}
