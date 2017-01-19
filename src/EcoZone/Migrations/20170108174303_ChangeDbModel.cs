using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ecozone.Migrations
{
    public partial class ChangeDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_BlockType_TypeId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Units_UnitId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_AuthorId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Units_UnitId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitTags_Tag_TagId",
                table: "UnitTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitTags_Units_UnitId",
                table: "UnitTags");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitTags",
                table: "UnitTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockType",
                table: "BlockType");

            migrationBuilder.RenameTable(
                name: "UnitTags",
                newName: "UnitTagses");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "BlockType",
                newName: "BlockTypes");

            migrationBuilder.RenameIndex(
                name: "IX_UnitTags_UnitId",
                table: "UnitTagses",
                newName: "IX_UnitTagses_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitTags_TagId",
                table: "UnitTagses",
                newName: "IX_UnitTagses_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_UnitId",
                table: "Likes",
                newName: "IX_Likes_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_AuthorId",
                table: "Likes",
                newName: "IX_Likes_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UnitId",
                table: "Comments",
                newName: "IX_Comments_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitTagses",
                table: "UnitTagses",
                columns: new[] { "TagId", "UnitId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockTypes",
                table: "BlockTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_BlockTypes_TypeId",
                table: "Blocks",
                column: "TypeId",
                principalTable: "BlockTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Units_UnitId",
                table: "Comments",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_AuthorId",
                table: "Likes",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Units_UnitId",
                table: "Likes",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitTagses_Tags_TagId",
                table: "UnitTagses",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitTagses_Units_UnitId",
                table: "UnitTagses",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_BlockTypes_TypeId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Units_UnitId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_AuthorId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Units_UnitId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitTagses_Tags_TagId",
                table: "UnitTagses");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitTagses_Units_UnitId",
                table: "UnitTagses");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitTagses",
                table: "UnitTagses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockTypes",
                table: "BlockTypes");

            migrationBuilder.RenameTable(
                name: "UnitTagses",
                newName: "UnitTags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "BlockTypes",
                newName: "BlockType");

            migrationBuilder.RenameIndex(
                name: "IX_UnitTagses_UnitId",
                table: "UnitTags",
                newName: "IX_UnitTags_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitTagses_TagId",
                table: "UnitTags",
                newName: "IX_UnitTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UnitId",
                table: "Like",
                newName: "IX_Like_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_AuthorId",
                table: "Like",
                newName: "IX_Like_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UnitId",
                table: "Comment",
                newName: "IX_Comment_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "Comment",
                newName: "IX_Comment_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitTags",
                table: "UnitTags",
                columns: new[] { "TagId", "UnitId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockType",
                table: "BlockType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_BlockType_TypeId",
                table: "Blocks",
                column: "TypeId",
                principalTable: "BlockType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Units_UnitId",
                table: "Comment",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_AuthorId",
                table: "Like",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Units_UnitId",
                table: "Like",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitTags_Tag_TagId",
                table: "UnitTags",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitTags_Units_UnitId",
                table: "UnitTags",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
