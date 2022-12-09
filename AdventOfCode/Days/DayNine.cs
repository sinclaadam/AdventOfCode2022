using AdventOfCode.Common;

namespace AdventOfCode.Days;

public static class DayNine
{
    public static int FindUniquePositionsVisitedByTail(IEnumerable<string> input)
    {
        var head = new Point {Row = 0, Col = 0};
        var tail = new Point {Row = 0, Col = 0};

        var visitedLocations = new HashSet<Point> {tail};

        SimulateRope(head, tail, input, visitedLocations);

        return visitedLocations.Count;
    }

    private static void SimulateRope(Point head, Point tail, IEnumerable<string> input, HashSet<Point> visitedLocations)
    {
        foreach (var movement in input)
        {
            var (direction, numberOfSteps) = ParseNextMotion(movement);
            
            for (var i = 0; i < numberOfSteps; i++)
            {
                head = Move(head, direction);
                tail = CheckAndMoveTail(head, tail, direction);
                visitedLocations.Add(tail);
            }
            
        }
    }

    private static Point CheckAndMoveTail(Point head, Point tail, Direction lastDirection)
    {
        if (tail.IsTouching(head)) return tail;

        return lastDirection switch
        {
            Direction.Up => head with {Row = head.Row - 1},
            Direction.Down => head with {Row = head.Row + 1},
            Direction.Left => head with {Col = head.Col + 1},
            Direction.Right => head with {Col = head.Col - 1},
            _ => throw new ArgumentException("Invalid Direction", nameof(lastDirection))
        };
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

    private struct Point
    {
        public int Row { get; init; }
        public int Col { get; init; }
    }
}