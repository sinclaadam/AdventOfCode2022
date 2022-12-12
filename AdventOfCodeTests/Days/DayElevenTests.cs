﻿using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayElevenTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "Monkey 0:",
        "Starting items: 79, 98",
        "Operation: new = old * 19",
        "Test: divisible by 23",
        "If true: throw to monkey 2",
        "If false: throw to monkey 3",
        "",
        "Monkey 1:",
        "Starting items: 54, 65, 75, 74",
        "Operation: new = old + 6",
        "Test: divisible by 19",
        "If true: throw to monkey 2",
        "If false: throw to monkey 0",
        "",
        "Monkey 2:",
        "Starting items: 79, 60, 97",
        "Operation: new = old * old",
        "Test: divisible by 13",
        "If true: throw to monkey 1",
        "If false: throw to monkey 3",
        "",
        "Monkey 3:",
        "Starting items: 74",
        "Operation: new = old + 3",
        "Test: divisible by 17",
        "If true: throw to monkey 0",
        "If false: throw to monkey 1"
    };

    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayEleven.CalculateMonkeyBusiness(exampleData);

        Assert.Equal(10605, actual);
    }
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_Two()
    {
        var actual = DayEleven.CalculateMonkeyBusinessPartTwo(exampleData);

        Assert.Equal(2713310158L, actual);
    }
}