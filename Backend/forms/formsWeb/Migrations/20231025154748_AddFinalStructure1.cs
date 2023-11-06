using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddFinalStructure1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Radio_Answer_Translations_QuestionId",
                table: "Radio_Answer_Translations",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_Answer_Translations_QuestionnaireId",
                table: "Radio_Answer_Translations",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTranslations_QuestionId",
                table: "QuestionTranslations",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTranslations_QuestionTypeId",
                table: "QuestionTranslations",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBox_Answer_Translations_QuestionId",
                table: "CheckBox_Answer_Translations",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBox_Answer_Translations_QuestionnaireId",
                table: "CheckBox_Answer_Translations",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckBox_Answer_Translations_Questionnaire_QuestionnaireId",
                table: "CheckBox_Answer_Translations",
                column: "QuestionnaireId",
                principalTable: "Questionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckBox_Answer_Translations_Questions_QuestionId",
                table: "CheckBox_Answer_Translations",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTranslations_QuestionTypes_QuestionTypeId",
                table: "QuestionTranslations",
                column: "QuestionTypeId",
                principalTable: "QuestionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTranslations_Questionnaire_QuestionId",
                table: "QuestionTranslations",
                column: "QuestionId",
                principalTable: "Questionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Radio_Answer_Translations_Questionnaire_QuestionnaireId",
                table: "Radio_Answer_Translations",
                column: "QuestionnaireId",
                principalTable: "Questionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Radio_Answer_Translations_Questions_QuestionId",
                table: "Radio_Answer_Translations",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckBox_Answer_Translations_Questionnaire_QuestionnaireId",
                table: "CheckBox_Answer_Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckBox_Answer_Translations_Questions_QuestionId",
                table: "CheckBox_Answer_Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTranslations_QuestionTypes_QuestionTypeId",
                table: "QuestionTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTranslations_Questionnaire_QuestionId",
                table: "QuestionTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Radio_Answer_Translations_Questionnaire_QuestionnaireId",
                table: "Radio_Answer_Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Radio_Answer_Translations_Questions_QuestionId",
                table: "Radio_Answer_Translations");

            migrationBuilder.DropIndex(
                name: "IX_Radio_Answer_Translations_QuestionId",
                table: "Radio_Answer_Translations");

            migrationBuilder.DropIndex(
                name: "IX_Radio_Answer_Translations_QuestionnaireId",
                table: "Radio_Answer_Translations");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTranslations_QuestionId",
                table: "QuestionTranslations");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTranslations_QuestionTypeId",
                table: "QuestionTranslations");

            migrationBuilder.DropIndex(
                name: "IX_CheckBox_Answer_Translations_QuestionId",
                table: "CheckBox_Answer_Translations");

            migrationBuilder.DropIndex(
                name: "IX_CheckBox_Answer_Translations_QuestionnaireId",
                table: "CheckBox_Answer_Translations");
        }
    }
}
