namespace AdventOfCode.Days;

public static class DaySix
{
    public static int ReportStartOfPacketMarker(string input)
    {
        return ReportUniqueSection(input, 4);
    }
    
    public static int ReportStartOfMessageMarker(string input)
    {
        return ReportUniqueSection(input, 14);
    }

    private static int ReportUniqueSection(string input, int size)
    {
        for (var i = 0; i < input.Length-size; i++)
        {
            var section = input.Substring(i, size);
            if (IsSectionSequenceUnique(section)) return i + size;
        }
        return default;
    }

    private static bool IsSectionSequenceUnique(string section)
    {
        var set = new HashSet<char>(section.ToCharArray());
        return set.Count == section.Length;
    }
}