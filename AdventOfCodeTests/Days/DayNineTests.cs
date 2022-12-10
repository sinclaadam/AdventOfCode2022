using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayNineTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "R 4",
        "U 4",
        "L 3",
        "D 1",
        "R 4",
        "D 1",
        "L 5",
        "R 2"
    };
    
    private IEnumerable<string> largerExampleData = new[]
    {
        "R 5",
        "U 8",
        "L 8",
        "D 3",
        "R 17",
        "D 10",
        "L 25",
        "U 20"
    };
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayNine.FindUniquePositionsVisitedByTail(exampleData, 1);
        
        Assert.Equal(13, actual);
    }
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_Two()
    {
        var actual = DayNine.FindUniquePositionsVisitedByTail(exampleData, 9);

        Assert.Equal(1, actual);
    }
    
    [Fact]
    public void Given_Larger_Example_When_Processed_Gives_Correct_Answer_For_Part_Two()
    {
        var actual = DayNine.FindUniquePositionsVisitedByTail(largerExampleData, 9);
        
        Assert.Equal(36, actual);
    }
}