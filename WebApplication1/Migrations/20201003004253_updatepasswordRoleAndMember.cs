using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class updatepasswordRoleAndMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_member_MemberId",
                table: "role");

            migrationBuilder.DropIndex(
                name: "IX_role_MemberId",
                table: "role");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "role");

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "member",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "member",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "member",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "member",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "member",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "member",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_member_role_id",
                table: "member",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_member_role_role_id",
                table: "member",
                column: "role_id",
                principalTable: "role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_role_role_id",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_role_id",
                table: "member");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "member");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "member");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "role",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "member",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_role_MemberId",
                table: "role",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_role_member_MemberId",
                table: "role",
                column: "MemberId",
                principalTable: "member",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
