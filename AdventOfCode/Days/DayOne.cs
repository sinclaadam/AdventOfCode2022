namespace AdventOfCode.Days;

public static class DayOne
{
    private static int _maxCalories = 0;
    
    public static int CalculateElfCarryingMostCalories(IEnumerable<string> inputs)
    {
        var elfCalorieCount = 0;
        
        foreach (var line in inputs)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                CheckElfCalories(elfCalorieCount);
                elfCalorieCount = 0;
            }
            else
            {
                elfCalorieCount += int.Parse(line);
            }
        }

        return _maxCalories;
    }

    private static void CheckElfCalories(int calories)
    {
        if (calories > _maxCalories)
        {
            _maxCalories = calories;
        }
    }
}