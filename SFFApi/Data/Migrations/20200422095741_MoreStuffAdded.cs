using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFFApi.Data.Migrations
{
    public partial class MoreStuffAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Returned",
                table: "MovieLoans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MovieLibrary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<Guid>(nullable: false),
                    Avaliable = table.Column<int>(nullable: false),
                    LicenseLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLibrary", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieLibrary");

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "MovieLoans");
        }
    }
}
