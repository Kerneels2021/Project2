using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageGallery.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Geolocation",
                table: "GalleryImages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geolocation",
                table: "GalleryImages");
        }
    }
}
