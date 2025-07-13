namespace FantasySportsCsvExplorer
{

    static class CsvExplorer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fantasy Sports CSV Explorer");
            Console.WriteLine("==========================\n");

            // CSV directory path
            string csvDirectory = @"C:\Users\Charl\Downloads\FantasySportsData";

            if (args.Length > 0)
                csvDirectory = args[0];

            var csvFiles = Directory.GetFiles(csvDirectory, "*.csv", SearchOption.AllDirectories)
                .OrderBy(f => f)
                .ToList();

            Console.WriteLine($"Found {csvFiles.Count} CSV files\n");

            var allFileInfo = new List<CsvFileInfo>();

            foreach (var file in csvFiles)
            {
                var info = AnalyzeCsvFile(file, csvDirectory);
                allFileInfo.Add(info);

                Console.WriteLine($"File: {info.RelativePath}");
                Console.WriteLine($"Sport: {info.Sport}");
                Console.WriteLine($"Columns: {info.ColumnCount}");
                Console.WriteLine($"Rows: {info.RowCount}");
                Console.WriteLine($"Column Names: {string.Join(", ", info.Columns)}");
                Console.WriteLine($"Sample Values: {string.Join(" | ", info.SampleValues.Take(5))}");
                Console.WriteLine(new string('-', 80) + "\n");
            }

            // Find common columns across sports
            Console.WriteLine("\nCOMMON COLUMNS ANALYSIS");
            Console.WriteLine("=======================\n");

            var sportGroups = allFileInfo.GroupBy(f => f.Sport);

            foreach (var sportGroup in sportGroups)
            {
                Console.WriteLine($"\n{sportGroup.Key.ToUpper()} FILES:");
                foreach (var file in sportGroup)
                {
                    Console.WriteLine($"  - {Path.GetFileName(file.FilePath)}: {file.ColumnCount} columns");
                }
            }

            // Find columns that appear in multiple files
            Console.WriteLine("\n\nCOMMON COLUMNS ACROSS FILES:");
            var allColumns = allFileInfo.SelectMany(f => f.Columns.Select(c => new { Column = c, File = f.RelativePath }))
                .GroupBy(x => x.Column.ToLower())
                .Where(g => g.Count() > 1)
                .OrderByDescending(g => g.Count());

            foreach (var columnGroup in allColumns)
            {
                Console.WriteLine($"\n'{columnGroup.Key}' appears in {columnGroup.Count()} files:");
                foreach (var occurrence in columnGroup)
                {
                    Console.WriteLine($"  - {occurrence.File}");
                }
            }

            // Generate summary report
            GenerateSummaryReport(allFileInfo, csvDirectory);
        }

        static CsvFileInfo AnalyzeCsvFile(string filePath, string baseDirectory)
        {
            var lines = File.ReadAllLines(filePath);
            var relativePath = Path.GetRelativePath(baseDirectory, filePath);
            var sport = DetermineSport(relativePath);

            if (lines.Length == 0)
                return new CsvFileInfo { FilePath = filePath, RelativePath = relativePath, Sport = sport };

            var headers = lines[0].Split(',').Select(h => h.Trim('"').Trim()).ToArray();
            var sampleValues = new List<string>();

            if (lines.Length > 1)
            {
                var dataLine = lines[1].Split(',').Select(v => v.Trim('"').Trim()).ToArray();
                for (int i = 0; i < Math.Min(headers.Length, dataLine.Length); i++)
                {
                    sampleValues.Add($"{headers[i]}: {dataLine[i]}");
                }
            }

            return new CsvFileInfo
            {
                FilePath = filePath,
                RelativePath = relativePath,
                Sport = sport,
                Columns = headers,
                ColumnCount = headers.Length,
                RowCount = lines.Length - 1,
                SampleValues = sampleValues
            };
        }

        static string DetermineSport(string filePath)
        {
            var lowerPath = filePath.ToLower();
            if (lowerPath.Contains("football") && lowerPath.Contains("college"))
                return "College Football";
            else if (lowerPath.Contains("football") || lowerPath.Contains("nfl"))
                return "Pro Football";
            else if (lowerPath.Contains("baseball") || lowerPath.Contains("mlb"))
                return "Pro Baseball";
            else
                return "Unknown";
        }

        static void GenerateSummaryReport(List<CsvFileInfo> allFiles, string baseDirectory)
        {
            var reportPath = Path.Combine(baseDirectory, "csv_analysis_report.txt");

            using (var writer = new StreamWriter(reportPath))
            {
                writer.WriteLine("FANTASY SPORTS CSV ANALYSIS REPORT");
                writer.WriteLine($"Generated: {DateTime.Now}");
                writer.WriteLine(new string('=', 80));

                foreach (var sport in allFiles.GroupBy(f => f.Sport))
                {
                    writer.WriteLine($"\n\n{sport.Key.ToUpper()}");
                    writer.WriteLine(new string('-', sport.Key.Length));

                    foreach (var file in sport)
                    {
                        writer.WriteLine($"\nFile: {file.RelativePath}");
                        writer.WriteLine($"Columns ({file.ColumnCount}): {string.Join(", ", file.Columns)}");
                    }
                }

                writer.WriteLine("\n\nPOTENTIAL DATABASE DESIGN INSIGHTS:");
                writer.WriteLine(new string('-', 35));

                // Identify potential common entities
                var commonColumns = allFiles
                    .SelectMany(f => f.Columns)
                    .GroupBy(c => c.ToLower())
                    .Where(g => g.Count() >= 2)
                    .Select(g => g.Key);

                writer.WriteLine("\nColumns appearing in multiple files (potential shared entities):");
                foreach (var col in commonColumns)
                {
                    writer.WriteLine($"  - {col}");
                }
            }

            Console.WriteLine($"\n\nReport saved to: {reportPath}");
        }
    }

    class CsvFileInfo
    {
        public string FilePath { get; set; }
        public string RelativePath { get; set; }
        public string Sport { get; set; }
        public string[] Columns { get; set; } = Array.Empty<string>();
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public List<string> SampleValues { get; set; } = new List<string>();
    }
}

// dotnet run -- "C:\Users\Charl\Downloads\FantasySportsData"