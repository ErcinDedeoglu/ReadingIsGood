using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ReadingIsGood.Data.Migration
{
    public partial class Initial : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    AmountOfStock = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderDetailStatus = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Deleted", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 18, 12, 35, 5, 780, DateTimeKind.Utc).AddTicks(4928), false, "Self-Help", new DateTime(2021, 6, 18, 12, 35, 5, 780, DateTimeKind.Utc).AddTicks(5161) },
                    { 2, new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5370), false, "Biographies", new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5375) },
                    { 3, new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5446), false, "Business & Money", new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5447) },
                    { 4, new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5461), false, "Children's Books", new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5462) },
                    { 5, new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5475), false, "History", new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5476) },
                    { 6, new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5495), false, "Health, Fitness & Dieting", new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5496) },
                    { 7, new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5508), false, "Politics & Social Sciences", new DateTime(2021, 6, 18, 12, 35, 5, 781, DateTimeKind.Utc).AddTicks(5509) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreateDate", "Deleted", "FirstName", "LastName", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 18, 12, 35, 5, 783, DateTimeKind.Utc).AddTicks(2344), false, "Erçin", "Dedeoğlu", new DateTime(2021, 6, 18, 12, 35, 5, 783, DateTimeKind.Utc).AddTicks(2347) },
                    { 2, new DateTime(2021, 6, 18, 12, 35, 5, 783, DateTimeKind.Utc).AddTicks(3090), false, "Aylin", "Dedeoğlu", new DateTime(2021, 6, 18, 12, 35, 5, 783, DateTimeKind.Utc).AddTicks(3092) },
                    { 3, new DateTime(2021, 6, 18, 12, 35, 5, 783, DateTimeKind.Utc).AddTicks(3108), false, "Ata", "Dedeoğlu", new DateTime(2021, 6, 18, 12, 35, 5, 783, DateTimeKind.Utc).AddTicks(3110) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountOfStock", "CategoryId", "CreateDate", "Deleted", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 13, 1, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(8400), false, "Color Joy Coloring Book: Perfectly Portable Pages", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(8403) },
                    { 19, 233, 7, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9321), false, "Spilled Milk: Based on a true story", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9322) },
                    { 18, 233, 6, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9307), false, "Quiet: The Power of Introverts in a World That Can't Stop Talking", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9309) },
                    { 17, 233, 6, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9292), false, "The Four Agreements: A Practical Guide to Personal Freedom", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9293) },
                    { 16, 233, 6, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9278), false, "The Good Carb Cookbook: Secrets of Eating Low on the Glycemic Index", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9279) },
                    { 15, 233, 5, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9264), false, "Wild: From Lost to Found on the Pacific Crest Trail", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9265) },
                    { 14, 233, 5, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9250), false, "The Happiest Man on Earth", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9251) },
                    { 13, 233, 5, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9236), false, "The Turkish War of Independence: A Military History, 1919-1923", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9237) },
                    { 12, 233, 4, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9221), false, "A Long Walk to Water: Based on a True Story", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9222) },
                    { 20, 233, 7, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9335), false, "Exposing U.S. Government Policies On Extraterrestrial Life: The Challenge Of Exopolitics", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9336) },
                    { 11, 233, 4, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9207), false, "The Boy on the Wooden Box: How the Impossible Became Possible", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9208) },
                    { 9, 233, 3, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9176), false, "Sales 101: From Finding Leads and Closing Techniques to Retaining Customers and Growing Your Business", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9177) },
                    { 8, 233, 3, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9161), false, "HBR's 10 Must Reads on Sales", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9162) },
                    { 7, 233, 3, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9145), false, "The Book on Sales and Marketing: Expert Marketing for the People", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9146) },
                    { 6, 233, 2, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9081), false, "Running on Red Dog Road: And Other Perils of an Appalachian", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9082) },
                    { 5, 55, 2, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9063), false, "12 Years a Slave", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9063) },
                    { 4, 1881, 2, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9047), false, "Atatürk", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9048) },
                    { 3, 0, 1, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9031), false, "Greenlights", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9032) },
                    { 2, 3, 1, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9008), false, "The Four Agreements: A Practical Guide to Personal Freedom", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9010) },
                    { 10, 233, 4, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9192), false, "Lost on a Mountain in Maine", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9193) },
                    { 21, 233, 7, new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9349), false, "On Death And Dying", new DateTime(2021, 6, 18, 12, 35, 5, 782, DateTimeKind.Utc).AddTicks(9350) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
