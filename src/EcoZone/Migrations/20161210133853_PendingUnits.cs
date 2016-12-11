using Microsoft.EntityFrameworkCore.Migrations;

namespace ecozone.Migrations
{
    public partial class PendingUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Blocks_Unit_UnitId",
                "Blocks");

            migrationBuilder.DropForeignKey(
                "FK_Comment_Unit_UnitId",
                "Comment");

            migrationBuilder.DropForeignKey(
                "FK_Like_Unit_UnitId",
                "Like");

            migrationBuilder.DropForeignKey(
                "FK_Unit_AspNetUsers_AuthorId",
                "Unit");

            migrationBuilder.DropForeignKey(
                "FK_UnitTags_Unit_UnitId",
                "UnitTags");

            migrationBuilder.DropPrimaryKey(
                "PK_Unit",
                "Unit");

            migrationBuilder.AddColumn<int>(
                "PendingUnitId",
                "Unit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "IsApproved",
                "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                "PK_Units",
                "Unit",
                "Id");

            migrationBuilder.CreateIndex(
                "IX_Units_PendingUnitId",
                "Unit",
                "PendingUnitId");

            migrationBuilder.AddForeignKey(
                "FK_Blocks_Units_UnitId",
                "Blocks",
                "UnitId",
                "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Comment_Units_UnitId",
                "Comment",
                "UnitId",
                "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Like_Units_UnitId",
                "Like",
                "UnitId",
                "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Units_AspNetUsers_AuthorId",
                "Unit",
                "AuthorId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Units_Units_PendingUnitId",
                "Unit",
                "PendingUnitId",
                "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_UnitTags_Units_UnitId",
                "UnitTags",
                "UnitId",
                "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                "IX_Unit_AuthorId",
                table: "Unit",
                newName: "IX_Units_AuthorId");

            migrationBuilder.RenameTable(
                "Unit",
                newName: "Units");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Blocks_Units_UnitId",
                "Blocks");

            migrationBuilder.DropForeignKey(
                "FK_Comment_Units_UnitId",
                "Comment");

            migrationBuilder.DropForeignKey(
                "FK_Like_Units_UnitId",
                "Like");

            migrationBuilder.DropForeignKey(
                "FK_Units_AspNetUsers_AuthorId",
                "Units");

            migrationBuilder.DropForeignKey(
                "FK_Units_Units_PendingUnitId",
                "Units");

            migrationBuilder.DropForeignKey(
                "FK_UnitTags_Units_UnitId",
                "UnitTags");

            migrationBuilder.DropPrimaryKey(
                "PK_Units",
                "Units");

            migrationBuilder.DropIndex(
                "IX_Units_PendingUnitId",
                "Units");

            migrationBuilder.DropColumn(
                "PendingUnitId",
                "Units");

            migrationBuilder.DropColumn(
                "IsApproved",
                "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                "PK_Unit",
                "Units",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Blocks_Unit_UnitId",
                "Blocks",
                "UnitId",
                "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Comment_Unit_UnitId",
                "Comment",
                "UnitId",
                "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Like_Unit_UnitId",
                "Like",
                "UnitId",
                "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Unit_AspNetUsers_AuthorId",
                "Units",
                "AuthorId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_UnitTags_Unit_UnitId",
                "UnitTags",
                "UnitId",
                "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                "IX_Units_AuthorId",
                table: "Units",
                newName: "IX_Unit_AuthorId");

            migrationBuilder.RenameTable(
                "Units",
                newName: "Unit");
        }
    }
}