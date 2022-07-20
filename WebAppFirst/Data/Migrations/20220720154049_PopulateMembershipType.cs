using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppFirst.Data.Migrations
{
    public partial class PopulateMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipType (Id,SignUpFee,DurationInMonths, DiscountRate, Name) VALUES (1,0,0,0,'Gratuit')");
            migrationBuilder.Sql("INSERT INTO MembershipType (Id,SignUpFee,DurationInMonths, DiscountRate, Name) VALUES (2,30,1,10,'Starter pack')");
            migrationBuilder.Sql("INSERT INTO MembershipType (Id,SignUpFee,DurationInMonths, DiscountRate, Name) VALUES (3,90,3,15,'Medium pack')");
            migrationBuilder.Sql("INSERT INTO MembershipType (Id,SignUpFee,DurationInMonths, DiscountRate, Name) VALUES (4,300,12,25,'Milioner')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
