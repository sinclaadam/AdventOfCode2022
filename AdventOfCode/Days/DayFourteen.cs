using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Days;

public static class DayFourteen
{
    private const int SandStartCol = 500;
    private const string Air = ".";
    private const string Sand = "o";
    private const string Rock = "#";
    private const string Input = "+";
    
    public static int CalculateUnitsOfSand(IEnumerable<string> input)
    {
        var rockLines = ParseLines(input);
        var (scan, sandStartCol) = GenerateMap(rockLines);

        DrawScan(scan);
        var totalSandUnits = CalculateMaximumSand(scan, sandStartCol);
        return totalSandUnits;
    }

    private static int CalculateMaximumSand(string[,] scan, int sandStartCol)
    {
        throw new NotImplementedException();
    }

    private static (string[,] scan, int sandStartCol) GenerateMap(List<Line> rockLines)
    {
        // Row always starts at 0
        var maxRow = rockLines.Max(x => x.LinesCoordinates.Max(y => y.Row));
        
        var minCol = rockLines.Min(x => x.LinesCoordinates.Min(y => y.Col));
        var maxCol = rockLines.Max(x => x.LinesCoordinates.Max(y => y.Col));

        var sizeCol = maxCol - minCol + 1;

        // max Row doesn't account for 0 indexed 
        var scan = new string[maxRow+1, sizeCol];
        
        // Col = Col - MinCol
        StandardiseColCoordinates(rockLines, minCol);
        PopulateMapData(scan, rockLines);

        var sandStartCol = SandStartCol - minCol;
        scan[0, sandStartCol] = Input;

        return (scan, sandStartCol);
    }

    private static void PopulateMapData(string[,] scan, List<Line> rockLines)
    {
        PopulateRocks(scan, rockLines);
        PopulateAir(scan);
    }

    private static void PopulateAir(string[,] scan)
    {
        for (var row = 0; row < scan.GetLength(0); row++)
        {
            for (var col = 0; col < scan.GetLength(1); col++)
            {
                if (scan[row, col] != Rock) scan[row, col] = Air;
            }
        }
    }

    private static void PopulateRocks(string[,] scan, List<Line> rockLines)
    {
        foreach (var line in rockLines)
        {
            Coordinate? previousCoordinate = null;
            foreach (var coordinate in line.LinesCoordinates)
            {
                if (previousCoordinate.HasValue)
                {
                    DrawRockLine(scan, previousCoordinate.Value, coordinate);
                }
                
                previousCoordinate = coordinate;
            }
        }
    }

    private static void DrawRockLine(string[,] scan, Coordinate from, Coordinate to)
    {
        if (from.Row == to.Row)
        {
            // draw horizontal line
            for (var col = Math.Min(from.Col, to.Col); col <= Math.Max(from.Col, to.Col); col++)
            {
                scan[from.Row, col] = Rock;
            }
        }
        else
        {
            // draw vertical line
            for (var row = Math.Min(from.Row, to.Row); row <= Math.Max(from.Row, to.Row); row++)
            {
                scan[row, from.Col] = Rock;
            }
        }
    }
    
    private static void StandardiseColCoordinates(List<Line>rockLines, int minCol)
    {
        foreach (var t in rockLines)
        {
            var lineCoordinates = t.LinesCoordinates;
            for (var k = 0; k < lineCoordinates.Count; k++)
            {
                lineCoordinates[k] = new Coordinate {Col = lineCoordinates[k].Col - minCol, Row = lineCoordinates[k].Row};
            }
        }
    }

    private static List<Line> ParseLines(IEnumerable<string> input)
    {
        var lines = new List<Line>();
        
        foreach (var line in input)
        {
            var lineCoordinates = new List<Coordinate>();
            
            var split = line.Split("->", StringSplitOptions.TrimEntries);
            
            lineCoordinates.AddRange(split.Select(coordinate => coordinate.Split(','))
                .Select(coordinateParts => new Coordinate {Row = Convert.ToInt32(coordinateParts[1]), Col = Convert.ToInt32(coordinateParts[0])}));
            lines.Add(new Line {LinesCoordinates = lineCoordinates});
        }

        return lines;
    }

    private static void DrawScan(string[,] scan)
    {
        var sb = new StringBuilder("");
        
        for (var row = 0; row < scan.GetLength(0); row++)
        {
            sb.AppendLine();
            for (var col = 0; col < scan.GetLength(1); col++)
            {
                sb.Append(scan[row, col]);
            }
        }

        Console.WriteLine(sb.ToString());
    }

    private struct Coordinate
    {
        public int Row { get; init; }
        public int Col { get; init; }
    }

    private struct Line
    {
        public List<Coordinate> LinesCoordinates { get; init; }
    }
}