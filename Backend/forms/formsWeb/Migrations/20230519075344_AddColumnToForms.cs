using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestId",
                table: "Forms",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Forms_QuestId",
                table: "Forms",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Questionnaire_QuestId",
                table: "Forms",
                column: "QuestId",
                principalTable: "Questionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Questionnaire_QuestId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_QuestId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "QuestId",
                table: "Forms");
        }
    }
}
