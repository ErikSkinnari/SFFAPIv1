using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFFApi.Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TriviaGuid",
                table: "Trivias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TriviaGuid",
                table: "Trivias");
        }
    }
}
