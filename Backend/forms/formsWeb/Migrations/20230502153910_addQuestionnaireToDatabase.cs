using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class addQuestionnaireToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    lang_code = table.Column<string>(type: "text", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTranslations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radio_Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radio_Answers_Questionnaire_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    questionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_questionType",
                        column: x => x.questionType,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Questionnaire_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radio_Answer_Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RadioId = table.Column<int>(type: "integer", nullable: false),
                    lang_code = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio_Answer_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radio_Answer_Translations_Radio_Answers_RadioId",
                        column: x => x.RadioId,
                        principalTable: "Radio_Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer_Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionnaireId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    nextQuestion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Maps_Questionnaire_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_Maps_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_Maps_QuestionId",
                table: "Answer_Maps",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_Maps_QuestionnaireId",
                table: "Answer_Maps",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionId",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_questionType",
                table: "Questions",
                column: "questionType");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_Answer_Translations_RadioId",
                table: "Radio_Answer_Translations",
                column: "RadioId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_Answers_QuestionId",
                table: "Radio_Answers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer_Maps");

            migrationBuilder.DropTable(
                name: "QuestionTranslations");

            migrationBuilder.DropTable(
                name: "Radio_Answer_Translations");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Radio_Answers");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Questionnaire");
        }
    }
}
