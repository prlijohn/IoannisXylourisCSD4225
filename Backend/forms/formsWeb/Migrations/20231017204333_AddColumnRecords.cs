using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionTypeId",
                table: "Records",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Records_QuestionTypeId",
                table: "Records",
                column: "QuestionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_QuestionTypes_QuestionTypeId",
                table: "Records",
                column: "QuestionTypeId",
                principalTable: "QuestionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_QuestionTypes_QuestionTypeId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_QuestionTypeId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "QuestionTypeId",
                table: "Records");
        }
    }
}
