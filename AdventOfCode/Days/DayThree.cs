using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days;

public static class DayThree
{
    public static int CalculatePrioritySum(IEnumerable<string> input)
    {
        var total = 0;
        
        foreach (var rucksack in input)
        {
            var (compartmentOne, compartmentTwo) = SplitRuckSack(rucksack);
            total += CompareCompartments(compartmentOne, compartmentTwo);
        }
        
        return total;
    }

    public static int CalculateBadgePrioritySum(IEnumerable<string> input)
    {
        var total = 0;
        var inputAsArray = input.ToArray();
        
        var groupOfRuckSacks = new List<string>();
        
        for (var i = 0; i < inputAsArray.Length; i++)
        {
            groupOfRuckSacks.Add(inputAsArray[i]);
            if (groupOfRuckSacks.Count != 3) continue;
            
            total += FindPriorityOfCommonItemInRucksacks(groupOfRuckSacks);
            groupOfRuckSacks.Clear();
        }

        return total;
    }

    private static int FindPriorityOfCommonItemInRucksacks(List<string> rucksacks)
    {
        var longestLength = rucksacks.Max(x => x.Length);
        var stringToCheck = rucksacks.First(x => x.Length == longestLength);
        
        foreach (var letter in stringToCheck.Where(letter => rucksacks.TrueForAll(x => x.Contains(letter))))
        {
            return GetPriority(letter.ToString());
        }

        throw new Exception();
    }

    private static (string compartmentOne, string compartmentTwo) SplitRuckSack(string input)
    {
        var halfLength = input.Length / 2;

        var compartmentOne = input[..halfLength];
        var compartmentTwo = input[halfLength..];
        return (compartmentOne, compartmentTwo);
    }

    private static int CompareCompartments(string first, string second)
    {
        foreach (var c in first)
        {
            if (second.Contains(c))
            {
               return GetPriority(c.ToString());
            }
        }

        return 0;
    }

    private static int GetPriority(string letter)
    {
        var lowerCase = new Regex("[a-z]");

        if (lowerCase.IsMatch(letter))
        {
            return Convert.ToInt32(letter[0]) - 96;
        }

        return Convert.ToInt32(letter[0]) - 38;
    }
}