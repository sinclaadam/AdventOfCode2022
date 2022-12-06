namespace AdventOfCode.Days;

public static class DayOne
{
    public static int CalculateElfCarryingMostCalories(IEnumerable<string> inputs)
    {
        var allCalories = CalculateAllElfCalories(inputs);

        return allCalories.Max();
    }

    public static int CalculateTopThreeElfCarryingMostCalories(IEnumerable<string> inputs)
    {
        var allCalories = CalculateAllElfCalories(inputs);
        allCalories.Sort();

        return allCalories.TakeLast(3).Sum();
    }

    private static List<int> CalculateAllElfCalories(IEnumerable<string> inputs)
    {
        var allCalories = new List<int>();
        
        var elfCalorieCount = 0;
        
        foreach (var line in inputs)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                allCalories.Add(elfCalorieCount);
                elfCalorieCount = 0;
            }
            else
            {
                elfCalorieCount += int.Parse(line);
            }
        }

        return allCalories;
    }
}