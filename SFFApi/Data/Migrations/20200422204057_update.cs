using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFFApi.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieLoanInstanceId",
                table: "MovieLoans");

            migrationBuilder.AddColumn<Guid>(
                name: "StudioGuid",
                table: "Studios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RatingGuid",
                table: "Ratings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MovieGuid",
                table: "Movies",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MovieLoanInstanceGuid",
                table: "MovieLoans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudioGuid",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "RatingGuid",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "MovieGuid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieLoanInstanceGuid",
                table: "MovieLoans");

            migrationBuilder.AddColumn<Guid>(
                name: "StudioId",
                table: "Studios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MovieLoanInstanceId",
                table: "MovieLoans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
