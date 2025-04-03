using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_rental_api.Migrations
{
    /// <inheritdoc />
    public partial class TSK004_UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalStatusId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdNumber",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RentalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalStatusId",
                table: "Rentals",
                column: "RentalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_RentalStatus_RentalStatusId",
                table: "Rentals",
                column: "RentalStatusId",
                principalTable: "RentalStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "RentalStatus",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 0, "Confirmed" },
                    { 1, "Cancelled" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_RentalStatus_RentalStatusId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "RentalStatus");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentalStatusId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalStatusId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Customers");

            migrationBuilder.DeleteData(table: "RentalStatus", keyColumn: "Id", keyValues: new object[] { 0, 1 });
        }
    }
}
