using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SbLeaderboards.Api.DAL.Migrations.MySqlMigrations
{
    /// <inheritdoc />
    public partial class MySqlInitialV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    McUuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LastNameCheck = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastStatUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CuteName = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SkyblockExp = table.Column<long>(type: "bigint", nullable: false),
                    TamingExp = table.Column<long>(type: "bigint", nullable: false),
                    MiningExp = table.Column<long>(type: "bigint", nullable: false),
                    ForagingExp = table.Column<long>(type: "bigint", nullable: false),
                    EnchantingExp = table.Column<long>(type: "bigint", nullable: false),
                    CarpentryExp = table.Column<long>(type: "bigint", nullable: false),
                    FarmingExp = table.Column<long>(type: "bigint", nullable: false),
                    CombatExp = table.Column<long>(type: "bigint", nullable: false),
                    FishingExp = table.Column<long>(type: "bigint", nullable: false),
                    AlchemyExp = table.Column<long>(type: "bigint", nullable: false),
                    RunecraftingExp = table.Column<long>(type: "bigint", nullable: false),
                    SocialExp = table.Column<long>(type: "bigint", nullable: false),
                    CatacombsExp = table.Column<long>(type: "bigint", nullable: false),
                    HealerExp = table.Column<long>(type: "bigint", nullable: false),
                    ArcherExp = table.Column<long>(type: "bigint", nullable: false),
                    TankExp = table.Column<long>(type: "bigint", nullable: false),
                    BerserkerExp = table.Column<long>(type: "bigint", nullable: false),
                    MageExp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlayerId",
                table: "Profiles",
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
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
