using Microsoft.EntityFrameworkCore.Migrations;

namespace Spenders.Migrations
{
    public partial class GeneralLedgerValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1f90dc8-e2be-4d0c-9a70-eebeedfe7d74", 0, "6c30fbe2-1626-4684-b563-f94e40dcdf11", "Gonza@Gmail.com", false, "Gonzalo", "Fernandez", false, null, null, null, null, null, false, "4ddc4aa7-0b7b-41a8-9b32-323c1f53e84c", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "660d472e-679f-422d-aded-13155da4034c", 0, "e6c59625-0f82-4bee-bac1-4f9599fc7a6c", "Ashley@Gmail.com", false, "Ashley", "Hague", false, null, null, null, null, null, false, "67bb9546-75b8-43c7-8725-b1b4e0411ff8", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "773316dc-f71f-44a1-b876-a28fdeb14d6f", 0, "b65f4e8d-74ee-456a-9ba6-771e3165c8c5", "Eduardo@Gmail.com", false, "Eduardo", "Simonson", false, null, null, null, null, null, false, "023c5d46-cfc3-43cb-8c38-5e0fb1584091", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "660d472e-679f-422d-aded-13155da4034c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "773316dc-f71f-44a1-b876-a28fdeb14d6f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1f90dc8-e2be-4d0c-9a70-eebeedfe7d74");

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
    }
}
