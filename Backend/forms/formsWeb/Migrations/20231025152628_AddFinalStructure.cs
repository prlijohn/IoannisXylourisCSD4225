using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace formsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddFinalStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CheckBox_Answers");

            migrationBuilder.DropTable(
                name: "Image_Answers");

            migrationBuilder.DropTable(
                name: "Radio_Answers");

            migrationBuilder.DropTable(
                name: "Text_Answers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrded = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                name: "IX_Radio_Answers_QuestionId",
                table: "Radio_Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Text_Answers_QuestionId",
                table: "Text_Answers",
                column: "QuestionId");
        }
    }
}
