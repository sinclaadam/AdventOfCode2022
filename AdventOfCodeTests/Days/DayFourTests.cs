using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayFourTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "2-4,6-8",
        "2-3,4-5",
        "5-7,7-9",
        "2-8,3-7",
        "6-6,4-6",
        "2-6,4-8"
    };
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayFour.CalculateFullyContainedPairs(exampleData);
        
        Assert.Equal(2, actual);
    }
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_Two()
    {
        var actual = DayFour.CalculateOverlappingPairs(exampleData);
        
        Assert.Equal(4, actual);
    }
}