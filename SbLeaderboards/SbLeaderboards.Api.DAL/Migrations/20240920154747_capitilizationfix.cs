using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SbLeaderboards.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class capitilizationfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_players_PlayerId",
                table: "Stats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_players",
                table: "players");

            migrationBuilder.RenameTable(
                name: "players",
                newName: "Players");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "players");

            migrationBuilder.AddPrimaryKey(
                name: "PK_players",
                table: "players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_players_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
