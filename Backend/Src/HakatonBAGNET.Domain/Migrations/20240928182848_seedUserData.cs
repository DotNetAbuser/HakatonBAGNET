using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HakatonBAGNET.Domain.Migrations
{
    /// <inheritdoc />
    public partial class seedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 18, 28, 47, 933, DateTimeKind.Utc).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 18, 28, 47, 933, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 18, 28, 47, 933, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 18, 28, 47, 933, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 18, 28, 47, 933, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "created_at", "deleted_at", "first_name", "is_active", "is_deleted", "last_name", "points_count", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6062), null, "Илья", true, false, "Олейник", 0, null },
                    { 2, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6064), null, "Кашелот", true, false, "Кашов", 0, null },
                    { 3, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6066), null, "Андрей", true, false, "Чуба", 0, null },
                    { 4, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6067), null, "Глеб", true, false, "Сергеев", 0, null },
                    { 5, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6070), null, "Анастасия", true, false, "Каторга", 0, null },
                    { 6, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6071), null, "Алена", true, false, "БэбиБон", 0, null },
                    { 7, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6072), null, "Маст", true, false, "Хэв", 0, null },
                    { 8, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6074), null, "Аленка", true, false, "Радушная", 0, null },
                    { 9, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6076), null, "Каша", true, false, "Бэбибонов", 0, null },
                    { 10, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6077), null, "Чупачупс", true, false, "Архангельский", 0, null },
                    { 11, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6078), null, "Кама", true, false, "Пуля", 0, null },
                    { 10000, new DateTime(2024, 9, 28, 18, 28, 47, 934, DateTimeKind.Utc).AddTicks(6053), null, "Сережа", true, false, "Батист", 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 10000);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 12, 46, 12, 827, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 12, 46, 12, 827, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 12, 46, 12, 827, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 12, 46, 12, 827, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 9, 28, 12, 46, 12, 827, DateTimeKind.Utc).AddTicks(4584));
        }
    }
}
