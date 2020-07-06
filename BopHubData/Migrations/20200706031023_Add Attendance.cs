using Microsoft.EntityFrameworkCore.Migrations;

namespace BopHubData.Migrations
{
    public partial class AddAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    BopId = table.Column<int>(nullable: false),
                    AttendeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => new { x.BopId, x.AttendeeId });
                    table.ForeignKey(
                        name: "FK_Attendances_Accounts_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Bops_BopId",
                        column: x => x.BopId,
                        principalTable: "Bops",
                        principalColumn: "BopId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AttendeeId",
                table: "Attendances",
                column: "AttendeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");
        }
    }
}
