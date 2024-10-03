using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SbLeaderboards.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProfileType_to_ProfileCutename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Stats");

            migrationBuilder.RenameColumn(
                name: "ProfileType",
                table: "Profiles",
                newName: "CuteName");

            migrationBuilder.RenameColumn(
                name: "lastNameCheck",
                table: "Players",
                newName: "LastNameCheck");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlayerId",
                table: "Profiles",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Players_PlayerId",
                table: "Profiles",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Players_PlayerId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_PlayerId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "CuteName",
                table: "Profiles",
                newName: "ProfileType");

            migrationBuilder.RenameColumn(
                name: "LastNameCheck",
                table: "Players",
                newName: "lastNameCheck");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
