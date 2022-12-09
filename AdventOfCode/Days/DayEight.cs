namespace AdventOfCode.Days;

public static class DayEight
{
    public static int CountVisibleTrees(IEnumerable<string> input)
    {
        var forest = ParseForest(input);
        SetForestVisibility(forest);
        return CountVisibleTreesInForest(forest);
    }
    
    public static int GetBestScenicScore(IEnumerable<string> input)
    {
        var forest = ParseForest(input);
        var bestScenicScore = SetForestVisibility(forest);
        return bestScenicScore;
    }

    private static int CountVisibleTreesInForest(Tree[,] forest)
    {
        var total = 0;

        for (var row = 0; row < forest.GetLength(0); row++)
        {
            for (var col = 0; col < forest.GetLength(1); col++)
            {
                var tree = forest[row, col];
                if (tree.Visible[Direction.Top]
                    || tree.Visible[Direction.Left]
                    || tree.Visible[Direction.Bottom]
                    || tree.Visible[Direction.Right]) total++;
            }
        }

        return total;
    }

    private static Tree[,] ParseForest(IEnumerable<string> input)
    {
        var inputAsArray = input.ToArray();

        var width = inputAsArray[0].Length;
        var length = inputAsArray.Length;

        var forest = new Tree[width, length];

        for (var row = 0; row < length; row++)
        {
            for (var col = 0; col < width; col++)
            {
                var tree = new Tree
                {
                    Size = Convert.ToInt32(inputAsArray[row][col].ToString())
                };

                forest[row, col] = tree;
            }
        }

        return forest;
    }

    private static int SetForestVisibility(Tree[,] forest)
    {
        var bestScenicScore = 0;
        
        for (var row = 0; row < forest.GetLength(0); row++)
        {
            for (var col = 0; col < forest.GetLength(1); col++)
            {
                var scenicScore = CheckVisibilityInAllDirections(row, col, forest);
                if (scenicScore > bestScenicScore) bestScenicScore = scenicScore;
            }
        }
        return bestScenicScore;
    }
    
    private static int CheckVisibilityInAllDirections(int row, int col, Tree[,] forest)
    {
        var topNumber = CheckVisibilityTop(row, col, forest);
        var bottomNumber = CheckVisibilityBottom(row, col, forest);
        var leftNumber = CheckVisibilityLeft(row, col, forest);
        var rightNumber = CheckVisibilityRight(row, col, forest);

        return topNumber * bottomNumber * leftNumber * rightNumber;
    }
    
    private static int CheckVisibilityTop(int row, int col, Tree[,] forest)
    {
        var tree = forest[row, col];
        var visible = true;
        var count = 0;
        
        while (row > 0)
        {
            row -= 1;
            count++;
            if (!tree.IsBiggerThan(forest[row, col]))
            {
                visible = false;
                break;
            }
        }
        
        tree.Visible.Add(Direction.Top, visible);
        return count;
    }
    
    private static int CheckVisibilityBottom(int row, int col, Tree[,] forest)
    {
        var tree = forest[row, col];
        var visible = true;
        var count = 0;

        while (row < forest.GetUpperBound(0))
        {
            row += 1;
            count++;
            if (!tree.IsBiggerThan(forest[row, col]))
            {
                visible = false;
                break;
            }
        }
        
        tree.Visible.Add(Direction.Bottom, visible);
        return count;
    }
    
    private static int CheckVisibilityLeft(int row, int col, Tree[,] forest)
    {
        var tree = forest[row, col];
        var visible = true;
        var count = 0;

        while (col > 0)
        {
            col -= 1;
            count++;
            if (!tree.IsBiggerThan(forest[row, col]))
            {
                visible = false;
                break;
            }
        }
        
        tree.Visible.Add(Direction.Left, visible);
        return count;
    }
    
    private static int CheckVisibilityRight(int row, int col, Tree[,] forest)
    {
        var tree = forest[row, col];
        var visible = true;
        var count = 0;

        while (col < forest.GetUpperBound(1))
        {
            col += 1;
            count++;
            if (!tree.IsBiggerThan(forest[row, col]))
            {
                visible = false;
                break;
            }
        }
        
        tree.Visible.Add(Direction.Right, visible);
        return count;
    }

    private class Tree
    {
        public int Size { get; set; }
        public Dictionary<Direction, bool> Visible { get; } = new();
    }

    private enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
    }

    private static bool IsBiggerThan(this Tree first, Tree second)
    {
        return first.Size > second.Size;
    }
}