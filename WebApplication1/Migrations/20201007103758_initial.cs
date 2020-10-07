using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Nickname = table.Column<string>(nullable: false),
                    dob = table.Column<DateTime>(type: "date", nullable: false),
                    role_id = table.Column<int>(nullable: false, defaultValue: 3),
                    gender = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    Biography = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.member_id);
                    table.ForeignKey(
                        name: "FK_member_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    event_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    member_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_event_member_member_id",
                        column: x => x.member_id,
                        principalTable: "member",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    schedule_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_id = table.Column<int>(nullable: false),
                    event_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_schedule_event_event_id",
                        column: x => x.event_id,
                        principalTable: "event",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "role_id", "role_type" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "role_id", "role_type" },
                values: new object[] { 2, "Coach" });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "role_id", "role_type" },
                values: new object[] { 3, "Member" });

            migrationBuilder.InsertData(
                table: "member",
                columns: new[] { "member_id", "Biography", "dob", "Email", "gender", "name", "Nickname", "Password", "role_id" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "M", "admin", "admin", "admin", 1 },
                    { 2, "coach", new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "coach@coach.com", "M", "coach", "coach", "coach", 2 },
                    { 4, "Roger Federer is a Swiss professional tennis player ", new DateTime(1981, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "roger@r.com", "M", "Roger Federer", "The King", "roger", 2 },
                    { 3, "new member", new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "member@member.com", "M", "John Doe", "jjdoe", "member", 3 }
                });

            migrationBuilder.InsertData(
                table: "event",
                columns: new[] { "event_id", "date", "description", "member_id", "name" },
                values: new object[] { 1, new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Free event, everyone is welcomed to join!", 2, "Fun With The Familiy" });

            migrationBuilder.InsertData(
                table: "event",
                columns: new[] { "event_id", "date", "description", "member_id", "name" },
                values: new object[] { 3, new DateTime(2018, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The weekly 1 on 1 matches", 2, "Weekly 1v1 Competitions" });

            migrationBuilder.InsertData(
                table: "event",
                columns: new[] { "event_id", "date", "description", "member_id", "name" },
                values: new object[] { 2, new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complimentary tennis lessons with Roger Federer", 4, "Roger Federer Free Lessons" });

            migrationBuilder.CreateIndex(
                name: "IX_event_member_id",
                table: "event",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_member_role_id",
                table: "member",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_event_id",
                table: "schedule",
                column: "event_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
