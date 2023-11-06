using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToRadioAnswerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radio_Answer_Translations_Radio_Answers_RadioId",
                table: "Radio_Answer_Translations");

            migrationBuilder.DropIndex(
                name: "IX_Radio_Answer_Translations_RadioId",
                table: "Radio_Answer_Translations");

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "Radio_Answer_Translations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Radio_Answer_Translations");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_Answer_Translations_RadioId",
                table: "Radio_Answer_Translations",
                column: "RadioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Radio_Answer_Translations_Radio_Answers_RadioId",
                table: "Radio_Answer_Translations",
                column: "RadioId",
                principalTable: "Radio_Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
