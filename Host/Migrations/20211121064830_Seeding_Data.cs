using Microsoft.EntityFrameworkCore.Migrations;

namespace Host.Migrations
{
    public partial class Seeding_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Note" },
                values: new object[] { 1, "Loại 1", "Loại này bình thường" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Note" },
                values: new object[] { 2, "Loại 2", "Loại này hơi xịn" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Note" },
                values: new object[] { 3, "Loại 3", "Loại này rất xịn" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BannerImageId", "CategoryId", "Description", "Name", "Price", "Quantity", "SmallImageId" },
                values: new object[,]
                {
                    { 1, null, 1, null, "Hạt coffee loại1", 250000, 100, null },
                    { 2, null, 1, null, "Hạt coffee loại2", 220000, 100, null },
                    { 3, null, 1, null, "Hạt coffee loại3", 240000, 100, null },
                    { 4, null, 2, null, "Hạt coffee loại4", 150000, 100, null },
                    { 5, null, 2, null, "Hạt coffee loại5", 350000, 100, null },
                    { 6, null, 2, null, "Hạt coffee loại6", 650000, 100, null },
                    { 7, null, 3, null, "Hạt coffee loại7", 550000, 100, null },
                    { 8, null, 3, null, "Hạt coffee loại8", 225000, 100, null },
                    { 9, null, 3, null, "Hạt coffee loại9", 255000, 100, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
