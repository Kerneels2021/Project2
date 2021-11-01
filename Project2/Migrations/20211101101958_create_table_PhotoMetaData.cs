using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class create_table_PhotoMetaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PhotoMetaDatas_PhotoMetaDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhotoMetaDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhotoMetaDataId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PhotoMetaDatas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PhotoMetaDatas_UserId",
                table: "PhotoMetaDatas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoMetaDatas_Users_UserId",
                table: "PhotoMetaDatas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoMetaDatas_Users_UserId",
                table: "PhotoMetaDatas");

            migrationBuilder.DropIndex(
                name: "IX_PhotoMetaDatas_UserId",
                table: "PhotoMetaDatas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PhotoMetaDatas");

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoMetaDataId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhotoMetaDataId",
                table: "Users",
                column: "PhotoMetaDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PhotoMetaDatas_PhotoMetaDataId",
                table: "Users",
                column: "PhotoMetaDataId",
                principalTable: "PhotoMetaDatas",
                principalColumn: "PhotoMetaDataId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
