using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class updateMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_role_RoleTypeRoleId",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_RoleTypeRoleId",
                table: "member");

            migrationBuilder.DropColumn(
                name: "RoleTypeRoleId",
                table: "member");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "role",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "member",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "member");

            migrationBuilder.AddColumn<int>(
                name: "RoleTypeRoleId",
                table: "member",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_member_RoleTypeRoleId",
                table: "member",
                column: "RoleTypeRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_member_role_RoleTypeRoleId",
                table: "member",
                column: "RoleTypeRoleId",
                principalTable: "role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
