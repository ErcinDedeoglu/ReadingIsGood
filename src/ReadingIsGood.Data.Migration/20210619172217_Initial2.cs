using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingIsGood.Data.Migration
{
    public partial class Initial2 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "OrderDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderDetails");
        }
    }
}
