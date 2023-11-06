using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToQuestionnaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "expression",
                table: "Questionnaire",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<double>>(
                name: "score",
                table: "Questionnaire",
                type: "double precision[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expression",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "score",
                table: "Questionnaire");
        }
    }
}
