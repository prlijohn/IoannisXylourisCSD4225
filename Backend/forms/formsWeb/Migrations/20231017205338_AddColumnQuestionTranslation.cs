using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnQuestionTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionTypeId",
                table: "QuestionTranslations",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionTypeId",
                table: "QuestionTranslations");
        }
    }
}
