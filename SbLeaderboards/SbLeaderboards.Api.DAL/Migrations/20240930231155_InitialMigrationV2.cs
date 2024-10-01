using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SbLeaderboards.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    McUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lastNameCheck = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ProfileType = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SkyblockExp = table.Column<int>(type: "int", nullable: false),
                    TamingExp = table.Column<int>(type: "int", nullable: false),
                    MiningExp = table.Column<int>(type: "int", nullable: false),
                    ForagingExp = table.Column<int>(type: "int", nullable: false),
                    EnchantingExp = table.Column<int>(type: "int", nullable: false),
                    CarpentryExp = table.Column<int>(type: "int", nullable: false),
                    FarmingExp = table.Column<int>(type: "int", nullable: false),
                    CombatExp = table.Column<int>(type: "int", nullable: false),
                    FishingExp = table.Column<int>(type: "int", nullable: false),
                    AlchemyExp = table.Column<int>(type: "int", nullable: false),
                    RunecraftingExp = table.Column<int>(type: "int", nullable: false),
                    SocialExp = table.Column<int>(type: "int", nullable: false),
                    CatacombsExp = table.Column<int>(type: "int", nullable: false),
                    HealerExp = table.Column<int>(type: "int", nullable: false),
                    ArcherExp = table.Column<int>(type: "int", nullable: false),
                    TankExp = table.Column<int>(type: "int", nullable: false),
                    BerserkerExp = table.Column<int>(type: "int", nullable: false),
                    MageExp = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stats_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_ProfileId",
                table: "Stats",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}