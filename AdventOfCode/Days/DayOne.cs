using AdventOfCode.Common;

namespace AdventOfCode.Days;

public static class DayOne
{
    private static int _elfWithMax = 0;
    private static int _maxCalories = 0;
    
    public static void CalculateElfCarryingMostCalories()
    {
        var input = FileInput.GetAllInputLinesForDay(1);

        var elfNumber = 1;
        var elfCalorieCount = 0;
        
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                CheckElfCalories(elfNumber, elfCalorieCount);
                elfNumber++;
                elfCalorieCount = 0;
            }
            else
            {
                elfCalorieCount += int.Parse(line);
            }
        }

        Console.WriteLine($"Day One Answer: Elf {_elfWithMax} has the maximum with {_maxCalories} calories");
    }

    private static void CheckElfCalories(int elfNumber, int calories)
    {
        if (calories > _maxCalories)
        {
            _elfWithMax = elfNumber;
            _maxCalories = calories;
        }
    }
}