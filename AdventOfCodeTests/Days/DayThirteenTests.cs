using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayThirteenTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "[1,1,3,1,1]",
        "[1,1,5,1,1]",
        "",
        "[[1],[2,3,4]]",
        "[[1],4]",
        "",
        "[9]",
        "[[8,7,6]]",
        "",
        "[[4,4],4,4]",
        "[[4,4],4,4,4]",
        "",
        "[7,7,7,7]",
        "[7,7,7]",
        "",
        "[]",
        "[3]",
        "",
        "[[[]]]",
        "[[]]",
        "",
        "[1,[2,[3,[4,[5,6,7]]]],8,9]",
        "[1,[2,[3,[4,[5,6,0]]]],8,9]",
    };
    
    private IEnumerable<string> exampleDataReversePairs = new[]
    {
        "[1,1,5,1,1]",
        "[1,1,3,1,1]",
        "",
        "[[1],4]",
        "[[1],[2,3,4]]",
        "",
        "[[8,7,6]]",
        "[9]",
        "",
        "[[4,4],4,4,4]",
        "[[4,4],4,4]",
        "",
        "[7,7,7]",
        "[7,7,7,7]",
        "",
        "[3]",
        "[]",
        "",
        "[[]]",
        "[[[]]]",
        "",
        "[1,[2,[3,[4,[5,6,0]]]],8,9]",
        "[1,[2,[3,[4,[5,6,7]]]],8,9]",
    };

    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayThirteen.SumValidIndices(exampleData);

        Assert.Equal(13, actual);
    }
    
    [Fact]
    public void Given_Reversed_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayThirteen.SumValidIndices(exampleDataReversePairs);

        Assert.Equal(23, actual);
    }

}