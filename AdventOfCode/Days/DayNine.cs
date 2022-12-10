using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days;

public static class DayNine
{
    public static int FindUniquePositionsVisitedByTail(IEnumerable<string> input, int knotNumber)
    {
        var knots = Enumerable.Repeat(new Point {Row = 0, Col = 0}, knotNumber + 1).ToList(); // include head

        var visitedLocations = new HashSet<Point> {knots.Last()};

        SimulateRope(knots, input, visitedLocations);

        return visitedLocations.Count;
    }

    private static void SimulateRope(List<Point> knots, IEnumerable<string> input, HashSet<Point> visitedLocations)
    {
        foreach (var movement in input)
        {
            var (direction, numberOfSteps) = ParseNextMotion(movement);

            for (var i = 0; i < numberOfSteps; i++)
            {
                knots[0] = Move(knots[0], direction);

                for (var index = 1; index < knots.Count; index++)
                {
                    knots[index] = CheckAndMoveKnots(knots[index - 1], knots[index], direction);
                }

                visitedLocations.Add(knots.Last());
            }
        }
    }

    private static Point CheckAndMoveKnots(Point lastPoint, Point pointToMove, Direction lastDirection)
    {
        if (pointToMove.IsTouching(lastPoint)) return pointToMove;
        
        var leftRightMove = pointToMove.Col - lastPoint.Col;
        leftRightMove = Math.Clamp(leftRightMove, -1, 1);

        var upDownMove = pointToMove.Row - lastPoint.Row;
        upDownMove = Math.Clamp(upDownMove, -1, 1);

        return new Point {Row = pointToMove.Row - upDownMove, Col = pointToMove.Col - leftRightMove};
    }

    private static (Direction direction, int numberOfSteps) ParseNextMotion(string motion)
    {
        var lineParts = motion.Split(' ');
        var numberOfSteps = Convert.ToInt32(lineParts[1]);

        return lineParts[0] switch
        {
            "U" => (Direction.Up, numberOfSteps),
            "D" => (Direction.Down, numberOfSteps),
            "L" => (Direction.Left, numberOfSteps),
            "R" => (Direction.Right, numberOfSteps),
            _ => throw new ArgumentException($"Unexpected Direction {lineParts[0]}", nameof(motion))
        };
    }

    private static Point Move(Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => point with {Row = point.Row + 1},
            Direction.Down => point with {Row = point.Row - 1},
            Direction.Left => point with {Col = point.Col - 1},
            Direction.Right => point with {Col = point.Col + 1},
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    private static bool IsTouching(this Point point, Point otherPoint)
    {
        return Math.Abs(point.Row - otherPoint.Row) <= 1
               && Math.Abs(point.Col - otherPoint.Col) <= 1;
    }

    private static void Draw(this List<Point> knots, int gridSize)
    {
        var sb = new StringBuilder();
        for (var row = gridSize; row > -gridSize; row--)
        {
            for (var col = -gridSize; col < gridSize; col++)
            {
                var knotIndexAtLocation = knots.FindIndex(x => x.Col == col && x.Row == row);
                if (knotIndexAtLocation != -1)
                {
                    sb.Append(knotIndexAtLocation == 0 ? "H" : knotIndexAtLocation);
                }
                else
                {
                    sb.Append('.');
                }
            }

            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }

    private struct Point
    {
        public int Row { get; init; }
        public int Col { get; init; }
    }
}