using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coach",
                columns: table => new
                {
                    coach_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    nickname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: false),
                    biography = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coach", x => x.coach_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_type = table.Column<string>(nullable: true, defaultValue: "Member")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    member_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Nickname = table.Column<string>(nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: false),
                    RoleTypeRoleId = table.Column<int>(nullable: true),
                    gender = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Biography = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.member_id);
                    table.ForeignKey(
                        name: "FK_member_role_RoleTypeRoleId",
                        column: x => x.RoleTypeRoleId,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    event_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    MemberId = table.Column<int>(nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_event_member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "member",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    schedule_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_schedule_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_schedule_member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "member",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_MemberId",
                table: "event",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_member_RoleTypeRoleId",
                table: "member",
                column: "RoleTypeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_EventId",
                table: "schedule",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_MemberId",
                table: "schedule",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coach");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
