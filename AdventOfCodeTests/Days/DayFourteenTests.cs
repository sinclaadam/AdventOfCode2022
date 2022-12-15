using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayFourteenTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "498,4 -> 498,6 -> 496,6",
        "503,4 -> 502,4 -> 502,9 -> 494,9",
    };
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayFourteen.CalculateUnitsOfSand(exampleData);
        
        Assert.Equal(24, actual);
    }
}