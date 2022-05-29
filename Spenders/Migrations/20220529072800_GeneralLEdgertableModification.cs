using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spenders.Migrations
{
    public partial class GeneralLEdgertableModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a63edb6-ee7d-4c17-b553-d8926684fdfe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d5ac5d2-8b2d-41ef-837f-002f814e8a58");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dee09b91-bba3-47ed-86df-2cb29dcea84a");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpenseDate",
                table: "GeneralLedgers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "985c2478-7fcb-429d-a5bb-7867965327cf", 0, "4b19e723-2f5e-4ef2-9105-2ac61120f5c7", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "8f9491ac-c4a3-4723-b1a6-e1e51ac88783", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f9799118-5f16-419b-b82d-487355ff2594", 0, "cf9cb6b5-9efc-45ff-a2b7-d47b302ad1ee", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "79596c7f-fd5e-4a41-9bc1-0d0d01d272f8", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "130c2ae4-c908-4d96-8ad9-d19ec5329cdd", 0, "c673454c-c2c2-46b4-96df-363a4a879db2", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "c7e1a55d-4c9e-434f-80a1-e11759486528", false, null });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralLedgers_GroupSpendersUser_GroupSpendersUserId",
                table: "GeneralLedgers");

            migrationBuilder.DropIndex(
                name: "IX_GeneralLedgers_GroupSpendersUserId",
                table: "GeneralLedgers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "130c2ae4-c908-4d96-8ad9-d19ec5329cdd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "985c2478-7fcb-429d-a5bb-7867965327cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9799118-5f16-419b-b82d-487355ff2594");

            migrationBuilder.DropColumn(
                name: "ExpenseDate",
                table: "GeneralLedgers");

            migrationBuilder.DropColumn(
                name: "GroupSpendersUserId",
                table: "GeneralLedgers");

            migrationBuilder.AddColumn<int>(
                name: "SpendersUserId",
                table: "GeneralLedgers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpendersUserId1",
                table: "GeneralLedgers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "groupID",
                table: "GeneralLedgers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a63edb6-ee7d-4c17-b553-d8926684fdfe", 0, "aabbb230-2864-48e2-9f66-f6596a6c72b5", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "c41fe38a-8190-4617-a0c1-aa94bd0486f5", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dee09b91-bba3-47ed-86df-2cb29dcea84a", 0, "74bdbca8-3d1e-4bac-a76d-095ebc95bbc6", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "c8c50449-6d19-40f8-96fa-12a2f7eeda94", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d5ac5d2-8b2d-41ef-837f-002f814e8a58", 0, "c7f228f8-03d2-448b-8f29-cdd0d5d11ded", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "173e0e0b-648b-4bb0-81e3-34a0e977eae3", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgers_SpendersUserId1",
                table: "GeneralLedgers",
                column: "SpendersUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgers_groupID",
                table: "GeneralLedgers",
                column: "groupID");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralLedgers_AspNetUsers_SpendersUserId1",
                table: "GeneralLedgers",
                column: "SpendersUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralLedgers_Group_groupID",
                table: "GeneralLedgers",
                column: "groupID",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
