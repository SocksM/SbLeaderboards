using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SbLeaderboards.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    McUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ProfileType = table.Column<int>(type: "int", nullable: false),
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
                    MageExp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
