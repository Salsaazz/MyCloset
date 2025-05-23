using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Clothes_ClothingId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Image_Id",
                table: "Images",
                newName: "IX_Images_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Image_ClothingId",
                table: "Images",
                newName: "IX_Images_ClothingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Clothes_ClothingId",
                table: "Images",
                column: "ClothingId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Clothes_ClothingId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Id",
                table: "Image",
                newName: "IX_Image_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ClothingId",
                table: "Image",
                newName: "IX_Image_ClothingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Clothes_ClothingId",
                table: "Image",
                column: "ClothingId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
