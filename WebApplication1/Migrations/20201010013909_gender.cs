using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "member",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);

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
            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "member",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 200);

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
