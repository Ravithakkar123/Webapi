using Microsoft.EntityFrameworkCore.Migrations;

namespace Webapi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    CustomerNum = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerPinCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemName = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    FoodItemInfo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FoodItemPrice = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardOwnerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Exp = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    FoodItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodItemId",
                table: "OrderItems",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItemId",
                table: "Orders",
                column: "OrderItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "FoodItems");
        }
    }
}
