using Microsoft.EntityFrameworkCore.Migrations;

namespace Spenders.Migrations
{
    public partial class InitialLogicTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "GroupSpendersUser",
                columns: table => new
                {
                    GroupSpendersUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    SpendersUserId = table.Column<int>(nullable: false),
                    SpendersUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSpendersUser", x => x.GroupSpendersUserID);
                    table.ForeignKey(
                        name: "FK_GroupSpendersUser_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSpendersUser_AspNetUsers_SpendersUserId1",
                        column: x => x.SpendersUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupSpendersUser_GroupId",
                table: "GroupSpendersUser",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSpendersUser_SpendersUserId1",
                table: "GroupSpendersUser",
                column: "SpendersUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupSpendersUser");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
