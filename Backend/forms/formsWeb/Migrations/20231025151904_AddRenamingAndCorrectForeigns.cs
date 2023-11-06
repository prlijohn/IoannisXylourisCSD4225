using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddRenamingAndCorrectForeigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RadioId",
                table: "Radio_Answer_Translations",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "RadioId",
                table: "CheckBox_Answer_Translations",
                newName: "QuestionId");

            migrationBuilder.AlterColumn<bool>(
                name: "Checked",
                table: "Records",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Radio_Answer_Translations",
                newName: "RadioId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "CheckBox_Answer_Translations",
                newName: "RadioId");

            migrationBuilder.AlterColumn<bool>(
                name: "Checked",
                table: "Records",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }
    }
}
