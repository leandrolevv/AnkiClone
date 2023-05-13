using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anki.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Front = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    Back = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    DeckId = table.Column<int>(type: "int", nullable: false),
                    DeckId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Deck",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Deck_DeckId1",
                        column: x => x.DeckId1,
                        principalTable: "Deck",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardTag",
                columns: table => new
                {
                    Card_Id = table.Column<int>(type: "int", nullable: false),
                    Tag_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTag", x => new { x.Card_Id, x.Tag_Id });
                    table.ForeignKey(
                        name: "FK_CARDTAG_CARDID",
                        column: x => x.Card_Id,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CARDTAG_TAGID",
                        column: x => x.Tag_Id,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_DeckId",
                table: "Card",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_DeckId1",
                table: "Card",
                column: "DeckId1");

            migrationBuilder.CreateIndex(
                name: "IX_CardTag_Tag_Id",
                table: "CardTag",
                column: "Tag_Id");

            migrationBuilder.CreateIndex(
                name: "IDX_Title_Deck",
                table: "Deck",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Text",
                table: "Tag",
                column: "Text",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Deck");
        }
    }
}
