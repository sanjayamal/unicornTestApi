using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class orderDetailTablecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNos = table.Column<int>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    NoOfUnits = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                  
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderNo,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onUpdate:ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderNo",
                table: "OrderDetails",
                column: "OrderNo");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");
        }
    }
}
