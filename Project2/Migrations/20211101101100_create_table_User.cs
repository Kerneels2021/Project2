using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class create_table_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoMetaDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_PhotoMetaDatas_PhotoMetaDataId",
                        column: x => x.PhotoMetaDataId,
                        principalTable: "PhotoMetaDatas",
                        principalColumn: "PhotoMetaDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhotoMetaDataId",
                table: "Users",
                column: "PhotoMetaDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
