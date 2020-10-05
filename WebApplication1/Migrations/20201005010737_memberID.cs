using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class memberID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coach");

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 1,
                column: "role_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 2,
                column: "role_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 3,
                column: "role_id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 4,
                column: "role_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "role_id",
                keyValue: 1,
                column: "role_type",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "role_id",
                keyValue: 2,
                column: "role_type",
                value: "Coach");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "role_id",
                keyValue: 3,
                column: "role_type",
                value: "Member");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coach",
                columns: table => new
                {
                    coach_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biography = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coach", x => x.coach_id);
                });

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 1,
                column: "role_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 2,
                column: "role_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 3,
                column: "role_id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 4,
                column: "role_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "role_id",
                keyValue: 1,
                column: "role_type",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "role_id",
                keyValue: 2,
                column: "role_type",
                value: "Coach");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "role_id",
                keyValue: 3,
                column: "role_type",
                value: "Member");
        }
    }
}
