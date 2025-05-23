using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreColumnToClothing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Store",
                table: "Clothes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Store",
                table: "Clothes");
        }
    }
}
