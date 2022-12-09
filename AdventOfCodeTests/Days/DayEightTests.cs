using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayEightTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "30373",
        "25512",
        "65332",
        "33549",
        "35390"
    };
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayEight.CountVisibleTrees(exampleData);
        
        Assert.Equal(21, actual);
    }
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_Two()
    {
        var actual = DayEight.GetBestScenicScore(exampleData);
        
        Assert.Equal(8, actual);
    }
}