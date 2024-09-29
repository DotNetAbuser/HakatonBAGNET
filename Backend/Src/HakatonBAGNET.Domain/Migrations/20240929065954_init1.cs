using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HakatonBAGNET.Domain.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    points_count = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    question_content = table.Column<string>(type: "text", nullable: false),
                    correct_points_count = table.Column<int>(type: "integer", nullable: false),
                    incorrect_points_count = table.Column<int>(type: "integer", nullable: false),
                    is_moderated = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.question_id);
                    table.ForeignKey(
                        name: "FK_questions_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_questions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    answer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    answer_content = table.Column<string>(type: "text", nullable: false),
                    is_moderated = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.answer_id);
                    table.ForeignKey(
                        name: "FK_answers_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_answers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    answer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_liked = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reactions_answers_answer_id",
                        column: x => x.answer_id,
                        principalTable: "answers",
                        principalColumn: "answer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reactions_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reactions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "created_at", "deleted_at", "is_deleted", "title", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 29, 6, 59, 54, 325, DateTimeKind.Utc).AddTicks(6389), null, false, "Математический анализ", null },
                    { 2, new DateTime(2024, 9, 29, 6, 59, 54, 325, DateTimeKind.Utc).AddTicks(6395), null, false, "Линейная алгебра", null },
                    { 3, new DateTime(2024, 9, 29, 6, 59, 54, 325, DateTimeKind.Utc).AddTicks(6396), null, false, "Философия", null },
                    { 4, new DateTime(2024, 9, 29, 6, 59, 54, 325, DateTimeKind.Utc).AddTicks(6398), null, false, "История России", null },
                    { 5, new DateTime(2024, 9, 29, 6, 59, 54, 325, DateTimeKind.Utc).AddTicks(6399), null, false, "Физика", null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "created_at", "deleted_at", "first_name", "is_active", "is_deleted", "last_name", "points_count", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7784), null, "Илья", true, false, "Олейник", 0, null },
                    { 2, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7786), null, "Кашелот", true, false, "Кашов", 0, null },
                    { 3, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7788), null, "Андрей", true, false, "Чуба", 0, null },
                    { 4, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7789), null, "Глеб", true, false, "Сергеев", 0, null },
                    { 5, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7792), null, "Анастасия", true, false, "Каторга", 0, null },
                    { 6, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7793), null, "Алена", true, false, "БэбиБон", 0, null },
                    { 7, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7794), null, "Маст", true, false, "Хэв", 0, null },
                    { 8, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7796), null, "Аленка", true, false, "Радушная", 0, null },
                    { 9, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7798), null, "Каша", true, false, "Бэбибонов", 0, null },
                    { 10, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7799), null, "Чупачупс", true, false, "Архангельский", 0, null },
                    { 11, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7801), null, "Кама", true, false, "Пуля", 0, null },
                    { 10000, new DateTime(2024, 9, 29, 6, 59, 54, 326, DateTimeKind.Utc).AddTicks(7778), null, "Сережа", true, false, "Батист", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_answers_user_id",
                table: "answers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_title",
                table: "categories",
                column: "title",
                unique: true,
                filter: "is_deleted IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_questions_category_id",
                table: "questions",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_user_id",
                table: "questions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_reactions_answer_id",
                table: "reactions",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_reactions_question_id",
                table: "reactions",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_reactions_user_id",
                table: "reactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_id",
                table: "users",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reactions");

            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
