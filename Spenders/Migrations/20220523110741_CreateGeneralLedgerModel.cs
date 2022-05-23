using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spenders.Migrations
{
    public partial class CreateGeneralLedgerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Group",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Group",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Expenses",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GeneralLedgers",
                columns: table => new
                {
                    GeneralLedgerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupSpenderUserId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ExpenseId = table.Column<int>(nullable: false),
                    DateEntered = table.Column<DateTime>(nullable: false),
                    GroupSpendersUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedgers", x => x.GeneralLedgerId);
                    table.ForeignKey(
                        name: "FK_GeneralLedgers_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralLedgers_GroupSpendersUser_GroupSpendersUserID",
                        column: x => x.GroupSpendersUserID,
                        principalTable: "GroupSpendersUser",
                        principalColumn: "GroupSpendersUserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92a0dc94-a6f7-4d99-8784-c36bb5ce9a85", 0, "b1f2d49f-f8e4-4dad-8dc5-a8375e8917d7", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "15777357-e6d6-4dd3-ae4b-433970367234", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86b0a417-afa3-496b-8ffb-781217b5f174", 0, "c5a06692-f652-48b4-a59c-864b32867124", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "439bedc6-8bb0-4fbb-9469-b2499304f4a2", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5cb50584-a6de-4f13-ab38-0cd54b6b64d0", 0, "c6d88e7d-b6fe-4e6a-8261-e6b5ca3a5c87", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "2ab2b101-8d48-4dbb-842c-2d170687dcfb", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgers_ExpenseId",
                table: "GeneralLedgers",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgers_GroupSpendersUserID",
                table: "GeneralLedgers",
                column: "GroupSpendersUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralLedgers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cb50584-a6de-4f13-ab38-0cd54b6b64d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86b0a417-afa3-496b-8ffb-781217b5f174");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92a0dc94-a6f7-4d99-8784-c36bb5ce9a85");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Group",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Group",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e9cb1cc7-16a3-4117-b2b3-bd37b80f29a0", 0, "00c199bf-79b7-49b5-bcde-ff78f06b453e", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "142c413f-e654-4e05-a3c2-862bf6036388", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a66dd0bb-c79e-4950-8056-043911707340", 0, "7ea8f52f-df91-4d9a-9e39-66931f23f884", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "200457b8-9227-4d2e-a43d-2d6045d3aac1", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d98ba014-7273-4b4c-8721-8afe6c64b2dc", 0, "f2b02d09-c204-4f12-804d-034e490b43ae", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "b48aa48a-1f62-4eef-ac32-903925639a27", false, null });
        }
    }
}
