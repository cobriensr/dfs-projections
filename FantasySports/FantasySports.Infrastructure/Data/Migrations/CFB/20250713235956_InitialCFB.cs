using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasySports.Infrastructure.Data.Migrations.CFB
{
    /// <inheritdoc />
    public partial class InitialCFB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cfb");

            migrationBuilder.CreateTable(
                name: "Stadiums",
                schema: "cfb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    StadiumEntityId = table.Column<int>(type: "integer", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Dome = table.Column<bool>(type: "boolean", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Geolat = table.Column<string>(type: "text", nullable: true),
                    Geolong = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_Stadiums_Stadiums_StadiumEntityId",
                        column: x => x.StadiumEntityId,
                        principalSchema: "cfb",
                        principalTable: "Stadiums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "cfb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamEntityId = table.Column<int>(type: "integer", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    School = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    StadiumEntityId = table.Column<int>(type: "integer", nullable: true),
                    Aprank = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Conferencewins = table.Column<string>(type: "text", nullable: true),
                    Conferencelosses = table.Column<string>(type: "text", nullable: true),
                    Teamlogourl = table.Column<string>(type: "text", nullable: true),
                    Conferenceid = table.Column<string>(type: "text", nullable: true),
                    Conference = table.Column<string>(type: "text", nullable: true),
                    Shortdisplayname = table.Column<string>(type: "text", nullable: true),
                    Rankweek = table.Column<int>(type: "integer", nullable: true),
                    Rankseason = table.Column<int>(type: "integer", nullable: true),
                    Rankseasontype = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_Teams_Stadiums_StadiumEntityId",
                        column: x => x.StadiumEntityId,
                        principalSchema: "cfb",
                        principalTable: "Stadiums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "cfb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Season = table.Column<int>(type: "integer", nullable: true),
                    Seasontype = table.Column<int>(type: "integer", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Awayteam = table.Column<string>(type: "text", nullable: true),
                    Hometeam = table.Column<string>(type: "text", nullable: true),
                    AwayTeamId = table.Column<int>(type: "integer", nullable: false),
                    HomeTeamId = table.Column<int>(type: "integer", nullable: false),
                    Awayteamname = table.Column<string>(type: "text", nullable: true),
                    Hometeamname = table.Column<string>(type: "text", nullable: true),
                    Awayteamscore = table.Column<string>(type: "text", nullable: true),
                    Hometeamscore = table.Column<string>(type: "text", nullable: true),
                    Pointspread = table.Column<int>(type: "integer", nullable: true),
                    Overunder = table.Column<decimal>(type: "numeric", nullable: true),
                    Awayteammoneyline = table.Column<string>(type: "text", nullable: true),
                    Hometeammoneyline = table.Column<string>(type: "text", nullable: true),
                    StadiumId = table.Column<int>(type: "integer", nullable: false),
                    Stadium = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Homerotationnumber = table.Column<string>(type: "text", nullable: true),
                    Awayrotationnumber = table.Column<string>(type: "text", nullable: true),
                    Neutralvenue = table.Column<string>(type: "text", nullable: true),
                    Awaypointspreadpayout = table.Column<string>(type: "text", nullable: true),
                    Homepointspreadpayout = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "cfb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalSchema: "cfb",
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "cfb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Jersey = table.Column<int>(type: "integer", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Positioncategory = table.Column<string>(type: "text", nullable: true),
                    Class = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: true),
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "cfb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasons",
                schema: "cfb",
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
                    Wins = table.Column<int>(type: "integer", nullable: true),
                    Losses = table.Column<int>(type: "integer", nullable: true),
                    Pointsfor = table.Column<int>(type: "integer", nullable: true),
                    Pointsagainst = table.Column<int>(type: "integer", nullable: true),
                    Conferencewins = table.Column<string>(type: "text", nullable: true),
                    Conferencelosses = table.Column<string>(type: "text", nullable: true),
                    Conferencepointsfor = table.Column<string>(type: "text", nullable: true),
                    Conferencepointsagainst = table.Column<string>(type: "text", nullable: true),
                    Homewins = table.Column<string>(type: "text", nullable: true),
                    Homelosses = table.Column<string>(type: "text", nullable: true),
                    Roadwins = table.Column<string>(type: "text", nullable: true),
                    Roadlosses = table.Column<string>(type: "text", nullable: true),
                    Streak = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    Opponentscore = table.Column<string>(type: "text", nullable: true),
                    Firstdowns = table.Column<string>(type: "text", nullable: true),
                    Thirddownconversions = table.Column<string>(type: "text", nullable: true),
                    Thirddownattempts = table.Column<string>(type: "text", nullable: true),
                    Fourthdownconversions = table.Column<string>(type: "text", nullable: true),
                    Fourthdownattempts = table.Column<string>(type: "text", nullable: true),
                    Penalties = table.Column<string>(type: "text", nullable: true),
                    Penaltyyards = table.Column<string>(type: "text", nullable: true),
                    Timeofpossessionminutes = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timeofpossessionseconds = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalpercentage = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalslongestmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                schema: "cfb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeriodId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Awayscore = table.Column<string>(type: "text", nullable: true),
                    Homescore = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccessCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periods_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "cfb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamGames",
                schema: "cfb",
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
                    Score = table.Column<int>(type: "integer", nullable: true),
                    Opponentscore = table.Column<string>(type: "text", nullable: true),
                    Firstdowns = table.Column<string>(type: "text", nullable: true),
                    Thirddownconversions = table.Column<string>(type: "text", nullable: true),
                    Thirddownattempts = table.Column<string>(type: "text", nullable: true),
                    Fourthdownconversions = table.Column<string>(type: "text", nullable: true),
                    Fourthdownattempts = table.Column<string>(type: "text", nullable: true),
                    Penalties = table.Column<string>(type: "text", nullable: true),
                    Penaltyyards = table.Column<string>(type: "text", nullable: true),
                    Timeofpossessionminutes = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timeofpossessionseconds = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalpercentage = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalslongestmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "cfb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamGames_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameProjections",
                schema: "cfb",
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
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalpercentage = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalslongestmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "cfb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameProjections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "cfb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameProjections_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasons",
                schema: "cfb",
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
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalpercentage = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalslongestmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
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
                        principalSchema: "cfb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSeasons_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                schema: "cfb",
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
                    Injurystatus = table.Column<string>(type: "text", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    OpponentId = table.Column<int>(type: "integer", nullable: false),
                    Opponent = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Homeoraway = table.Column<string>(type: "text", nullable: true),
                    Games = table.Column<int>(type: "integer", nullable: true),
                    Fantasypoints = table.Column<string>(type: "text", nullable: true),
                    Passingattempts = table.Column<string>(type: "text", nullable: true),
                    Passingcompletions = table.Column<string>(type: "text", nullable: true),
                    Passingyards = table.Column<string>(type: "text", nullable: true),
                    Passingcompletionpercentage = table.Column<string>(type: "text", nullable: true),
                    Passingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Passingyardspercompletion = table.Column<string>(type: "text", nullable: true),
                    Passingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Passinginterceptions = table.Column<string>(type: "text", nullable: true),
                    Passingrating = table.Column<string>(type: "text", nullable: true),
                    Rushingattempts = table.Column<string>(type: "text", nullable: true),
                    Rushingyards = table.Column<string>(type: "text", nullable: true),
                    Rushingyardsperattempt = table.Column<string>(type: "text", nullable: true),
                    Rushingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Rushinglong = table.Column<string>(type: "text", nullable: true),
                    Receptions = table.Column<string>(type: "text", nullable: true),
                    Receivingyards = table.Column<string>(type: "text", nullable: true),
                    Receivingyardsperreception = table.Column<string>(type: "text", nullable: true),
                    Receivingtouchdowns = table.Column<string>(type: "text", nullable: true),
                    Receivinglong = table.Column<string>(type: "text", nullable: true),
                    Fieldgoalsattempted = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalsmade = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalpercentage = table.Column<int>(type: "integer", nullable: true),
                    Fieldgoalslongestmade = table.Column<int>(type: "integer", nullable: true),
                    Extrapointsattempted = table.Column<string>(type: "text", nullable: true),
                    Extrapointsmade = table.Column<string>(type: "text", nullable: true),
                    CFBPlayerGameId = table.Column<int>(type: "integer", nullable: true),
                    CFBTeamGameId = table.Column<int>(type: "integer", nullable: true),
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
                        principalSchema: "cfb",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_PlayerGames_CFBPlayerGameId",
                        column: x => x.CFBPlayerGameId,
                        principalSchema: "cfb",
                        principalTable: "PlayerGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "cfb",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_TeamGames_CFBTeamGameId",
                        column: x => x.CFBTeamGameId,
                        principalSchema: "cfb",
                        principalTable: "TeamGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "cfb",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId",
                schema: "cfb",
                table: "Games",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameId",
                schema: "cfb",
                table: "Games",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                schema: "cfb",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_IsDeleted",
                schema: "cfb",
                table: "Games",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StadiumId",
                schema: "cfb",
                table: "Games",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_GameId",
                schema: "cfb",
                table: "Periods",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_IsDeleted",
                schema: "cfb",
                table: "Periods",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_GameId",
                schema: "cfb",
                table: "PlayerGameProjections",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_IsDeleted",
                schema: "cfb",
                table: "PlayerGameProjections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_PlayerId",
                schema: "cfb",
                table: "PlayerGameProjections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameProjections_TeamEntityId",
                schema: "cfb",
                table: "PlayerGameProjections",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_CFBPlayerGameId",
                schema: "cfb",
                table: "PlayerGames",
                column: "CFBPlayerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_CFBTeamGameId",
                schema: "cfb",
                table: "PlayerGames",
                column: "CFBTeamGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                schema: "cfb",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_IsDeleted",
                schema: "cfb",
                table: "PlayerGames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                schema: "cfb",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_TeamEntityId",
                schema: "cfb",
                table: "PlayerGames",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_IsDeleted",
                schema: "cfb",
                table: "Players",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerId",
                schema: "cfb",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                schema: "cfb",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_IsDeleted",
                schema: "cfb",
                table: "PlayerSeasons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_PlayerId",
                schema: "cfb",
                table: "PlayerSeasons",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_TeamEntityId",
                schema: "cfb",
                table: "PlayerSeasons",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_IsDeleted",
                schema: "cfb",
                table: "Stadiums",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_StadiumEntityId",
                schema: "cfb",
                table: "Stadiums",
                column: "StadiumEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_GameId",
                schema: "cfb",
                table: "TeamGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_IsDeleted",
                schema: "cfb",
                table: "TeamGames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_TeamEntityId",
                schema: "cfb",
                table: "TeamGames",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_IsDeleted",
                schema: "cfb",
                table: "Teams",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumEntityId",
                schema: "cfb",
                table: "Teams",
                column: "StadiumEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamEntityId",
                schema: "cfb",
                table: "Teams",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasons_IsDeleted",
                schema: "cfb",
                table: "TeamSeasons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasons_TeamEntityId",
                schema: "cfb",
                table: "TeamSeasons",
                column: "TeamEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Periods",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "PlayerGameProjections",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "PlayerGames",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "PlayerSeasons",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "TeamSeasons",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "TeamGames",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "cfb");

            migrationBuilder.DropTable(
                name: "Stadiums",
                schema: "cfb");
        }
    }
}
