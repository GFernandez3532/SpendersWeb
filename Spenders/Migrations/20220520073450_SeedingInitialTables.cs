using Microsoft.EntityFrameworkCore.Migrations;

namespace Spenders.Migrations
{
    public partial class SeedingInitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b0483c8b-d986-4a8c-b69b-9b5818c1736e", 0, "b4c3a87d-ead8-47eb-94fc-ac88847aa86c", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "a4ca493a-4ab0-4794-80c0-feee5f16634a", false, null },
                    { "90d4a72d-9c04-4eab-8511-54bd704134a9", 0, "08aa430f-064a-4553-af1c-1063c649eb5f", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "d41fa4c0-e38c-4c42-9b2f-da9f9325847a", false, null },
                    { "03278b25-2f45-470a-af22-20afc060f179", 0, "73c51470-2307-4cea-a6e5-1fde3f06dd10", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "2f753821-d49c-43c6-a82e-032c2dfc3599", false, null }
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "GroupId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Spendings at home", "Spending at home" },
                    { 2, "Spendings at the office", "Spending at home" },
                    { 3, "Spendings during holiday", "Spending at home" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03278b25-2f45-470a-af22-20afc060f179");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90d4a72d-9c04-4eab-8511-54bd704134a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0483c8b-d986-4a8c-b69b-9b5818c1736e");

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

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 3);
        }
    }
}
