using Microsoft.EntityFrameworkCore.Migrations;

namespace Spenders.Migrations
{
    public partial class MakeSmallTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSpendersUser_AspNetUsers_SpendersUserId1",
                table: "GroupSpendersUser");

            migrationBuilder.DropIndex(
                name: "IX_GroupSpendersUser_SpendersUserId1",
                table: "GroupSpendersUser");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d84d485-67b4-4bf7-b070-04982c8a0c4b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94a339f4-1fe8-474d-a9c3-03c0cde4fe48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b567d27e-dbe9-4526-8412-852cc11923ce");

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

            migrationBuilder.DropColumn(
                name: "SpendersUserId1",
                table: "GroupSpendersUser");

            migrationBuilder.AlterColumn<string>(
                name: "SpendersUserId",
                table: "GroupSpendersUser",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "585c5f0c-a0b4-4db7-b9d8-817617931021", 0, "13a0eee2-f566-45a4-ba1a-57d6d4256f7c", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "a80420be-fca6-4ee2-9783-5ae7555915df", false, null },
                    { "d8f19931-4174-4074-9d91-a474f46108fa", 0, "e2f5e26d-d15d-420c-afbe-9e30a9769a5f", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "ebc75d2a-54f0-43c6-8367-6d90fef712f9", false, null },
                    { "5a872ab1-62d1-4093-bbce-1a609206604c", 0, "1e612593-b72d-461a-bc39-fab7ce6a1ac9", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "e2b155af-bdb6-4309-8466-e5bf170a5df3", false, null }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ExpenseId", "GroupId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "New world" },
                    { 2, 1, "Take out" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupSpendersUser_SpendersUserId",
                table: "GroupSpendersUser",
                column: "SpendersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSpendersUser_AspNetUsers_SpendersUserId",
                table: "GroupSpendersUser",
                column: "SpendersUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSpendersUser_AspNetUsers_SpendersUserId",
                table: "GroupSpendersUser");

            migrationBuilder.DropIndex(
                name: "IX_GroupSpendersUser_SpendersUserId",
                table: "GroupSpendersUser");

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

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "SpendersUserId",
                table: "GroupSpendersUser",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpendersUserId1",
                table: "GroupSpendersUser",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "94a339f4-1fe8-474d-a9c3-03c0cde4fe48", 0, "c2b4142c-a44f-4bce-b85c-4d4dbbb00695", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "ae05c3b5-4e7d-4ac6-b781-d22512fcd79d", false, null },
                    { "0d84d485-67b4-4bf7-b070-04982c8a0c4b", 0, "152903bb-998d-4d48-afa3-4445ddc32bf9", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "3df074bc-910f-49bc-9da6-2d7f221a481f", false, null },
                    { "b567d27e-dbe9-4526-8412-852cc11923ce", 0, "2105b6c0-9a2c-43a6-9c1a-cb622e7127b6", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "eb138eef-b4f0-4cbb-85d5-c6a2e2818708", false, null }
                });

            migrationBuilder.InsertData(
                table: "GroupSpendersUser",
                columns: new[] { "GroupSpendersUserID", "GroupId", "SpendersUserId", "SpendersUserId1" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 2, 1, 2, null },
                    { 3, 2, 2, null },
                    { 4, 2, 3, null },
                    { 5, 3, 1, null },
                    { 6, 3, 2, null },
                    { 7, 3, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupSpendersUser_SpendersUserId1",
                table: "GroupSpendersUser",
                column: "SpendersUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSpendersUser_AspNetUsers_SpendersUserId1",
                table: "GroupSpendersUser",
                column: "SpendersUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
