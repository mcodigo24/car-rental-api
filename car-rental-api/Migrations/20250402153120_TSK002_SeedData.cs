using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_rental_api.Migrations
{
    /// <inheritdoc />
    public partial class TSK002_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model", "Type" },
                values: new object[,]
                {
                    { 1, "Toyota Corolla", "Sedan" },
                    { 2, "Fiat Cronos", "Sedan" },
                    { 3, "Ford Mustang", "Sports" },
                    { 4, "Chevrolet Tracker", "SUV" },
                    { 5, "Volkswagen T-Cross", "SUV" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Date", "CarId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 10), 1 },
                    { 2, new DateTime(2025, 3, 15), 2 },
                    { 3, new DateTime(2025, 3, 20), 3 },
                    { 4, new DateTime(2025, 3, 25), 4 },
                    { 5, new DateTime(2025, 3, 30), 5 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Cars", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5 });
            migrationBuilder.DeleteData(table: "Services", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
