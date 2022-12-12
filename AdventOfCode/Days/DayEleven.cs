using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Days;

public static class DayEleven
{
    private static readonly Regex NumbersCapture = new("[0-9]+");

    public static int CalculateMonkeyBusiness(IEnumerable<string> input)
    {
        var monkeys = ParseInput(input);
        CompleteRounds(monkeys, 20, true);
        var inspections = monkeys.Select(x => x.ItemInspectionCount).ToList();
        inspections.Sort();
        return inspections[^2] * inspections[^1];
    }
    
    public static long CalculateMonkeyBusinessPartTwo(IEnumerable<string> input)
    {
        var monkeys = ParseInput(input);
        CompleteRounds(monkeys, 10_000, false);
        var inspections = monkeys.Select(x => Convert.ToInt64(x.ItemInspectionCount)).ToList();
        inspections.Sort();
        return inspections[^2] * inspections[^1];
    }

    private static void CompleteRounds(List<Monkey> monkeys, int rounds, bool isPartOne)
    {
        for (var round = 0; round < rounds; round++)
        {
            for (var monkey = 0; monkey < monkeys.Count; monkey++)
            {
                CompleteMonkeyTurn(monkeys, monkey, isPartOne);
            }
        }
    }

    private static void CompleteMonkeyTurn(List<Monkey> monkeys, int monkeyNumber, bool isPartOne)
    {
        var monkey = monkeys[monkeyNumber];
        
        for (var i = 0; i < monkey.Items.Count; i++)
        {
            monkey.ItemInspectionCount++;
            var item = monkey.Items[i];
            
            item = monkey.Operation(item);

            item = TransformWorry(item, isPartOne, monkeys);

            if (item % monkey.TestDivisibleNumber == 0)
            {
                monkeys[monkey.TrueThrowToMonkey].Items.Add(item);
            }
            else
            {
                monkeys[monkey.FalseThrowToMonkey].Items.Add(item);
            }

            monkey.Items.RemoveAt(i);
            i--;
            
        }
    }

    private static long TransformWorry(long worry, bool isPartOne, List<Monkey> monkeys)
    {
        if (isPartOne) return worry /= 3;

        var divide = monkeys.Select(x => x.TestDivisibleNumber).Aggregate(1, (i, i1) => i * i1);
        return worry % divide;
    }

    private static List<Monkey> ParseInput(IEnumerable<string> input)
    {
        var list = input.ToList();
        var monkeys = new List<Monkey>();

        for (var i = 0; i < list.Count; i += 7)
        {
            var startingItems = NumbersCapture.Matches(list[1 + i]).Select(x => Convert.ToInt64(x.Value)).ToList();
            var operation = ParseOperation(list[2 + i]);
            var testDivisibleNumber = Convert.ToInt32(NumbersCapture.Match(list[3 + i]).Value);
            var trueThrowToMoney = Convert.ToInt32(NumbersCapture.Match(list[4 + i]).Value);
            var falseThrowToMoney = Convert.ToInt32(NumbersCapture.Match(list[5 + i]).Value);
            
            monkeys.Add(new Monkey
            {
                ItemInspectionCount = 0,
                Items = startingItems,
                Operation = operation,
                TestDivisibleNumber = testDivisibleNumber,
                TrueThrowToMonkey = trueThrowToMoney,
                FalseThrowToMonkey = falseThrowToMoney,

            });
        }

        return monkeys;
    }

    private static Func<long, long> ParseOperation(string line)
    {
        var lineParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var operand = lineParts[4];
        var value = lineParts[5];

        return operand switch
        {
            "*" when value == "old" => checked(i => i * i),
            "+" when value == "old" => checked(i => i + i),
            "*" => i => checked(i * Convert.ToInt64(value)),
            "+" => i => checked(i + Convert.ToInt64(value)),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private class Monkey
    {
        public int ItemInspectionCount { get; set; }
        public List<long> Items { get; init; } = new();
        public Func<long, long> Operation { get; init; } = default!;
        public int TestDivisibleNumber { get; init; }
        public int TrueThrowToMonkey { get; init; }
        public int FalseThrowToMonkey { get; init; }
    }
}