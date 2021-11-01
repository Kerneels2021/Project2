using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class create_access_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTypes",
                columns: table => new
                {
                    AccessTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAccessType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTypes", x => x.AccessTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTypes");
        }
    }
}
