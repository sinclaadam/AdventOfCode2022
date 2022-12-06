using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayTwoTests
{
    [Theory]
    [InlineData(new []{"A X"}, 4)] // rock rock
    [InlineData(new []{"A Y"}, 8)] // rock paper
    [InlineData(new []{"A Z"}, 3)] // rock scissors
    [InlineData(new []{"B X"}, 1)] // paper rock
    [InlineData(new []{"B Y"}, 5)] // paper paper
    [InlineData(new []{"B Z"}, 9)] // paper scissors
    [InlineData(new []{"C X"}, 7)] // scissors rock
    [InlineData(new []{"C Y"}, 2)] // scissors paper
    [InlineData(new []{"C Z"}, 6)] // scissors scissors
    public void Given_All_OutComes_Returns_Correct_Score_Part_One(IEnumerable<string> input, int expectedScore)
    {
        var result = DayTwo.CalculateRockPaperScissorsPartOne(input);
        
        Assert.Equal(expectedScore, result);
    }
    
    [Theory]
    [InlineData(new []{"A X"}, 3)] // rock lose
    [InlineData(new []{"A Y"}, 4)] // rock draw
    [InlineData(new []{"A Z"}, 8)] // rock win
    [InlineData(new []{"B X"}, 1)] // paper lose
    [InlineData(new []{"B Y"}, 5)] // paper draw
    [InlineData(new []{"B Z"}, 9)] // paper win
    [InlineData(new []{"C X"}, 2)] // scissors lose
    [InlineData(new []{"C Y"}, 6)] // scissors draw
    [InlineData(new []{"C Z"}, 7)] // scissors win
    public void Given_All_OutComes_Returns_Correct_Score_Part_Two(IEnumerable<string> input, int expectedScore)
    {
        var result = DayTwo.CalculateRockPaperScissorsPartTwo(input);
        
        Assert.Equal(expectedScore, result);
    }
}