using Microsoft.EntityFrameworkCore.Migrations;

namespace BopHubData.Migrations
{
    public partial class populategenretable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO GENRES (Id, Name) VALUES(1, 'Afro')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id, Name) VALUES(2, 'Jazz')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id, Name) VALUES(3, 'Blues')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id, Name) VALUES(4, 'Rock')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres WHERE Name in ('Afro', 'Jazz', 'Blues', 'Rock'");
        }
    }
}
