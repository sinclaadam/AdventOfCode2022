namespace AdventOfCode.Days;

public static class DayFour
{
    public static int CalculateFullyContainedPairs(IEnumerable<string> pairs)
    {
        var count = 0;
        foreach (var pair in pairs)
        {
            var (sectionOne, sectionTwo) = SeparateSectionPairsToTuples(pair);
            if (DoesOneRangeContainTheOther(sectionOne, sectionTwo)) count++;
        }
        
        return count;
    }

    public static int CalculateOverlappingPairs(IEnumerable<string> pairs)
    {
        var count = 0;
        foreach (var pair in pairs)
        {
            var (sectionOne, sectionTwo) = SeparateSectionPairsToTuples(pair);
            if (DoRangesOverlap(sectionOne, sectionTwo)) count++;
        }
        
        return count;
    }

    private static (Tuple<int,int> first, Tuple<int,int> second) SeparateSectionPairsToTuples(string input)
    {
        var sectionPairs = input.Split(',');
        var firstPair = ParseNumbersFromSection(sectionPairs[0]);
        var secondPair = ParseNumbersFromSection(sectionPairs[1]);
        return (firstPair, secondPair);
    }

    private static Tuple<int, int> ParseNumbersFromSection(string section)
    {
        var sectionSplit = section.Split('-');

        var firstNumber = Convert.ToInt32(sectionSplit[0]);
        var secondNumber = Convert.ToInt32(sectionSplit[1]);

        return new Tuple<int, int>(firstNumber, secondNumber);
    }

    private static bool DoesOneRangeContainTheOther(Tuple<int, int> first, Tuple<int, int> second)
    {
        var firstContainsSecond = first.Item1 <= second.Item1 && first.Item2 >= second.Item2;
        var secondContainsFirst = second.Item1 <= first.Item1 && second.Item2 >= first.Item2;

        return firstContainsSecond || secondContainsFirst;
    }
    
    private static bool DoRangesOverlap(Tuple<int, int> first, Tuple<int, int> second)
    {
        return !(first.Item2 < second.Item1 || second.Item2 < first.Item1);
    }
}