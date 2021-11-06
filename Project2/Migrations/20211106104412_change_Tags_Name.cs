using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class change_Tags_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "PhotoMetaDatas",
                newName: "PhotoTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoTag",
                table: "PhotoMetaDatas",
                newName: "Tags");
        }
    }
}
