using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace PokerWebsite.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokerWebsite.Core.Domain.Achievements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SPName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "PokerWebsite.Core.Domain.Images",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "PokerWebsite.Core.Domain.Players",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "PokerWebsite.Core.Domain.Venues",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    Descrition = table.Column<string>(nullable: true),
                    Hour = table.Column<int>(nullable: false),
                    ImageID = table.Column<int>(nullable: true),
                    Minute = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Venue_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "PokerWebsite.Core.Domain.Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "PokerWebsite.Core.Domain.PlayerAchievements",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false),
                    AchievementID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAchievement", x => new { x.PlayerID, x.AchievementID });
                    table.ForeignKey(
                        name: "FK_PlayerAchievement_Achievement_AchievementID",
                        column: x => x.AchievementID,
                        principalTable: "PokerWebsite.Core.Domain.Achievements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerAchievement_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "PokerWebsite.Core.Domain.Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PokerWebsite.Core.Domain.Tournaments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    NumberOfPlayers = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    VenueID = table.Column<int>(nullable: true),
                    WinnerImageID = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tournament_Venue_VenueID",
                        column: x => x.VenueID,
                        principalTable: "PokerWebsite.Core.Domain.Venues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournament_Image_WinnerImageID",
                        column: x => x.WinnerImageID,
                        principalTable: "PokerWebsite.Core.Domain.Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "PokerWebsite.Core.Domain.Results",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false),
                    TournamentID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Place = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => new { x.PlayerID, x.TournamentID });
                    table.ForeignKey(
                        name: "FK_Result_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "PokerWebsite.Core.Domain.Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_Tournament_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "PokerWebsite.Core.Domain.Tournaments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("PokerWebsite.Core.Domain.PlayerAchievements");
            migrationBuilder.DropTable("PokerWebsite.Core.Domain.Results");
            migrationBuilder.DropTable("PokerWebsite.Core.Domain.Achievements");
            migrationBuilder.DropTable("PokerWebsite.Core.Domain.Players");
            migrationBuilder.DropTable("PokerWebsite.Core.Domain.Tournaments");
            migrationBuilder.DropTable("PokerWebsite.Core.Domain.Venues");
            migrationBuilder.DropTable("PokerWebsite.Core.Domain.Images");
        }
    }
}
