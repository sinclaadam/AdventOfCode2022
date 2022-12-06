using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayThreeTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    };
        
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer()
    {
        var actual = DayThree.CalculatePrioritySum(exampleData);
        
        Assert.Equal(157, actual);
    }
}