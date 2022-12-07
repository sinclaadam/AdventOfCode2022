using System.Collections.Generic;
using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DayFiveTests
{
    private IEnumerable<string> exampleData = new[]
    {
        "            [C]         [N] [R]    ",
        "[J] [T]     [H]         [P] [L]    ",
        "[F] [S] [T] [B]         [M] [D]    ",
        "[C] [L] [J] [Z] [S]     [L] [B]    ",
        "[N] [Q] [G] [J] [J]     [F] [F] [R]",
        "[D] [V] [B] [L] [B] [Q] [D] [M] [T]",
        "[B] [Z] [Z] [T] [V] [S] [V] [S] [D]",
        "[W] [P] [P] [D] [G] [P] [B] [P] [V]",
        " 1   2   3   4   5   6   7   8   9 ",
        "",
        "move 1 from 2 to 1", // T S T C S Q N R R
        "move 3 from 1 to 3",
        "move 2 from 2 to 1",
        "move 1 from 1 to 2"
    };
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One()
    {
        var actual = DayFive.CalculateCrateOnTopPartOne(exampleData);
        
        Assert.Equal("SLFCSQNRR", actual);
    }
    
    [Fact]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_Two()
    {
        var actual = DayFive.CalculateCrateOnTopPartTwo(exampleData);
        
        Assert.Equal("LSTCSQNRR", actual);
    }
}