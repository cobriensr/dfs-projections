using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasySports.Infrastructure.Data.Migrations.NFL
{
    /// <inheritdoc />
    public partial class InitialNFL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quarters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuarterId = table.Column<int>(type: "integer", nullable: false),
                    ScoreId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Awayteamscore = table.Column<string>(type: "text", nullable: true),
                    Hometeamscore = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<int>(type: "integer", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    Playingsurface = table.Column<string>(type: "text", nullable: true),
                    Geolat = table.Column<string>(type: "text", nullable: true),
                    Geolong = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stadiums_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    Opponentscore = table.Column<string>(type: "text", nullable: true),
                    Totalscore = table.Column<int>(type: "integer", nullable: true),
                    Scorequarter1 = table.Column<int>(type: "integer", nullable: true),
                    Scorequarter2 = table.Column<int>(type: "integer", nullable: true),
                    Scorequarter3 = table.Column<int>(type: "integer", nullable: true),
                    Scorequarter4 = table.Column<int>(type: "integer", nullable: true),
                    Scoreovertime = table.Column<int>(type: "integer", nullable: true),
                    Timeofpossession = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Firstdowns = table.Column<string>(type: "text", nullable: true),
                    Firstdownsbyrushing = table.Column<string>(type: "text", nullable: true),
                    Firstdownsbypassing = table.Column<string>(type: "text", nullable: true),
                    Firstdownsbypenalty = table.Column<string>(type: "text", nullable: true),
                    Offensiveplays = table.Column<string>(type: "text", nullable: true),
                    Offensiveyards = table.Column<string>(type: "text", nullable: true),
                    Offensiveyardsperplay = table.Column<string>(type: "text", nullable: true),
                    Touchdowns = table.Column<int>(type: "integer", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Completionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passerrating = table.Column<string>(type: "text", nullable: true),
                    Thirddownattempts = table.Column<string>(type: "text", nullable: true),
                    Thirddownconversions = table.Column<string>(type: "text", nullable: true),
                    Thirddownpercentage = table.Column<string>(type: "text", nullable: true),
                    Fourthdownattempts = table.Column<string>(type: "text", nullable: true),
                    Fourthdownconversions = table.Column<string>(type: "text", nullable: true),
                    Fourthdownpercentage = table.Column<string>(type: "text", nullable: true),
                    Redzoneattempts = table.Column<string>(type: "text", nullable: true),
                    Redzoneconversions = table.Column<string>(type: "text", nullable: true),
                    Goaltogoattempts = table.Column<string>(type: "text", nullable: true),
                    Goaltogoconversions = table.Column<string>(type: "text", nullable: true),
                    Penalties = table.Column<string>(type: "text", nullable: true),
                    Penaltyyards = table.Column<string>(type: "text", nullable: true),
                    Fumbles = table.Column<string>(type: "text", nullable: true),
                    Fumbleslost = table.Column<string>(type: "text", nullable: true),
                    Timessacked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timessackedyards = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Punts = table.Column<string>(type: "text", nullable: true),
                    Puntyards = table.Column<string>(type: "text", nullable: true),
                    Puntaverage = table.Column<string>(type: "text", nullable: true),
                    Giveaways = table.Column<string>(type: "text", nullable: true),
                    Takeaways = table.Column<string>(type: "text", nullable: true),
                    Turnoverdifferential = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter1 = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter2 = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter3 = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter4 = table.Column<string>(type: "text", nullable: true),
                    Opponentscoreovertime = table.Column<string>(type: "text", nullable: true),
                    Opponenttimeofpossession = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdownsbyrushing = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdownsbypassing = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdownsbypenalty = table.Column<string>(type: "text", nullable: true),
                    Opponentoffensiveplays = table.Column<string>(type: "text", nullable: true),
                    Opponentoffensiveyards = table.Column<string>(type: "text", nullable: true),
                    Opponentoffensiveyardsperplay = table.Column<string>(type: "text", nullable: true),
                    Opponenttouchdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingyards = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingcompletions = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingyards = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentpassinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Opponentcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentpasserrating = table.Column<string>(type: "text", nullable: true),
                    Opponentthirddownattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentthirddownconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentthirddownpercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentfourthdownattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentfourthdownconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentfourthdownpercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentredzoneattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentredzoneconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentgoaltogoattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentgoaltogoconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentpenalties = table.Column<string>(type: "text", nullable: true),
                    Opponentpenaltyyards = table.Column<string>(type: "text", nullable: true),
                    Opponentfumbles = table.Column<string>(type: "text", nullable: true),
                    Opponentfumbleslost = table.Column<string>(type: "text", nullable: true),
                    Opponenttimessacked = table.Column<string>(type: "text", nullable: true),
                    Opponenttimessackedyards = table.Column<string>(type: "text", nullable: true),
                    Opponentquarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Opponenttacklesforloss = table.Column<string>(type: "text", nullable: true),
                    Opponentpunts = table.Column<string>(type: "text", nullable: true),
                    Opponentpuntyards = table.Column<string>(type: "text", nullable: true),
                    Opponentpuntaverage = table.Column<string>(type: "text", nullable: true),
                    Opponentgiveaways = table.Column<string>(type: "text", nullable: true),
                    Opponenttakeaways = table.Column<string>(type: "text", nullable: true),
                    Opponentturnoverdifferential = table.Column<string>(type: "text", nullable: true),
                    Redzonepercentage = table.Column<string>(type: "text", nullable: true),
                    Goaltogopercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentredzonepercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentgoaltogopercentage = table.Column<string>(type: "text", nullable: true),
                    Extrapointkickingattempts = table.Column<string>(type: "text", nullable: true),
                    Extrapointkickingconversions = table.Column<string>(type: "text", nullable: true),
                    Extrapointshadblocked = table.Column<string>(type: "text", nullable: true),
                    Extrapointpassingattempts = table.Column<string>(type: "text", nullable: true),
                    Extrapointpassingconversions = table.Column<string>(type: "text", nullable: true),
                    Extrapointrushingattempts = table.Column<string>(type: "text", nullable: true),
                    Extrapointrushingconversions = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalattempts = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Opponentextrapointkickingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointkickingconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointshadblocked = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointpassingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointpassingconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointrushingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointrushingconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentfieldgoalattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentfieldgoalsmade = table.Column<string>(type: "text", nullable: true),
                    Solotackles = table.Column<string>(type: "text", nullable: true),
                    Assistedtackles = table.Column<string>(type: "text", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Passesdefended = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Opponentsolotackles = table.Column<string>(type: "text", nullable: true),
                    Opponentassistedtackles = table.Column<string>(type: "text", nullable: true),
                    Opponentsacks = table.Column<string>(type: "text", nullable: true),
                    Opponentsackyards = table.Column<string>(type: "text", nullable: true),
                    Opponentpassesdefended = table.Column<string>(type: "text", nullable: true),
                    Opponentfumblesforced = table.Column<string>(type: "text", nullable: true),
                    Opponentfumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Teamid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gamekey = table.Column<string>(type: "text", nullable: true),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Awayteam = table.Column<string>(type: "text", nullable: true),
                    Hometeam = table.Column<string>(type: "text", nullable: true),
                    Awayscore = table.Column<string>(type: "text", nullable: true),
                    Homescore = table.Column<string>(type: "text", nullable: true),
                    Pointspread = table.Column<int>(type: "integer", nullable: true),
                    Overunder = table.Column<decimal>(type: "numeric", nullable: true),
                    Awayscorequarter1 = table.Column<string>(type: "text", nullable: true),
                    Awayscorequarter2 = table.Column<string>(type: "text", nullable: true),
                    Awayscorequarter3 = table.Column<string>(type: "text", nullable: true),
                    Awayscorequarter4 = table.Column<string>(type: "text", nullable: true),
                    Awayscoreovertime = table.Column<string>(type: "text", nullable: true),
                    Homescorequarter1 = table.Column<string>(type: "text", nullable: true),
                    Homescorequarter2 = table.Column<string>(type: "text", nullable: true),
                    Homescorequarter3 = table.Column<string>(type: "text", nullable: true),
                    Homescorequarter4 = table.Column<string>(type: "text", nullable: true),
                    Homescoreovertime = table.Column<string>(type: "text", nullable: true),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    Forecasttemplow = table.Column<string>(type: "text", nullable: true),
                    Forecasttemphigh = table.Column<string>(type: "text", nullable: true),
                    Forecastdescription = table.Column<string>(type: "text", nullable: true),
                    Forecastwindchill = table.Column<string>(type: "text", nullable: true),
                    Forecastwindspeed = table.Column<string>(type: "text", nullable: true),
                    Awayteammoneyline = table.Column<string>(type: "text", nullable: true),
                    Hometeammoneyline = table.Column<string>(type: "text", nullable: true),
                    ScoreId = table.Column<int>(type: "integer", nullable: false),
                    Neutralvenue = table.Column<string>(type: "text", nullable: true),
                    Overpayout = table.Column<decimal>(type: "numeric", nullable: true),
                    Underpayout = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Conference = table.Column<string>(type: "text", nullable: true),
                    Division = table.Column<string>(type: "text", nullable: true),
                    Fullname = table.Column<string>(type: "text", nullable: true),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    Byeweek = table.Column<string>(type: "text", nullable: true),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Averagedraftpositionppr = table.Column<decimal>(type: "numeric", nullable: true),
                    Primarycolor = table.Column<string>(type: "text", nullable: true),
                    Secondarycolor = table.Column<string>(type: "text", nullable: true),
                    Tertiarycolor = table.Column<string>(type: "text", nullable: true),
                    Quaternarycolor = table.Column<string>(type: "text", nullable: true),
                    Wikipedialogourl = table.Column<string>(type: "text", nullable: true),
                    Wikipediawordmarkurl = table.Column<string>(type: "text", nullable: true),
                    Draftkingsname = table.Column<string>(type: "text", nullable: true),
                    DraftKingsPlayerId = table.Column<int>(type: "integer", nullable: false),
                    Fanduelname = table.Column<string>(type: "text", nullable: true),
                    Fanduelplayerid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: true),
                    Birthdate = table.Column<string>(type: "text", nullable: true),
                    College = table.Column<string>(type: "text", nullable: true),
                    Experience = table.Column<int>(type: "integer", nullable: true),
                    Fantasyposition = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Photourl = table.Column<string>(type: "text", nullable: true),
                    Byeweek = table.Column<string>(type: "text", nullable: true),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Collegedraftteam = table.Column<string>(type: "text", nullable: true),
                    Collegedraftyear = table.Column<string>(type: "text", nullable: true),
                    Collegedraftround = table.Column<string>(type: "text", nullable: true),
                    Collegedraftpick = table.Column<string>(type: "text", nullable: true),
                    Isundraftedfreeagent = table.Column<bool>(type: "boolean", nullable: true),
                    FanDuelPlayerId = table.Column<int>(type: "integer", nullable: false),
                    DraftKingsPlayerId = table.Column<int>(type: "integer", nullable: false),
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    Fanduelname = table.Column<string>(type: "text", nullable: true),
                    Draftkingsname = table.Column<string>(type: "text", nullable: true),
                    Teamid = table.Column<string>(type: "text", nullable: true),
                    NFLTeamId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_NFLTeamId",
                        column: x => x.NFLTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Conference = table.Column<string>(type: "text", nullable: true),
                    Division = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Ties = table.Column<string>(type: "text", nullable: true),
                    Percentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Pointsfor = table.Column<int>(type: "integer", nullable: true),
                    Pointsagainst = table.Column<int>(type: "integer", nullable: true),
                    Netpoints = table.Column<string>(type: "text", nullable: true),
                    Touchdowns = table.Column<int>(type: "integer", nullable: true),
                    Divisionwins = table.Column<string>(type: "text", nullable: true),
                    Divisionlosses = table.Column<string>(type: "text", nullable: true),
                    Conferencewins = table.Column<string>(type: "text", nullable: true),
                    Conferencelosses = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    Divisionties = table.Column<string>(type: "text", nullable: true),
                    Conferenceties = table.Column<string>(type: "text", nullable: true),
                    Divisionrank = table.Column<string>(type: "text", nullable: true),
                    Conferencerank = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standings_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    Opponentscore = table.Column<string>(type: "text", nullable: true),
                    Totalscore = table.Column<int>(type: "integer", nullable: true),
                    Stadium = table.Column<string>(type: "text", nullable: true),
                    Scorequarter1 = table.Column<int>(type: "integer", nullable: true),
                    Scorequarter2 = table.Column<int>(type: "integer", nullable: true),
                    Scorequarter3 = table.Column<int>(type: "integer", nullable: true),
                    Scorequarter4 = table.Column<int>(type: "integer", nullable: true),
                    Scoreovertime = table.Column<int>(type: "integer", nullable: true),
                    Timeofpossessionminutes = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timeofpossessionseconds = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timeofpossession = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Firstdowns = table.Column<string>(type: "text", nullable: true),
                    Firstdownsbyrushing = table.Column<string>(type: "text", nullable: true),
                    Firstdownsbypassing = table.Column<string>(type: "text", nullable: true),
                    Firstdownsbypenalty = table.Column<string>(type: "text", nullable: true),
                    Offensiveplays = table.Column<string>(type: "text", nullable: true),
                    Offensiveyards = table.Column<string>(type: "text", nullable: true),
                    Offensiveyardsperplay = table.Column<string>(type: "text", nullable: true),
                    Touchdowns = table.Column<int>(type: "integer", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Completionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passerrating = table.Column<string>(type: "text", nullable: true),
                    Thirddownattempts = table.Column<string>(type: "text", nullable: true),
                    Thirddownconversions = table.Column<string>(type: "text", nullable: true),
                    Thirddownpercentage = table.Column<string>(type: "text", nullable: true),
                    Fourthdownattempts = table.Column<string>(type: "text", nullable: true),
                    Fourthdownconversions = table.Column<string>(type: "text", nullable: true),
                    Fourthdownpercentage = table.Column<string>(type: "text", nullable: true),
                    Redzoneattempts = table.Column<string>(type: "text", nullable: true),
                    Redzoneconversions = table.Column<string>(type: "text", nullable: true),
                    Goaltogoattempts = table.Column<string>(type: "text", nullable: true),
                    Goaltogoconversions = table.Column<string>(type: "text", nullable: true),
                    Penalties = table.Column<string>(type: "text", nullable: true),
                    Penaltyyards = table.Column<string>(type: "text", nullable: true),
                    Fumbles = table.Column<string>(type: "text", nullable: true),
                    Fumbleslost = table.Column<string>(type: "text", nullable: true),
                    Timessacked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timessackedyards = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Punts = table.Column<string>(type: "text", nullable: true),
                    Puntyards = table.Column<string>(type: "text", nullable: true),
                    Puntaverage = table.Column<string>(type: "text", nullable: true),
                    Giveaways = table.Column<string>(type: "text", nullable: true),
                    Takeaways = table.Column<string>(type: "text", nullable: true),
                    Turnoverdifferential = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter1 = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter2 = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter3 = table.Column<string>(type: "text", nullable: true),
                    Opponentscorequarter4 = table.Column<string>(type: "text", nullable: true),
                    Opponentscoreovertime = table.Column<string>(type: "text", nullable: true),
                    Opponenttimeofpossessionminutes = table.Column<string>(type: "text", nullable: true),
                    Opponenttimeofpossessionseconds = table.Column<string>(type: "text", nullable: true),
                    Opponenttimeofpossession = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdownsbyrushing = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdownsbypassing = table.Column<string>(type: "text", nullable: true),
                    Opponentfirstdownsbypenalty = table.Column<string>(type: "text", nullable: true),
                    Opponentoffensiveplays = table.Column<string>(type: "text", nullable: true),
                    Opponentoffensiveyards = table.Column<string>(type: "text", nullable: true),
                    Opponentoffensiveyardsperplay = table.Column<string>(type: "text", nullable: true),
                    Opponenttouchdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingyards = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Opponentrushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingcompletions = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingyards = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Opponentpassinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Opponentpassingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Opponentcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentpasserrating = table.Column<string>(type: "text", nullable: true),
                    Opponentthirddownattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentthirddownconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentthirddownpercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentfourthdownattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentfourthdownconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentfourthdownpercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentredzoneattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentredzoneconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentgoaltogoattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentgoaltogoconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentpenalties = table.Column<string>(type: "text", nullable: true),
                    Opponentpenaltyyards = table.Column<string>(type: "text", nullable: true),
                    Opponentfumbles = table.Column<string>(type: "text", nullable: true),
                    Opponentfumbleslost = table.Column<string>(type: "text", nullable: true),
                    Opponenttimessacked = table.Column<string>(type: "text", nullable: true),
                    Opponenttimessackedyards = table.Column<string>(type: "text", nullable: true),
                    Opponentquarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Opponenttacklesforloss = table.Column<string>(type: "text", nullable: true),
                    Opponentpunts = table.Column<string>(type: "text", nullable: true),
                    Opponentpuntyards = table.Column<string>(type: "text", nullable: true),
                    Opponentpuntaverage = table.Column<string>(type: "text", nullable: true),
                    Opponentgiveaways = table.Column<string>(type: "text", nullable: true),
                    Opponenttakeaways = table.Column<string>(type: "text", nullable: true),
                    Opponentturnoverdifferential = table.Column<string>(type: "text", nullable: true),
                    Redzonepercentage = table.Column<string>(type: "text", nullable: true),
                    Goaltogopercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentredzonepercentage = table.Column<string>(type: "text", nullable: true),
                    Opponentgoaltogopercentage = table.Column<string>(type: "text", nullable: true),
                    Extrapointkickingattempts = table.Column<string>(type: "text", nullable: true),
                    Extrapointkickingconversions = table.Column<string>(type: "text", nullable: true),
                    Extrapointshadblocked = table.Column<string>(type: "text", nullable: true),
                    Extrapointpassingattempts = table.Column<string>(type: "text", nullable: true),
                    Extrapointpassingconversions = table.Column<string>(type: "text", nullable: true),
                    Extrapointrushingattempts = table.Column<string>(type: "text", nullable: true),
                    Extrapointrushingconversions = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalattempts = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Opponentextrapointkickingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointkickingconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointshadblocked = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointpassingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointpassingconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointrushingattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentextrapointrushingconversions = table.Column<string>(type: "text", nullable: true),
                    Opponentfieldgoalattempts = table.Column<string>(type: "text", nullable: true),
                    Opponentfieldgoalsmade = table.Column<string>(type: "text", nullable: true),
                    Solotackles = table.Column<string>(type: "text", nullable: true),
                    Assistedtackles = table.Column<string>(type: "text", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Passesdefended = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Opponentsolotackles = table.Column<string>(type: "text", nullable: true),
                    Opponentassistedtackles = table.Column<string>(type: "text", nullable: true),
                    Opponentsacks = table.Column<string>(type: "text", nullable: true),
                    Opponentsackyards = table.Column<string>(type: "text", nullable: true),
                    Opponentpassesdefended = table.Column<string>(type: "text", nullable: true),
                    Opponentfumblesforced = table.Column<string>(type: "text", nullable: true),
                    Opponentfumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Dayofweek = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Scoreid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamGames_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FantasyDefenseGameProjections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Pointsallowed = table.Column<int>(type: "integer", nullable: true),
                    Touchdownsscored = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkicks = table.Column<string>(type: "text", nullable: true),
                    Safeties = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalreturntouchdowns = table.Column<int>(type: "integer", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Defensivetouchdowns = table.Column<string>(type: "text", nullable: true),
                    Specialteamstouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Pointsallowedbydefensespecialteams = table.Column<int>(type: "integer", nullable: true),
                    Twopointconversionreturns = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Scoreid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyDefenseGameProjections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyDefenseGameProjections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyDefenseGameProjections_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FantasyDefenseGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Pointsallowed = table.Column<int>(type: "integer", nullable: true),
                    Touchdownsscored = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkicks = table.Column<string>(type: "text", nullable: true),
                    Safeties = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalreturntouchdowns = table.Column<int>(type: "integer", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Defensivetouchdowns = table.Column<string>(type: "text", nullable: true),
                    Specialteamstouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Pointsallowedbydefensespecialteams = table.Column<int>(type: "integer", nullable: true),
                    Twopointconversionreturns = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Scoreid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyDefenseGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyDefenseGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyDefenseGames_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FantasyDefenseSeasonProjections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Pointsallowed = table.Column<int>(type: "integer", nullable: true),
                    Touchdownsscored = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkicks = table.Column<string>(type: "text", nullable: true),
                    Safeties = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalreturntouchdowns = table.Column<int>(type: "integer", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Defensivetouchdowns = table.Column<string>(type: "text", nullable: true),
                    Specialteamstouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Pointsallowedbydefensespecialteams = table.Column<int>(type: "integer", nullable: true),
                    Auctionvalue = table.Column<string>(type: "text", nullable: true),
                    Auctionvalueppr = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionreturns = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Averagedraftpositionppr = table.Column<decimal>(type: "numeric", nullable: true),
                    Teamid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyDefenseSeasonProjections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyDefenseSeasonProjections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FantasyDefenseSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Pointsallowed = table.Column<int>(type: "integer", nullable: true),
                    Touchdownsscored = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkicks = table.Column<string>(type: "text", nullable: true),
                    Safeties = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Blockedkickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalreturntouchdowns = table.Column<int>(type: "integer", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Defensivetouchdowns = table.Column<string>(type: "text", nullable: true),
                    Specialteamstouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Pointsallowedbydefensespecialteams = table.Column<int>(type: "integer", nullable: true),
                    Auctionvalue = table.Column<string>(type: "text", nullable: true),
                    Auctionvalueppr = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionreturns = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Averagedraftpositionppr = table.Column<decimal>(type: "numeric", nullable: true),
                    Teamid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyDefenseSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyDefenseSeasons_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameProjections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Gamedate = table.Column<string>(type: "text", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Played = table.Column<bool>(type: "boolean", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Passinglong = table.Column<string>(type: "text", nullable: true),
                    Passingsacks = table.Column<string>(type: "text", nullable: true),
                    Passingsackyards = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receivingtargets = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fumbles = table.Column<string>(type: "text", nullable: true),
                    Fumbleslost = table.Column<string>(type: "text", nullable: true),
                    Puntreturns = table.Column<string>(type: "text", nullable: true),
                    Puntreturnyards = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturns = table.Column<string>(type: "text", nullable: true),
                    Kickreturnyards = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Solotackles = table.Column<string>(type: "text", nullable: true),
                    Assistedtackles = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Passesdefended = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionpasses = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionruns = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionreceptions = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Fantasyposition = table.Column<string>(type: "text", nullable: true),
                    PlayerGameId = table.Column<int>(type: "integer", nullable: false),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsmade0to19 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade20to29 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade30to39 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade40to49 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade50plus = table.Column<int>(type: "integer", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Scoreid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameProjections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGameProjections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameProjections_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasonProjections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Played = table.Column<bool>(type: "boolean", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Passinglong = table.Column<string>(type: "text", nullable: true),
                    Passingsacks = table.Column<string>(type: "text", nullable: true),
                    Passingsackyards = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receivingtargets = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fumbles = table.Column<string>(type: "text", nullable: true),
                    Fumbleslost = table.Column<string>(type: "text", nullable: true),
                    Puntreturns = table.Column<string>(type: "text", nullable: true),
                    Puntreturnyards = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturns = table.Column<string>(type: "text", nullable: true),
                    Kickreturnyards = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Solotackles = table.Column<string>(type: "text", nullable: true),
                    Assistedtackles = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Passesdefended = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionpasses = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionruns = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionreceptions = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Fantasyposition = table.Column<string>(type: "text", nullable: true),
                    PlayerSeasonId = table.Column<int>(type: "integer", nullable: false),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Auctionvalue = table.Column<string>(type: "text", nullable: true),
                    Auctionvalueppr = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsmade0to19 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade20to29 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade30to39 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade40to49 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade50plus = table.Column<int>(type: "integer", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Averagedraftpositionppr = table.Column<decimal>(type: "numeric", nullable: true),
                    Teamid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasonProjections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonProjections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Played = table.Column<bool>(type: "boolean", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Passinglong = table.Column<string>(type: "text", nullable: true),
                    Passingsacks = table.Column<string>(type: "text", nullable: true),
                    Passingsackyards = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receivingtargets = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fumbles = table.Column<string>(type: "text", nullable: true),
                    Fumbleslost = table.Column<string>(type: "text", nullable: true),
                    Puntreturns = table.Column<string>(type: "text", nullable: true),
                    Puntreturnyards = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturns = table.Column<string>(type: "text", nullable: true),
                    Kickreturnyards = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Solotackles = table.Column<string>(type: "text", nullable: true),
                    Assistedtackles = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Passesdefended = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionpasses = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionruns = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionreceptions = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Fantasyposition = table.Column<string>(type: "text", nullable: true),
                    PlayerSeasonId = table.Column<int>(type: "integer", nullable: false),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Auctionvalue = table.Column<string>(type: "text", nullable: true),
                    Auctionvalueppr = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsmade0to19 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade20to29 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade30to39 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade40to49 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade50plus = table.Column<int>(type: "integer", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Averagedraftpositionppr = table.Column<decimal>(type: "numeric", nullable: true),
                    Teamid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSeasons_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Gamedate = table.Column<string>(type: "text", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Played = table.Column<bool>(type: "boolean", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Passinglong = table.Column<string>(type: "text", nullable: true),
                    Passingsacks = table.Column<string>(type: "text", nullable: true),
                    Passingsackyards = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receivingtargets = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fumbles = table.Column<string>(type: "text", nullable: true),
                    Fumbleslost = table.Column<string>(type: "text", nullable: true),
                    Puntreturns = table.Column<string>(type: "text", nullable: true),
                    Puntreturnyards = table.Column<string>(type: "text", nullable: true),
                    Puntreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Kickreturns = table.Column<string>(type: "text", nullable: true),
                    Kickreturnyards = table.Column<string>(type: "text", nullable: true),
                    Kickreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Solotackles = table.Column<string>(type: "text", nullable: true),
                    Assistedtackles = table.Column<string>(type: "text", nullable: true),
                    Tacklesforloss = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    Sackyards = table.Column<string>(type: "text", nullable: true),
                    Quarterbackhits = table.Column<string>(type: "text", nullable: true),
                    Passesdefended = table.Column<string>(type: "text", nullable: true),
                    Fumblesforced = table.Column<string>(type: "text", nullable: true),
                    Fumblesrecovered = table.Column<string>(type: "text", nullable: true),
                    Fumblereturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Interceptionreturntouchdowns = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionpasses = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionruns = table.Column<string>(type: "text", nullable: true),
                    Twopointconversionreceptions = table.Column<string>(type: "text", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Fantasyposition = table.Column<string>(type: "text", nullable: true),
                    PlayerGameId = table.Column<int>(type: "integer", nullable: false),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsmade0to19 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade20to29 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade30to39 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade40to49 = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade50plus = table.Column<int>(type: "integer", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Scoreid = table.Column<int>(type: "integer", nullable: true),
                    NFLFantasyDefenseGameId = table.Column<int>(type: "integer", nullable: true),
                    NFLPlayerGameId = table.Column<int>(type: "integer", nullable: true),
                    NFLTeamGameId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGames_FantasyDefenseGames_NFLFantasyDefenseGameId",
                        column: x => x.NFLFantasyDefenseGameId,
                        principalTable: "FantasyDefenseGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_PlayerGames_NFLPlayerGameId",
                        column: x => x.NFLPlayerGameId,
                        principalTable: "PlayerGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_TeamGames_NFLTeamGameId",
                        column: x => x.NFLTeamGameId,
                        principalTable: "TeamGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseGameProjections_IsDeleted",
                table: "FantasyDefenseGameProjections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseGameProjections_PlayerId",
                table: "FantasyDefenseGameProjections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseGameProjections_TeamEntityId",
                table: "FantasyDefenseGameProjections",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseGames_IsDeleted",
                table: "FantasyDefenseGames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseGames_PlayerId",
                table: "FantasyDefenseGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseGames_TeamEntityId",
                table: "FantasyDefenseGames",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseSeasonProjections_IsDeleted",
                table: "FantasyDefenseSeasonProjections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseSeasonProjections_PlayerId",
                table: "FantasyDefenseSeasonProjections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseSeasons_IsDeleted",
                table: "FantasyDefenseSeasons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyDefenseSeasons_PlayerId",
                table: "FantasyDefenseSeasons",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_IsDeleted",
                table: "PlayerGameProjections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_PlayerId",
                table: "PlayerGameProjections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_TeamEntityId",
                table: "PlayerGameProjections",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_IsDeleted",
                table: "PlayerGames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_NFLFantasyDefenseGameId",
                table: "PlayerGames",
                column: "NFLFantasyDefenseGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_NFLPlayerGameId",
                table: "PlayerGames",
                column: "NFLPlayerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_NFLTeamGameId",
                table: "PlayerGames",
                column: "NFLTeamGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_TeamEntityId",
                table: "PlayerGames",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_IsDeleted",
                table: "Players",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Players_NFLTeamId",
                table: "Players",
                column: "NFLTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerId",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonProjections_IsDeleted",
                table: "PlayerSeasonProjections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonProjections_PlayerId",
                table: "PlayerSeasonProjections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_IsDeleted",
                table: "PlayerSeasons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_PlayerId",
                table: "PlayerSeasons",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quarters_IsDeleted",
                table: "Quarters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_IsDeleted",
                table: "Scores",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StadiumId",
                table: "Scores",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_IsDeleted",
                table: "Stadiums",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_StadiumId",
                table: "Stadiums",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_IsDeleted",
                table: "Standings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_TeamEntityId",
                table: "Standings",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_IsDeleted",
                table: "TeamGames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_TeamEntityId",
                table: "TeamGames",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_IsDeleted",
                table: "Teams",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasons_IsDeleted",
                table: "TeamSeasons",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyDefenseGameProjections");

            migrationBuilder.DropTable(
                name: "FantasyDefenseSeasonProjections");

            migrationBuilder.DropTable(
                name: "FantasyDefenseSeasons");

            migrationBuilder.DropTable(
                name: "PlayerGameProjections");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "PlayerSeasonProjections");

            migrationBuilder.DropTable(
                name: "PlayerSeasons");

            migrationBuilder.DropTable(
                name: "Quarters");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropTable(
                name: "TeamSeasons");

            migrationBuilder.DropTable(
                name: "FantasyDefenseGames");

            migrationBuilder.DropTable(
                name: "TeamGames");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
