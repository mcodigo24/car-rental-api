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
                    { 0, "Toyota Corolla", "Sedan" },
                    { 1, "Fiat Cronos", "Sedan" },
                    { 2, "Ford Mustang", "Sports" },
                    { 3, "Chevrolet Tracker", "SUV" },
                    { 4, "Volkswagen T-Cross", "SUV" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Date", "CarId" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 3, 10), 0 },
                    { 1, new DateTime(2025, 3, 15), 1 },
                    { 2, new DateTime(2025, 3, 20), 2 },
                    { 3, new DateTime(2025, 3, 25), 3 },
                    { 4, new DateTime(2025, 3, 30), 4 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Cars", keyColumn: "Id", keyValues: new object[] { 0, 1, 2, 3, 4 });
            migrationBuilder.DeleteData(table: "Services", keyColumn: "Id", keyValues: new object[] { 0, 1, 2, 3, 4 });
        }
    }
}
