using Microsoft.EntityFrameworkCore.Migrations;

namespace ecozone.Migrations
{
    public partial class ApprovedUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                "IsApproved",
                "Units",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "IsApproved",
                "Units");
        }
    }
}