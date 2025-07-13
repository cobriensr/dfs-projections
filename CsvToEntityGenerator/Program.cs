using StringBuilder = System.Text.StringBuilder;
using Regex = System.Text.RegularExpressions.Regex;
using RegexOptions = System.Text.RegularExpressions.RegexOptions;

namespace CsvToEntityGenerator
{

    static class CsvToEntityGenerator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CSV to C# Entity Generator");
            Console.WriteLine("==========================\n");

            // Update this to your CSV analysis report path
            string reportPath = @"C:\Users\Charl\Downloads\FantasySportsData\csv_analysis_report.txt";

            if (args.Length > 0)
                reportPath = args[0];

            if (!File.Exists(reportPath))
            {
                Console.WriteLine($"Error: File not found at {reportPath}");
                return;
            }

            var reportContent = File.ReadAllText(reportPath);
            GenerateEntities(reportContent);
        }

        static void GenerateEntities(string reportContent)
        {
            var lines = reportContent.Split('\n');
            string outputDirectory = "GeneratedEntities";

            // Create sport directories
            Directory.CreateDirectory(Path.Combine(outputDirectory, "MLB"));
            Directory.CreateDirectory(Path.Combine(outputDirectory, "NFL"));
            Directory.CreateDirectory(Path.Combine(outputDirectory, "CollegeFootball"));

            int mlbCount = 0, nflCount = 0, cfbCount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();

                if (line.StartsWith("File:") && i + 1 < lines.Length && lines[i + 1].StartsWith("Columns"))
                {
                    // Determine sport from folder name
                    string sport = "";
                    if (line.Contains("BaseballFantasyOdds"))
                    {
                        sport = "MLB";
                        mlbCount++;
                    }
                    else if (line.Contains("CollegeFootballFantasyOdds"))
                    {
                        sport = "CollegeFootball";
                        cfbCount++;
                    }
                    else if (line.Contains("FootballFantasyOdds"))
                    {
                        sport = "NFL";
                        nflCount++;
                    }
                    else
                    {
                        Console.WriteLine($"Skipping unknown sport: {line}");
                        continue;
                    }

                    // Rest of the code...
                    Console.WriteLine($"Processing {sport}: {line}");

                    // Extract filename
                    var match = Regex.Match(line, @"\\([^\\]+)\.csv", RegexOptions.RightToLeft);
                    if (!match.Success) continue;

                    var fileName = match.Groups[1].Value;

                    // Get columns from next line
                    var columnsMatch = Regex.Match(lines[i + 1], @"Columns \(\d+\): (.+)");
                    if (!columnsMatch.Success) continue;

                    var columns = columnsMatch.Groups[1].Value.Split(", ");

                    // Generate entity
                    var entityName = ConvertToEntityName(fileName, sport);
                    var entityCode = GenerateEntityClass(entityName, columns, sport);

                    // Write to file
                    var outputPath = Path.Combine(outputDirectory, sport, $"{entityName}.cs");
                    File.WriteAllText(outputPath, entityCode);
                    Console.WriteLine($"Generated: {sport}/{entityName}.cs");
                }
            }

            Console.WriteLine($"\nGeneration Complete!");
            Console.WriteLine($"MLB: {mlbCount} files");
            Console.WriteLine($"NFL: {nflCount} files");
            Console.WriteLine($"CFB: {cfbCount} files");
        }

        static string ConvertToEntityName(string fileName, string sport)
        {
            var prefix = sport == "NFL" ? "NFL" : sport == "MLB" ? "MLB" : "CFB";

            // Special cases
            if (fileName == "Game.2024") return $"{prefix}Game";
            if (fileName == "Player.2024") return $"{prefix}Player";
            if (fileName == "Team.2024") return $"{prefix}Team";
            if (fileName == "Stadium.2024") return $"{prefix}Stadium";
            if (fileName == "PlayerGame.2024") return $"{prefix}PlayerGame";
            if (fileName == "PlayerGameProjection.2024") return $"{prefix}PlayerGameProjection";
            if (fileName == "PlayerSeason.2024") return $"{prefix}PlayerSeason";
            if (fileName == "PlayerSeasonProjection.2024") return $"{prefix}PlayerSeasonProjection";
            if (fileName == "TeamGame.2024") return $"{prefix}TeamGame";
            if (fileName == "TeamSeason.2024") return $"{prefix}TeamSeason";
            if (fileName == "Inning.2024") return $"{prefix}Inning";
            if (fileName == "Period.2024") return $"{prefix}Period";
            if (fileName == "Quarter.2024") return $"{prefix}Quarter";
            if (fileName == "Score.2024") return $"{prefix}Score";
            if (fileName == "Standing.2024") return $"{prefix}Standing";
            if (fileName.StartsWith("FantasyDefense")) return $"{prefix}{fileName.Replace(".2024", "")}";

            return $"{prefix}{fileName.Replace(".2024", "")}";
        }

        static string GenerateEntityClass(string entityName, string[] columns, string sport)
        {
            var sb = new StringBuilder();
            var namespaceName = sport == "NFL" ? "NFL" : sport == "MLB" ? "MLB" : "CollegeFootball";
            var baseEntity = $"{sport}BaseEntity";

            // Header
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine($"namespace FantasySports.Core.Entities.{namespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {entityName} : {baseEntity}");
            sb.AppendLine("    {");

            // Always add Id first
            sb.AppendLine("        public int Id { get; set; }");

            // Add properties for each column
            foreach (var column in columns)
            {
                var propertyName = ConvertToPascalCase(column);
                var propertyType = InferPropertyType(propertyName);

                // Skip if it's an ID we already added
                if (propertyName == "Id") continue;

                // Add navigation properties for foreign keys
                if (propertyName.EndsWith("Id") && propertyName != "Id")
                {
                    sb.AppendLine($"        public {propertyType} {propertyName} {{ get; set; }}");

                    // Add navigation property
                    var navigationName = propertyName.Substring(0, propertyName.Length - 2);
                    if (navigationName == "Team" || navigationName == "HomeTeam" || navigationName == "AwayTeam")
                        sb.AppendLine($"        public virtual {sport}Team? {navigationName} {{ get; set; }}");
                    else if (navigationName == "Player" || navigationName.EndsWith("Pitcher"))
                        sb.AppendLine($"        public virtual {sport}Player? {navigationName} {{ get; set; }}");
                    else if (navigationName == "Game")
                        sb.AppendLine($"        public virtual {sport}Game? {navigationName} {{ get; set; }}");
                    else if (navigationName == "Stadium")
                        sb.AppendLine($"        public virtual {sport}Stadium? {navigationName} {{ get; set; }}");
                }
                else
                {
                    sb.AppendLine($"        public {propertyType} {propertyName} {{ get; set; }}");
                }

                // Add blank line after groups
                if (IsLastOfGroup(column, columns))
                    sb.AppendLine();
            }

            // Add collections for main entities
            if (entityName.EndsWith("Team"))
            {
                sb.AppendLine("        // Collections");
                sb.AppendLine($"        public virtual ICollection<{sport}Player> Players {{ get; set; }} = new List<{sport}Player>();");
                sb.AppendLine($"        public virtual ICollection<{sport}Game> HomeGames {{ get; set; }} = new List<{sport}Game>();");
                sb.AppendLine($"        public virtual ICollection<{sport}Game> AwayGames {{ get; set; }} = new List<{sport}Game>();");
            }
            else if (entityName.EndsWith("Player"))
            {
                sb.AppendLine("        // Collections");
                sb.AppendLine($"        public virtual ICollection<{sport}PlayerGame> GameStats {{ get; set; }} = new List<{sport}PlayerGame>();");
                sb.AppendLine($"        public virtual ICollection<{sport}PlayerSeason> SeasonStats {{ get; set; }} = new List<{sport}PlayerSeason>();");
            }
            else if (entityName.EndsWith("Game"))
            {
                sb.AppendLine("        // Collections");
                sb.AppendLine($"        public virtual ICollection<{sport}PlayerGame> PlayerStats {{ get; set; }} = new List<{sport}PlayerGame>();");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        static string ConvertToPascalCase(string input)
        {
            // Handle special cases
            var specialCases = new Dictionary<string, string>
        {
            { "GameID", "GameId" },
            { "PlayerID", "PlayerId" },
            { "TeamID", "TeamId" },
            { "StadiumID", "StadiumId" },
            { "StatID", "ExternalStatId" },
            { "[Key]", "Key" },
            { "OpponentID", "OpponentId" },
            { "AwayTeamID", "AwayTeamId" },
            { "HomeTeamID", "HomeTeamId" },
            { "FanDuelPlayerID", "FanDuelPlayerId" },
            { "DraftKingsPlayerID", "DraftKingsPlayerId" },
            { "PlayerGameID", "PlayerGameId" },
            { "PlayerSeasonID", "PlayerSeasonId" },
            { "ScoreID", "ScoreId" },
            { "QuarterID", "QuarterId" },
            { "InningID", "InningId" },
            { "PeriodID", "PeriodId" }
        };

            if (specialCases.ContainsKey(input))
                return specialCases[input];

            // Convert to PascalCase
            return string.Join("", input.Split('_')
                .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }

        static string InferPropertyType(string propertyName)
        {
            // IDs
            if (propertyName.EndsWith("Id") || propertyName == "Id")
                return "int";

            // Decimals
            if (propertyName.Contains("Percentage") || propertyName.Contains("Average") ||
                propertyName.Contains("Rating") || propertyName.Contains("PerAttempt") ||
                propertyName.Contains("Decimal") || propertyName.Contains("Payout") ||
                propertyName.EndsWith("Value") || propertyName.Contains("Spread") ||
                propertyName.Contains("Line") || propertyName.Contains("Under") ||
                propertyName.Contains("Over") || propertyName == "Latitude" ||
                propertyName == "Longitude" || propertyName == "GeoLat" ||
                propertyName == "GeoLong" || propertyName.Contains("Slugging") ||
                propertyName.Contains("OnBase") || propertyName.Contains("ERA") ||
                propertyName.Contains("WHIP") || propertyName.Contains("Weighted"))
                return "decimal?";

            // Integers
            if (propertyName.Contains("Yards") || propertyName.Contains("Attempts") ||
                propertyName.Contains("Completions") || propertyName.Contains("Touchdowns") ||
                propertyName.Contains("Interceptions") || propertyName.Contains("Sacks") ||
                propertyName.Contains("Tackles") || propertyName.Contains("Hits") ||
                propertyName.Contains("Runs") || propertyName.Contains("Points") ||
                propertyName.Contains("Score") || propertyName.Contains("Count") ||
                propertyName.Contains("Total") || propertyName.Contains("Games") ||
                propertyName.Contains("Wins") || propertyName.Contains("Losses") ||
                propertyName.Contains("Saves") || propertyName.Contains("Week") ||
                propertyName.Contains("Season") || propertyName.Contains("Capacity") ||
                propertyName.Contains("Field") || propertyName.Contains("Rank") ||
                propertyName.Contains("Round") || propertyName.Contains("Pick") ||
                propertyName.Contains("Jersey") || propertyName.Contains("Number") ||
                propertyName.Contains("Height") || propertyName.Contains("Weight") ||
                propertyName.Contains("Experience") || propertyName.Contains("Minutes") ||
                propertyName.Contains("Seconds") || propertyName.Contains("Temperature") ||
                propertyName.Contains("Wind") || propertyName.Contains("Altitude") ||
                propertyName.Contains("Rotation") || propertyName.Contains("Direction"))
                return "int?";

            // Dates
            if (propertyName.Contains("Date") || propertyName == "Day" ||
                propertyName == "DateTime" || propertyName.Contains("Time"))
                return "DateTime?";

            // Booleans
            if (propertyName.StartsWith("Is") || propertyName.StartsWith("Has") ||
                propertyName == "Active" || propertyName == "Started" ||
                propertyName == "Played" || propertyName == "NeutralVenue" ||
                propertyName == "Dome" || propertyName.Contains("Opener"))
                return "bool?";

            // Default to string
            return "string?";
        }

        static bool IsLastOfGroup(string column, string[] columns)
        {
            var groups = new[] { "Passing", "Rushing", "Receiving", "Defense", "Kicking", "Batting", "Pitching", "Fielding" };
            var index = Array.IndexOf(columns, column);

            if (index == columns.Length - 1) return false;

            string nextColumn = columns[index + 1];
            foreach (var group in groups)
            {
                if (column.ToLower().Contains(group.ToLower()) &&
                    !nextColumn.ToLower().Contains(group.ToLower()))
                    return true;
            }

            return false;
        }
    }
}

// dotnet run -- "C:\Users\Charl\Downloads\FantasySportsData\csv_analysis_report.txt"
// This will generate all entity files in a GeneratedEntities folder