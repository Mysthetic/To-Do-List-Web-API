using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class todo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoEntryTodoTag");

            migrationBuilder.DropTable(
                name: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TodoEntryTodoTag",
                columns: table => new
                {
                    TaggedEntriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoEntryTodoTag", x => new { x.TaggedEntriesId, x.TagsID });
                    table.ForeignKey(
                        name: "FK_TodoEntryTodoTag_Tags_TagsID",
                        column: x => x.TagsID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoEntryTodoTag_TodoEntries_TaggedEntriesId",
                        column: x => x.TaggedEntriesId,
                        principalTable: "TodoEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoEntryTodoTag_TagsID",
                table: "TodoEntryTodoTag",
                column: "TagsID");
        }
    }
}
