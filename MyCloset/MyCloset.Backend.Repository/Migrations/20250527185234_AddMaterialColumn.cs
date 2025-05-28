using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Material",
                table: "Clothes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Material",
                table: "Clothes");
        }
    }
}
