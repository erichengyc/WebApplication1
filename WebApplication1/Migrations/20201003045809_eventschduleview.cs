using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class eventschduleview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "event",
                columns: new[] { "event_id", "date", "description", "member_id", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Free event, everyone is welcomed to join!", 2, "Fun With The Familiy" },
                    { 3, new DateTime(2018, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The weekly 1 on 1 matches", 2, "Weekly 1v1 Competitions" }
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
                columns: new[] { "Password", "role_id" },
                values: new object[] { "coach", 2 });

            migrationBuilder.InsertData(
                table: "member",
                columns: new[] { "member_id", "Biography", "dob", "Email", "gender", "name", "Nickname", "Password", "role_id" },
                values: new object[,]
                {
                    { 3, "new member", new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "member@member.com", "M", "John Doe", "jjdoe", "member", 3 },
                    { 4, "Roger Federer is a Swiss professional tennis player ", new DateTime(1981, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "roger@r.com", "M", "Roger Federer", "The King", "roger", 2 }
                });

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

            migrationBuilder.InsertData(
                table: "event",
                columns: new[] { "event_id", "date", "description", "member_id", "name" },
                values: new object[] { 2, new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complimentary tennis lessons with Roger Federer", 4, "Roger Federer Free Lessons" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "event",
                keyColumn: "event_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "event",
                keyColumn: "event_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "event",
                keyColumn: "event_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "member",
                keyColumn: "member_id",
                keyValue: 4);

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
                columns: new[] { "Password", "role_id" },
                values: new object[] { "Member", 2 });

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
