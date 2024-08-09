using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddConventions2Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomCapacities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalProperties",
                table: "RentalProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Floors",
                table: "Floors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenant");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "RentalProperties",
                newName: "RentalProperty");

            migrationBuilder.RenameTable(
                name: "Floors",
                newName: "Floor");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameColumn(
                name: "RoomCapacities",
                table: "Room",
                newName: "RoomCapacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant",
                column: "TenatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalProperty",
                table: "RentalProperty",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Floor",
                table: "Floor",
                column: "FloorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingId");

            migrationBuilder.CreateTable(
                name: "RoomCapacity",
                columns: table => new
                {
                    CapacityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCapacity", x => x.CapacityId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomCapacity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalProperty",
                table: "RentalProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Floor",
                table: "Floor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Tenant",
                newName: "Tenants");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "RentalProperty",
                newName: "RentalProperties");

            migrationBuilder.RenameTable(
                name: "Floor",
                newName: "Floors");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "RoomCapacity",
                table: "Rooms",
                newName: "RoomCapacities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "TenatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalProperties",
                table: "RentalProperties",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Floors",
                table: "Floors",
                column: "FloorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.CreateTable(
                name: "RoomCapacities",
                columns: table => new
                {
                    CapacityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCapacities", x => x.CapacityId);
                });
        }
    }
}
