using System.Text;

namespace AdventOfCode.Days;

public static class DayTwelve
{
    public static int FindSmallestPathNumber(IEnumerable<string> input)
    {
        var grid = ParseGrid(input);
        var path = FindSmallestPath(grid, false);
        var answer = CountNodes(path);
        return answer;
    }
    
    public static int FindSmallestPathNumberFromAllLowElevations(IEnumerable<string> input)
    {
        var grid = ParseGrid(input);
        var path = FindSmallestPath(grid, true);
        var answer = CountNodes(path);
        return answer;
    }

    private static Node<(int row, int col)> FindSmallestPath(char[,] grid, bool allLocations)
    {
        var startLocation = GetLocations(grid, 'S').First();
        var endLocation = GetLocations(grid, 'E').First();

        grid[startLocation.row, startLocation.col] = 'a';
        grid[endLocation.row, endLocation.col] = 'z';

        var gridCopy = (char[,])grid.Clone();

        var start = new Node<(int row, int col)>
        {
            Item = (startLocation.row, startLocation.col),
            CostSoFar = 0,
            HeuristicToGoal = CalculateManhattanDistanceHeuristic(startLocation, endLocation),
            PreviousItem = null
        };
        
        var fringe = new PriorityQueue<Node<(int row, int col)>, int>();
        
        if (allLocations)
        {
            var startingLocations = GetLocations(grid, 'a');
            var startingNodes = startingLocations.Select(x => new Node<(int row, int col)>
            {
                Item = (x.row, x.col),
                CostSoFar = 0,
                HeuristicToGoal = CalculateManhattanDistanceHeuristic(x, endLocation),
                PreviousItem = null
            });
            
            foreach (var startingNode in startingNodes)
            {
                fringe.Enqueue(startingNode, startingNode.EstimatedDistance);
            }
        }
        else
        {
            fringe.Enqueue(start, start.EstimatedDistance);
        }

        var visited = new HashSet<(int row, int col)>();
        
        while (fringe.Count > 0)
        {
            var node = fringe.Dequeue();
            visited.Add(node.Item);
            gridCopy[node.Item.row, node.Item.col] = '*';

            if (node.Item == endLocation) return node;
            var edges = FindAllUnvisitedEdges(node, visited, grid, endLocation);
            edges.ForEach(x => fringe.Enqueue(x, x.EstimatedDistance));
        }

        throw new Exception("No Path Found To End Goal");
    }

    private static List<Node<(int row, int col)>> FindAllUnvisitedEdges(Node<(int row, int col)> node,
        HashSet<(int row, int col)> visitedLocations, char[,] grid, (int row, int col) goal)
    {
        var edges = new List<Node<(int row, int col)>>();
        var row = node.Item.row;
        var col = node.Item.col;

        var newCost = node.CostSoFar + 1;

        // up
        if (row - 1 >= 0)
        {
            if (grid[row, col] + 1 >= grid[row - 1, col] && !visitedLocations.Contains((row - 1, col)))
            {
                edges.Add(new Node<(int row, int col)>
                {
                    Item = (row - 1, col),
                    CostSoFar = newCost,
                    HeuristicToGoal = CalculateManhattanDistanceHeuristic((row - 1, col), goal),
                    PreviousItem = node
                });
            }
        }

        // down
        if (row + 1 < grid.GetLength(0))
        {
            if (grid[row, col] + 1 >= grid[row + 1, col] && !visitedLocations.Contains((row + 1, col)))
            {
                edges.Add(new Node<(int row, int col)>
                {
                    Item = (row + 1, col),
                    CostSoFar = newCost,
                    HeuristicToGoal = CalculateManhattanDistanceHeuristic((row + 1, col), goal),
                    PreviousItem = node
                });
            }
        }

        // left
        if (col - 1 >= 0)
        {
            if (grid[row, col] + 1 >= grid[row, col - 1] && !visitedLocations.Contains((row, col - 1)))
            {
                edges.Add(new Node<(int row, int col)>
                {
                    Item = (row, col - 1),
                    CostSoFar = newCost,
                    HeuristicToGoal = CalculateManhattanDistanceHeuristic((row, col - 1), goal),
                    PreviousItem = node
                });
            }
        }

        //right
        if (col + 1 < grid.GetLength(1))
        {
            if (grid[row, col] + 1 >= grid[row, col + 1] && !visitedLocations.Contains((row, col + 1)))
            {
                edges.Add(new Node<(int row, int col)>
                {
                    Item = (row, col + 1),
                    CostSoFar = newCost,
                    HeuristicToGoal = CalculateManhattanDistanceHeuristic((row, col + 1), goal),
                    PreviousItem = node
                });
            }
        }

        return edges;
    }

    private static int CountNodes(Node<(int row, int col)> endNode)
    {
        var count = 0;

        while (endNode.PreviousItem != null)
        {
            endNode = endNode.PreviousItem;
            count++;
        }
        return count;
    }

    private static int CalculateManhattanDistanceHeuristic((int row, int col) currentLocation,
        (int row, int col) goalLocation)
    {
        return Math.Abs(currentLocation.row - goalLocation.row) + Math.Abs(currentLocation.col - goalLocation.col);
    }

    private static char[,] ParseGrid(IEnumerable<string> input)
    {
        var inputAsList = input.ToList();
        var rows = inputAsList.Count;
        var cols = inputAsList[0].Length;

        var heightMap = new char[rows, cols];

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (inputAsList[row][col] == 'S') heightMap[row, col] = 'S';
                else if (inputAsList[row][col] == 'E') heightMap[row, col] = 'E';
                else heightMap[row, col] = inputAsList[row][col];
            }
        }

        return heightMap;
    }

    private static List<(int row, int col)> GetLocations(char[,] grid, char find)
    {
        var locations = new List<(int row, int col)>();
        
        for (var row = 0; row < grid.GetLength(0); row++)
        {
            for (var col = 0; col < grid.GetLength(1); col++)
            {
                if (grid[row, col] == find) locations.Add((row, col));
            }
        }

        return locations;
    }

    private static void DrawGrid(char[,] grid)
    {
        Console.WriteLine();
        var sb = new StringBuilder();
        for (var row = 0; row < grid.GetLength(0); row++)
        {
            for (var col = 0; col < grid.GetLength(1); col++)
            {
                sb.Append(grid[row, col]);
            }

            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }

    private class Node<T>
    {
        public T Item { get; set; }
        public int CostSoFar { get; set; }
        public int HeuristicToGoal { get; set; }
        public int EstimatedDistance => CostSoFar + HeuristicToGoal;
        public Node<T>? PreviousItem { get; set; }
    }
}