using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayTwelveTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi"
    };

    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayTwelve.FindSmallestPathNumber(exampleData);

        Assert.Equal(31, actual);
    }
}