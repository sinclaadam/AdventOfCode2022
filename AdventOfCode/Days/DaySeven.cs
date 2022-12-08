namespace AdventOfCode.Days;

public static class DaySeven
{
    private const int TotalDiskSpace = 70_000_000;

    public static int SumDirectoriesUnderThreshold(IEnumerable<string> input)
    {
        var rootDirectory = new Directory
        {
            Name = "/"
        };

        CreateTree(rootDirectory, input);

        var answer = SumDirectoriesUnderSize(100_000, rootDirectory);

        return answer;
    }

    public static int FindClosestSizeDirectoryOverThreshold(IEnumerable<string> input)
    {
        var rootDirectory = new Directory
        {
            Name = "/"
        };

        CreateTree(rootDirectory, input);

        var answer = FindDirectoryToDelete(30_000_000, rootDirectory);

        return answer.Size;
    }

    private static void CreateTree(Directory node, IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            if (line.StartsWith("$")) node = ParseCommand(node, line);
            else ParseOutput(node, line);
        }
    }

    private static Directory ParseCommand(Directory directory, string line)
    {
        var lineParts = line.Split(' ');
        if (lineParts[1].Equals("ls")) return directory;

        // Must be cd instruction
        switch (lineParts[2])
        {
            case "..":
                return directory.Parent!;
            case "/":
                return GetRootDirectory(directory);
        }

        var directoryName = lineParts[2];
        var childDirectory = directory.Children.FirstOrDefault(x => x.Name.Equals(directoryName));

        if (childDirectory is not null)
        {
            return childDirectory;
        }

        childDirectory = new Directory
        {
            Name = directoryName,
            Parent = directory
        };

        directory.Children.Add(childDirectory);
        return childDirectory;
    }

    private static Directory GetRootDirectory(Directory directory)
    {
        while (directory.Parent is not null)
        {
            directory = directory.Parent;
        }

        return directory;
    }

    private static void ParseOutput(Directory directory, string line)
    {
        var lineParts = line.Split(' ');

        if (!int.TryParse(lineParts[0], out var size)) return;

        var fileName = lineParts[1];
        var file = directory.Files.FirstOrDefault(x => x.Name.Equals(fileName));

        if (file is null)
        {
            directory.Files.Add(new File
            {
                Name = fileName,
                Size = size
            });
        }
    }

    private static int SumDirectoriesUnderSize(int threshold, Directory directory)
    {
        var total = 0;

        if (directory.Size < threshold) total += directory.Size;

        total += directory.Children.Sum(directoryChild => SumDirectoriesUnderSize(threshold, directoryChild));

        return total;
    }

    private static Directory FindDirectoryToDelete(int freeSpaceNeeded, Directory rootDirectory)
    {
        var needToDelete = Math.Abs(TotalDiskSpace - rootDirectory.Size - freeSpaceNeeded);
        var answer = FindBestChild(rootDirectory, needToDelete);

        return answer;
    }

    private static Directory FindBestChild(Directory directory, int needToDelete)
    {
        if (directory.Size < needToDelete) return directory.Parent!;
        var best = directory;

        foreach (var child in directory.Children)
        {
            var canidate = FindBestChild(child, needToDelete);
            if (canidate.Size >= needToDelete && canidate.Size < best.Size) best = canidate;
        }

        return best;
    }
}

public class Directory
{
    public Directory? Parent { get; set; }
    public string Name { get; set; } = default!;
    public List<Directory> Children { get; } = new();
    public List<File> Files { get; } = new();

    public int Size
    {
        get { return Files.Sum(x => x.Size) + Children.Sum(x => x.Size); }
    }
}

public class File
{
    public string Name { get; set; } = default!;
    public int Size { get; set; }
}