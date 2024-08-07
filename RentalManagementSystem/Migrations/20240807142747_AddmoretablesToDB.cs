using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddmoretablesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Occupant_TenantTenatId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Book_BookingsBookingId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Room_BookingsBookingId",
                table: "Rooms",
                newName: "IX_Rooms_BookingsBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_TenantTenatId",
                table: "Books",
                newName: "IX_Books_TenantTenatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookingId");

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    FloorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomSize = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.FloorId);
                });

            migrationBuilder.CreateTable(
                name: "RentalProperties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorSize = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalProperties", x => x.PropertyId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Occupant_TenantTenatId",
                table: "Books",
                column: "TenantTenatId",
                principalTable: "Occupant",
                principalColumn: "TenatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Books_BookingsBookingId",
                table: "Rooms",
                column: "BookingsBookingId",
                principalTable: "Books",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Occupant_TenantTenatId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Books_BookingsBookingId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "RentalProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BookingsBookingId",
                table: "Room",
                newName: "IX_Room_BookingsBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_TenantTenatId",
                table: "Book",
                newName: "IX_Book_TenantTenatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Occupant_TenantTenatId",
                table: "Book",
                column: "TenantTenatId",
                principalTable: "Occupant",
                principalColumn: "TenatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Book_BookingsBookingId",
                table: "Room",
                column: "BookingsBookingId",
                principalTable: "Book",
                principalColumn: "BookingId");
        }
    }
}
