using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayTwoTests
{
    [Theory]
    [InlineData(new []{"A X"}, 4)] // rock rock
    [InlineData(new []{"A Y"}, 1)] // rock paper
    [InlineData(new []{"A Z"}, 7)] // rock scissors
    [InlineData(new []{"B X"}, 8)] // paper rock
    [InlineData(new []{"B Y"}, 5)] // paper paper
    [InlineData(new []{"B Z"}, 2)] // paper scissors
    [InlineData(new []{"C X"}, 3)] // scissors rock
    [InlineData(new []{"C Y"}, 9)] // scissors paper
    [InlineData(new []{"C Z"}, 6)] // scissors scissors
    public void Given_All_OutComes_Returns_Correct_Score(IEnumerable<string> input, int expectedScore)
    {
        var result = DayTwo.CalculateRockPaperScissorsScore(input);
        
        Assert.Equal(expectedScore, result);
    }
}