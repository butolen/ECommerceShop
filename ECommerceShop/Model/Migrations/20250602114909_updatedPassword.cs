using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceShop.Migrations
{
    /// <inheritdoc />
    public partial class updatedPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "administrators",
                columns: table => new
                {
                    username = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "VARCHAR(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrators", x => x.username);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "VARCHAR(700)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "VARCHAR(700)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "VARCHAR(700)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    instock = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "VARCHAR(700)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    username = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.username);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    user = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity_ordered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => new { x.product_id, x.user });
                    table.ForeignKey(
                        name: "FK_order_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_users_user",
                        column: x => x.user,
                        principalTable: "users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    reviewid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rating = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "VARCHAR(200)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.reviewid);
                    table.ForeignKey(
                        name: "FK_reviews_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_users_username",
                        column: x => x.username,
                        principalTable: "users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_user",
                table: "order_items",
                column: "user");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_productid",
                table: "reviews",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_username",
                table: "reviews",
                column: "username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
