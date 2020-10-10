using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_event_event_id",
                table: "schedule");

            migrationBuilder.AlterColumn<int>(
                name: "event_id",
                table: "schedule",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_schedule_member_id",
                table: "schedule",
                column: "member_id");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_event_event_id",
                table: "schedule",
                column: "event_id",
                principalTable: "event",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_member_member_id",
                table: "schedule",
                column: "member_id",
                principalTable: "member",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_event_event_id",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_member_member_id",
                table: "schedule");

            migrationBuilder.DropIndex(
                name: "IX_schedule_member_id",
                table: "schedule");

            migrationBuilder.AlterColumn<int>(
                name: "event_id",
                table: "schedule",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_event_event_id",
                table: "schedule",
                column: "event_id",
                principalTable: "event",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
