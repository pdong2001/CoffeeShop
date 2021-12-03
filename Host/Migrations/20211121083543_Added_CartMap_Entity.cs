using Microsoft.EntityFrameworkCore.Migrations;

namespace Host.Migrations
{
    public partial class Added_CartMap_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartMaps_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartMaps_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CartMaps",
                columns: new[] { "Id", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "7764bb69-5b0d-483c-9ef8-90b84d09936a" },
                    { 2, 2, "7764bb69-5b0d-483c-9ef8-90b84d09936a" },
                    { 3, 3, "7764bb69-5b0d-483c-9ef8-90b84d09936a" },
                    { 4, 4, "99637bc7-e749-4486-aec7-e85da1c59e6b" },
                    { 5, 5, "99637bc7-e749-4486-aec7-e85da1c59e6b" },
                    { 6, 6, "99637bc7-e749-4486-aec7-e85da1c59e6b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartMaps_ProductId",
                table: "CartMaps",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartMaps_UserId",
                table: "CartMaps",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartMaps");
        }
    }
}
