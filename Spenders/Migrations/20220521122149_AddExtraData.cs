using Microsoft.EntityFrameworkCore.Migrations;

namespace Spenders.Migrations
{
    public partial class AddExtraData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "585c5f0c-a0b4-4db7-b9d8-817617931021");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a872ab1-62d1-4093-bbce-1a609206604c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8f19931-4174-4074-9d91-a474f46108fa");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e9cb1cc7-16a3-4117-b2b3-bd37b80f29a0", 0, "00c199bf-79b7-49b5-bcde-ff78f06b453e", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "142c413f-e654-4e05-a3c2-862bf6036388", false, null },
                    { "a66dd0bb-c79e-4950-8056-043911707340", 0, "7ea8f52f-df91-4d9a-9e39-66931f23f884", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "200457b8-9227-4d2e-a43d-2d6045d3aac1", false, null },
                    { "d98ba014-7273-4b4c-8721-8afe6c64b2dc", 0, "f2b02d09-c204-4f12-804d-034e490b43ae", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "b48aa48a-1f62-4eef-ac32-903925639a27", false, null }
                });

            migrationBuilder.InsertData(
                table: "GroupSpendersUser",
                columns: new[] { "GroupSpendersUserID", "GroupId", "SpendersUserId" },
                values: new object[,]
                {
                    { 1, 1, "1" },
                    { 2, 1, "2" },
                    { 3, 2, "2" },
                    { 4, 2, "3" },
                    { 5, 3, "1" },
                    { 6, 3, "2" },
                    { 7, 3, "3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a66dd0bb-c79e-4950-8056-043911707340");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d98ba014-7273-4b4c-8721-8afe6c64b2dc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9cb1cc7-16a3-4117-b2b3-bd37b80f29a0");

            migrationBuilder.DeleteData(
                table: "GroupSpendersUser",
                keyColumn: "GroupSpendersUserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroupSpendersUser",
                keyColumn: "GroupSpendersUserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroupSpendersUser",
                keyColumn: "GroupSpendersUserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GroupSpendersUser",
                keyColumn: "GroupSpendersUserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroupSpendersUser",
                keyColumn: "GroupSpendersUserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GroupSpendersUser",
                keyColumn: "GroupSpendersUserID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GroupSpendersUser",
                keyColumn: "GroupSpendersUserID",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "585c5f0c-a0b4-4db7-b9d8-817617931021", 0, "13a0eee2-f566-45a4-ba1a-57d6d4256f7c", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "a80420be-fca6-4ee2-9783-5ae7555915df", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d8f19931-4174-4074-9d91-a474f46108fa", 0, "e2f5e26d-d15d-420c-afbe-9e30a9769a5f", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "ebc75d2a-54f0-43c6-8367-6d90fef712f9", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a872ab1-62d1-4093-bbce-1a609206604c", 0, "1e612593-b72d-461a-bc39-fab7ce6a1ac9", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "e2b155af-bdb6-4309-8466-e5bf170a5df3", false, null });
        }
    }
}
