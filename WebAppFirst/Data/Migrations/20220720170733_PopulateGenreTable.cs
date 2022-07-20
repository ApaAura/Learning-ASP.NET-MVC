using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppFirst.Data.Migrations
{
    public partial class PopulateGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Name) VALUES ('Drama'),('cuGandacei'),('Comedy'),('pentruBoieri'),('Documentar'),('pentruSaraci'),('cuLimbricei')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
