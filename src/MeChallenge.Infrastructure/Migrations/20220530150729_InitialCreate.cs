using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeChallenge.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MeChallenge");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "MeChallenge",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValueApproved = table.Column<decimal>(type: "numeric", nullable: false),
                    ItemsApproved = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "MeChallenge",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UnitValue = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "MeChallenge",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "MeChallenge",
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "MeChallenge",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "UnitValue" },
                values: new object[,]
                {
                    { new Guid("05077f8d-a577-47d6-9c92-6714332950e4"), "Lorem Ipsum", "Shorts", 95m },
                    { new Guid("09d92788-b384-4e6d-bce2-fcb9cf1928e9"), "Lorem Ipsum", "Glasses", 250m },
                    { new Guid("58551994-7838-41c2-9928-480cc3bcf287"), "Lorem Ipsum", "Cap", 35m },
                    { new Guid("8832c3fc-ca04-476d-8ced-4d400f5bdf07"), "Lorem Ipsum", "Jacket", 400m },
                    { new Guid("98ecf0f5-53ff-48f3-80d0-048059357bec"), "Lorem Ipsum", "T-shirt", 50m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "MeChallenge");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "MeChallenge");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "MeChallenge");
        }
    }
}
