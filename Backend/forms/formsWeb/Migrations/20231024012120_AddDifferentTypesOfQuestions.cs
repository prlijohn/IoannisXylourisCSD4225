using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddDifferentTypesOfQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "score",
                table: "Records",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                table: "Records",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Records",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Records",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CheckBox_Answer_Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionnaireId = table.Column<int>(type: "integer", nullable: false),
                    RadioId = table.Column<int>(type: "integer", nullable: false),
                    lang_code = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBox_Answer_Translations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckBox_Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBox_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckBox_Answers_Questionnaire_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image_Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Answers_Questionnaire_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Text_Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Text_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Text_Answers_Questionnaire_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckBox_Answers_QuestionId",
                table: "CheckBox_Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Answers_QuestionId",
                table: "Image_Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Text_Answers_QuestionId",
                table: "Text_Answers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckBox_Answer_Translations");

            migrationBuilder.DropTable(
                name: "CheckBox_Answers");

            migrationBuilder.DropTable(
                name: "Image_Answers");

            migrationBuilder.DropTable(
                name: "Text_Answers");

            migrationBuilder.DropColumn(
                name: "Checked",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "score",
                table: "Records",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
