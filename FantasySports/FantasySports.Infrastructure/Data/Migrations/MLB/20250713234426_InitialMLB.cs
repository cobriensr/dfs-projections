using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasySports.Infrastructure.Data.Migrations.MLB
{
    /// <inheritdoc />
    public partial class InitialMLB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mlb");

            migrationBuilder.CreateTable(
                name: "Stadiums",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<int>(type: "integer", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    Surface = table.Column<string>(type: "text", nullable: true),
                    Leftfield = table.Column<string>(type: "text", nullable: true),
                    Midleftfield = table.Column<string>(type: "text", nullable: true),
                    Leftcenterfield = table.Column<string>(type: "text", nullable: true),
                    Midleftcenterfield = table.Column<string>(type: "text", nullable: true),
                    Centerfield = table.Column<string>(type: "text", nullable: true),
                    Midrightcenterfield = table.Column<string>(type: "text", nullable: true),
                    Rightcenterfield = table.Column<string>(type: "text", nullable: true),
                    Midrightfield = table.Column<string>(type: "text", nullable: true),
                    Rightfield = table.Column<string>(type: "text", nullable: true),
                    Geolat = table.Column<string>(type: "text", nullable: true),
                    Geolong = table.Column<string>(type: "text", nullable: true),
                    Altitude = table.Column<int>(type: "integer", nullable: true),
                    Homeplatedirection = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "mlb",
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    League = table.Column<string>(type: "text", nullable: true),
                    Division = table.Column<string>(type: "text", nullable: true),
                    Primarycolor = table.Column<string>(type: "text", nullable: true),
                    Secondarycolor = table.Column<string>(type: "text", nullable: true),
                    Tertiarycolor = table.Column<string>(type: "text", nullable: true),
                    Quaternarycolor = table.Column<string>(type: "text", nullable: true),
                    Wikipedialogourl = table.Column<string>(type: "text", nullable: true),
                    Wikipediawordmarkurl = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "mlb",
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    SeasonType = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Awayteam = table.Column<string>(type: "text", nullable: true),
                    Hometeam = table.Column<string>(type: "text", nullable: true),
                    AwayTeamId = table.Column<int>(type: "integer", nullable: true),
                    HomeTeamId = table.Column<int>(type: "integer", nullable: true),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    Awayteamruns = table.Column<string>(type: "text", nullable: true),
                    Hometeamruns = table.Column<string>(type: "text", nullable: true),
                    Awayteamprobablepitcherid = table.Column<string>(type: "text", nullable: true),
                    Hometeamprobablepitcherid = table.Column<string>(type: "text", nullable: true),
                    Awayteamstartingpitcherid = table.Column<string>(type: "text", nullable: true),
                    Hometeamstartingpitcherid = table.Column<string>(type: "text", nullable: true),
                    Pointspread = table.Column<int>(type: "integer", nullable: true),
                    Overunder = table.Column<decimal>(type: "numeric", nullable: true),
                    Awayteammoneyline = table.Column<string>(type: "text", nullable: true),
                    Hometeammoneyline = table.Column<string>(type: "text", nullable: true),
                    Forecasttemplow = table.Column<string>(type: "text", nullable: true),
                    Forecasttemphigh = table.Column<string>(type: "text", nullable: true),
                    Forecastdescription = table.Column<string>(type: "text", nullable: true),
                    Forecastwindchill = table.Column<string>(type: "text", nullable: true),
                    Forecastwindspeed = table.Column<string>(type: "text", nullable: true),
                    Forecastwinddirection = table.Column<string>(type: "text", nullable: true),
                    Awayteamstartingpitcher = table.Column<string>(type: "text", nullable: true),
                    Hometeamstartingpitcher = table.Column<string>(type: "text", nullable: true),
                    Homerotationnumber = table.Column<string>(type: "text", nullable: true),
                    Awayrotationnumber = table.Column<string>(type: "text", nullable: true),
                    Neutralvenue = table.Column<string>(type: "text", nullable: true),
                    Overpayout = table.Column<decimal>(type: "numeric", nullable: true),
                    Underpayout = table.Column<decimal>(type: "numeric", nullable: true),
                    Hometeamopener = table.Column<string>(type: "text", nullable: true),
                    Awayteamopener = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "mlb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalSchema: "mlb",
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Jersey = table.Column<int>(type: "integer", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Bathand = table.Column<string>(type: "text", nullable: true),
                    Throwhand = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: true),
                    Birthdate = table.Column<string>(type: "text", nullable: true),
                    Birthcity = table.Column<string>(type: "text", nullable: true),
                    Birthstate = table.Column<string>(type: "text", nullable: true),
                    Birthcountry = table.Column<string>(type: "text", nullable: true),
                    Photourl = table.Column<string>(type: "text", nullable: true),
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    FanDuelPlayerId = table.Column<int>(type: "integer", nullable: false),
                    DraftKingsPlayerId = table.Column<int>(type: "integer", nullable: false),
                    Fanduelname = table.Column<string>(type: "text", nullable: true),
                    Draftkingsname = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "mlb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasons",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalStatId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Atbats = table.Column<string>(type: "text", nullable: true),
                    Runs = table.Column<int>(type: "integer", nullable: true),
                    Hits = table.Column<int>(type: "integer", nullable: true),
                    Singles = table.Column<string>(type: "text", nullable: true),
                    Doubles = table.Column<string>(type: "text", nullable: true),
                    Triples = table.Column<string>(type: "text", nullable: true),
                    Homeruns = table.Column<string>(type: "text", nullable: true),
                    Runsbattedin = table.Column<int>(type: "integer", nullable: true),
                    Battingaverage = table.Column<string>(type: "text", nullable: true),
                    Outs = table.Column<string>(type: "text", nullable: true),
                    Strikeouts = table.Column<string>(type: "text", nullable: true),
                    Walks = table.Column<string>(type: "text", nullable: true),
                    Hitbypitch = table.Column<string>(type: "text", nullable: true),
                    Sacrifices = table.Column<string>(type: "text", nullable: true),
                    Sacrificeflies = table.Column<string>(type: "text", nullable: true),
                    Groundintodoubleplay = table.Column<string>(type: "text", nullable: true),
                    Stolenbases = table.Column<string>(type: "text", nullable: true),
                    Caughtstealing = table.Column<string>(type: "text", nullable: true),
                    Onbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Sluggingpercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Onbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Saves = table.Column<int>(type: "integer", nullable: true),
                    Inningspitcheddecimal = table.Column<string>(type: "text", nullable: true),
                    Totaloutspitched = table.Column<int>(type: "integer", nullable: true),
                    Inningspitchedfull = table.Column<string>(type: "text", nullable: true),
                    Inningspitchedouts = table.Column<string>(type: "text", nullable: true),
                    Earnedrunaverage = table.Column<string>(type: "text", nullable: true),
                    Pitchinghits = table.Column<string>(type: "text", nullable: true),
                    Pitchingruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingearnedruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalks = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeouts = table.Column<string>(type: "text", nullable: true),
                    Pitchinghomeruns = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrown = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrownstrikes = table.Column<string>(type: "text", nullable: true),
                    Walkshitsperinningspitched = table.Column<string>(type: "text", nullable: true),
                    Pitchingbattingaverageagainst = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Weightedonbasepercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Pitchingcompletegames = table.Column<string>(type: "text", nullable: true),
                    Pitchingshutouts = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingsluggingpercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeoutspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalkspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingweightedonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsbatting = table.Column<string>(type: "text", nullable: true),
                    Fantasypointspitching = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSeasons_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Innings",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InningId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Inningnumber = table.Column<string>(type: "text", nullable: true),
                    Awayteamruns = table.Column<string>(type: "text", nullable: true),
                    Hometeamruns = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Innings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Innings_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "mlb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamGames",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalStatId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Atbats = table.Column<string>(type: "text", nullable: true),
                    Runs = table.Column<int>(type: "integer", nullable: true),
                    Hits = table.Column<int>(type: "integer", nullable: true),
                    Singles = table.Column<string>(type: "text", nullable: true),
                    Doubles = table.Column<string>(type: "text", nullable: true),
                    Triples = table.Column<string>(type: "text", nullable: true),
                    Homeruns = table.Column<string>(type: "text", nullable: true),
                    Runsbattedin = table.Column<int>(type: "integer", nullable: true),
                    Battingaverage = table.Column<string>(type: "text", nullable: true),
                    Outs = table.Column<string>(type: "text", nullable: true),
                    Strikeouts = table.Column<string>(type: "text", nullable: true),
                    Walks = table.Column<string>(type: "text", nullable: true),
                    Hitbypitch = table.Column<string>(type: "text", nullable: true),
                    Sacrifices = table.Column<string>(type: "text", nullable: true),
                    Sacrificeflies = table.Column<string>(type: "text", nullable: true),
                    Groundintodoubleplay = table.Column<string>(type: "text", nullable: true),
                    Stolenbases = table.Column<string>(type: "text", nullable: true),
                    Caughtstealing = table.Column<string>(type: "text", nullable: true),
                    Onbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Sluggingpercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Onbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Saves = table.Column<int>(type: "integer", nullable: true),
                    Inningspitcheddecimal = table.Column<string>(type: "text", nullable: true),
                    Totaloutspitched = table.Column<int>(type: "integer", nullable: true),
                    Inningspitchedfull = table.Column<string>(type: "text", nullable: true),
                    Inningspitchedouts = table.Column<string>(type: "text", nullable: true),
                    Earnedrunaverage = table.Column<string>(type: "text", nullable: true),
                    Pitchinghits = table.Column<string>(type: "text", nullable: true),
                    Pitchingruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingearnedruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalks = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeouts = table.Column<string>(type: "text", nullable: true),
                    Pitchinghomeruns = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrown = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrownstrikes = table.Column<string>(type: "text", nullable: true),
                    Walkshitsperinningspitched = table.Column<string>(type: "text", nullable: true),
                    Pitchingbattingaverageagainst = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Weightedonbasepercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Pitchingcompletegames = table.Column<string>(type: "text", nullable: true),
                    Pitchingshutouts = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingsluggingpercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeoutspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalkspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingweightedonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsbatting = table.Column<string>(type: "text", nullable: true),
                    Fantasypointspitching = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_TeamGames_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "mlb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamGames_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameProjections",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalStatId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Atbats = table.Column<string>(type: "text", nullable: true),
                    Runs = table.Column<int>(type: "integer", nullable: true),
                    Hits = table.Column<int>(type: "integer", nullable: true),
                    Singles = table.Column<string>(type: "text", nullable: true),
                    Doubles = table.Column<string>(type: "text", nullable: true),
                    Triples = table.Column<string>(type: "text", nullable: true),
                    Homeruns = table.Column<string>(type: "text", nullable: true),
                    Runsbattedin = table.Column<int>(type: "integer", nullable: true),
                    Battingaverage = table.Column<string>(type: "text", nullable: true),
                    Outs = table.Column<string>(type: "text", nullable: true),
                    Strikeouts = table.Column<string>(type: "text", nullable: true),
                    Walks = table.Column<string>(type: "text", nullable: true),
                    Hitbypitch = table.Column<string>(type: "text", nullable: true),
                    Sacrifices = table.Column<string>(type: "text", nullable: true),
                    Sacrificeflies = table.Column<string>(type: "text", nullable: true),
                    Groundintodoubleplay = table.Column<string>(type: "text", nullable: true),
                    Stolenbases = table.Column<string>(type: "text", nullable: true),
                    Caughtstealing = table.Column<string>(type: "text", nullable: true),
                    Onbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Sluggingpercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Onbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Saves = table.Column<int>(type: "integer", nullable: true),
                    Inningspitcheddecimal = table.Column<string>(type: "text", nullable: true),
                    Totaloutspitched = table.Column<int>(type: "integer", nullable: true),
                    Inningspitchedfull = table.Column<string>(type: "text", nullable: true),
                    Inningspitchedouts = table.Column<string>(type: "text", nullable: true),
                    Earnedrunaverage = table.Column<string>(type: "text", nullable: true),
                    Pitchinghits = table.Column<string>(type: "text", nullable: true),
                    Pitchingruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingearnedruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalks = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeouts = table.Column<string>(type: "text", nullable: true),
                    Pitchinghomeruns = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrown = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrownstrikes = table.Column<string>(type: "text", nullable: true),
                    Walkshitsperinningspitched = table.Column<string>(type: "text", nullable: true),
                    Pitchingbattingaverageagainst = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Weightedonbasepercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Pitchingcompletegames = table.Column<string>(type: "text", nullable: true),
                    Pitchingshutouts = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingsluggingpercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeoutspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalkspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingweightedonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsbatting = table.Column<string>(type: "text", nullable: true),
                    Fantasypointspitching = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_PlayerGameProjections_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "mlb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameProjections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "mlb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameProjections_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasonProjections",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalStatId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Auctionvalue = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Atbats = table.Column<string>(type: "text", nullable: true),
                    Runs = table.Column<int>(type: "integer", nullable: true),
                    Hits = table.Column<int>(type: "integer", nullable: true),
                    Singles = table.Column<string>(type: "text", nullable: true),
                    Doubles = table.Column<string>(type: "text", nullable: true),
                    Triples = table.Column<string>(type: "text", nullable: true),
                    Homeruns = table.Column<string>(type: "text", nullable: true),
                    Runsbattedin = table.Column<int>(type: "integer", nullable: true),
                    Battingaverage = table.Column<string>(type: "text", nullable: true),
                    Outs = table.Column<string>(type: "text", nullable: true),
                    Strikeouts = table.Column<string>(type: "text", nullable: true),
                    Walks = table.Column<string>(type: "text", nullable: true),
                    Hitbypitch = table.Column<string>(type: "text", nullable: true),
                    Sacrifices = table.Column<string>(type: "text", nullable: true),
                    Sacrificeflies = table.Column<string>(type: "text", nullable: true),
                    Groundintodoubleplay = table.Column<string>(type: "text", nullable: true),
                    Stolenbases = table.Column<string>(type: "text", nullable: true),
                    Caughtstealing = table.Column<string>(type: "text", nullable: true),
                    Onbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Sluggingpercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Onbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Saves = table.Column<int>(type: "integer", nullable: true),
                    Inningspitcheddecimal = table.Column<string>(type: "text", nullable: true),
                    Totaloutspitched = table.Column<int>(type: "integer", nullable: true),
                    Inningspitchedfull = table.Column<string>(type: "text", nullable: true),
                    Inningspitchedouts = table.Column<string>(type: "text", nullable: true),
                    Earnedrunaverage = table.Column<string>(type: "text", nullable: true),
                    Pitchinghits = table.Column<string>(type: "text", nullable: true),
                    Pitchingruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingearnedruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalks = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeouts = table.Column<string>(type: "text", nullable: true),
                    Pitchinghomeruns = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrown = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrownstrikes = table.Column<string>(type: "text", nullable: true),
                    Walkshitsperinningspitched = table.Column<string>(type: "text", nullable: true),
                    Pitchingbattingaverageagainst = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Weightedonbasepercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Pitchingcompletegames = table.Column<string>(type: "text", nullable: true),
                    Pitchingshutouts = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingsluggingpercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeoutspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalkspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingweightedonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsbatting = table.Column<string>(type: "text", nullable: true),
                    Fantasypointspitching = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "mlb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonProjections_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasons",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalStatId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Averagedraftposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Auctionvalue = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Atbats = table.Column<string>(type: "text", nullable: true),
                    Runs = table.Column<int>(type: "integer", nullable: true),
                    Hits = table.Column<int>(type: "integer", nullable: true),
                    Singles = table.Column<string>(type: "text", nullable: true),
                    Doubles = table.Column<string>(type: "text", nullable: true),
                    Triples = table.Column<string>(type: "text", nullable: true),
                    Homeruns = table.Column<string>(type: "text", nullable: true),
                    Runsbattedin = table.Column<int>(type: "integer", nullable: true),
                    Battingaverage = table.Column<string>(type: "text", nullable: true),
                    Outs = table.Column<string>(type: "text", nullable: true),
                    Strikeouts = table.Column<string>(type: "text", nullable: true),
                    Walks = table.Column<string>(type: "text", nullable: true),
                    Hitbypitch = table.Column<string>(type: "text", nullable: true),
                    Sacrifices = table.Column<string>(type: "text", nullable: true),
                    Sacrificeflies = table.Column<string>(type: "text", nullable: true),
                    Groundintodoubleplay = table.Column<string>(type: "text", nullable: true),
                    Stolenbases = table.Column<string>(type: "text", nullable: true),
                    Caughtstealing = table.Column<string>(type: "text", nullable: true),
                    Onbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Sluggingpercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Onbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Saves = table.Column<int>(type: "integer", nullable: true),
                    Inningspitcheddecimal = table.Column<string>(type: "text", nullable: true),
                    Totaloutspitched = table.Column<int>(type: "integer", nullable: true),
                    Inningspitchedfull = table.Column<string>(type: "text", nullable: true),
                    Inningspitchedouts = table.Column<string>(type: "text", nullable: true),
                    Earnedrunaverage = table.Column<string>(type: "text", nullable: true),
                    Pitchinghits = table.Column<string>(type: "text", nullable: true),
                    Pitchingruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingearnedruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalks = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeouts = table.Column<string>(type: "text", nullable: true),
                    Pitchinghomeruns = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrown = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrownstrikes = table.Column<string>(type: "text", nullable: true),
                    Walkshitsperinningspitched = table.Column<string>(type: "text", nullable: true),
                    Pitchingbattingaverageagainst = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Weightedonbasepercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Pitchingcompletegames = table.Column<string>(type: "text", nullable: true),
                    Pitchingshutouts = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingsluggingpercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeoutspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalkspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingweightedonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsbatting = table.Column<string>(type: "text", nullable: true),
                    Fantasypointspitching = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "mlb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSeasons_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                schema: "mlb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalStatId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Atbats = table.Column<string>(type: "text", nullable: true),
                    Runs = table.Column<int>(type: "integer", nullable: true),
                    Hits = table.Column<int>(type: "integer", nullable: true),
                    Singles = table.Column<string>(type: "text", nullable: true),
                    Doubles = table.Column<string>(type: "text", nullable: true),
                    Triples = table.Column<string>(type: "text", nullable: true),
                    Homeruns = table.Column<string>(type: "text", nullable: true),
                    Runsbattedin = table.Column<int>(type: "integer", nullable: true),
                    Battingaverage = table.Column<string>(type: "text", nullable: true),
                    Outs = table.Column<string>(type: "text", nullable: true),
                    Strikeouts = table.Column<string>(type: "text", nullable: true),
                    Walks = table.Column<string>(type: "text", nullable: true),
                    Hitbypitch = table.Column<string>(type: "text", nullable: true),
                    Sacrifices = table.Column<string>(type: "text", nullable: true),
                    Sacrificeflies = table.Column<string>(type: "text", nullable: true),
                    Groundintodoubleplay = table.Column<string>(type: "text", nullable: true),
                    Stolenbases = table.Column<string>(type: "text", nullable: true),
                    Caughtstealing = table.Column<string>(type: "text", nullable: true),
                    Onbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Sluggingpercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Onbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Saves = table.Column<int>(type: "integer", nullable: true),
                    Inningspitcheddecimal = table.Column<string>(type: "text", nullable: true),
                    Totaloutspitched = table.Column<int>(type: "integer", nullable: true),
                    Inningspitchedfull = table.Column<string>(type: "text", nullable: true),
                    Inningspitchedouts = table.Column<string>(type: "text", nullable: true),
                    Earnedrunaverage = table.Column<string>(type: "text", nullable: true),
                    Pitchinghits = table.Column<string>(type: "text", nullable: true),
                    Pitchingruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingearnedruns = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalks = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeouts = table.Column<string>(type: "text", nullable: true),
                    Pitchinghomeruns = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrown = table.Column<string>(type: "text", nullable: true),
                    Pitchesthrownstrikes = table.Column<string>(type: "text", nullable: true),
                    Walkshitsperinningspitched = table.Column<string>(type: "text", nullable: true),
                    Pitchingbattingaverageagainst = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsfanduel = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsdraftkings = table.Column<string>(type: "text", nullable: true),
                    Weightedonbasepercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Pitchingcompletegames = table.Column<string>(type: "text", nullable: true),
                    Pitchingshutouts = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingsluggingpercentage = table.Column<string>(type: "text", nullable: true),
                    Pitchingonbaseplusslugging = table.Column<string>(type: "text", nullable: true),
                    Pitchingstrikeoutspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingwalkspernineinnings = table.Column<string>(type: "text", nullable: true),
                    Pitchingweightedonbasepercentage = table.Column<string>(type: "text", nullable: true),
                    Fantasypointsbatting = table.Column<string>(type: "text", nullable: true),
                    Fantasypointspitching = table.Column<string>(type: "text", nullable: true),
                    MLBPlayerGameId = table.Column<int>(type: "integer", nullable: true),
                    MLBTeamGameId = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "mlb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerGames_PlayerGames_MLBPlayerGameId",
                        column: x => x.MLBPlayerGameId,
                        principalSchema: "mlb",
                        principalTable: "PlayerGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "mlb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerGames_TeamGames_MLBTeamGameId",
                        column: x => x.MLBTeamGameId,
                        principalSchema: "mlb",
                        principalTable: "TeamGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "mlb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId",
                schema: "mlb",
                table: "Games",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameId",
                schema: "mlb",
                table: "Games",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                schema: "mlb",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_IsDeleted",
                schema: "mlb",
                table: "Games",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StadiumId",
                schema: "mlb",
                table: "Games",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Innings_GameId",
                schema: "mlb",
                table: "Innings",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Innings_IsDeleted",
                schema: "mlb",
                table: "Innings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_GameId",
                schema: "mlb",
                table: "PlayerGameProjections",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_IsDeleted",
                schema: "mlb",
                table: "PlayerGameProjections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_PlayerId",
                schema: "mlb",
                table: "PlayerGameProjections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_TeamEntityId",
                schema: "mlb",
                table: "PlayerGameProjections",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                schema: "mlb",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_IsDeleted",
                schema: "mlb",
                table: "PlayerGames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_MLBPlayerGameId",
                schema: "mlb",
                table: "PlayerGames",
                column: "MLBPlayerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_MLBTeamGameId",
                schema: "mlb",
                table: "PlayerGames",
                column: "MLBTeamGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                schema: "mlb",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_TeamEntityId",
                schema: "mlb",
                table: "PlayerGames",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_IsDeleted",
                schema: "mlb",
                table: "Players",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerId",
                schema: "mlb",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                schema: "mlb",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonProjections_IsDeleted",
                schema: "mlb",
                table: "PlayerSeasonProjections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonProjections_PlayerId",
                schema: "mlb",
                table: "PlayerSeasonProjections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonProjections_TeamEntityId",
                schema: "mlb",
                table: "PlayerSeasonProjections",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_IsDeleted",
                schema: "mlb",
                table: "PlayerSeasons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_PlayerId",
                schema: "mlb",
                table: "PlayerSeasons",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_TeamEntityId",
                schema: "mlb",
                table: "PlayerSeasons",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_IsDeleted",
                schema: "mlb",
                table: "Stadiums",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_StadiumId",
                schema: "mlb",
                table: "Stadiums",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_GameId",
                schema: "mlb",
                table: "TeamGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_IsDeleted",
                schema: "mlb",
                table: "TeamGames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_TeamEntityId",
                schema: "mlb",
                table: "TeamGames",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_IsDeleted",
                schema: "mlb",
                table: "Teams",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                schema: "mlb",
                table: "Teams",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamEntityId",
                schema: "mlb",
                table: "Teams",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasons_IsDeleted",
                schema: "mlb",
                table: "TeamSeasons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasons_TeamEntityId",
                schema: "mlb",
                table: "TeamSeasons",
                column: "TeamEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Innings",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "PlayerGameProjections",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "PlayerGames",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "PlayerSeasonProjections",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "PlayerSeasons",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "TeamSeasons",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "TeamGames",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "mlb");

            migrationBuilder.DropTable(
                name: "Stadiums",
                schema: "mlb");
        }
    }
}
