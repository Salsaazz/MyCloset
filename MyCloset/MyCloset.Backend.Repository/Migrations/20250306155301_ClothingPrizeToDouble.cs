using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClothingPrizeToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prize",
                table: "Clothes",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "Prize",
                table: "Clothes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
