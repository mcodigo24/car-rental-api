using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_rental_api.Migrations
{
    /// <inheritdoc />
    public partial class TSK008_UpdateCustomer_AddPersonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "IdNumber",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
