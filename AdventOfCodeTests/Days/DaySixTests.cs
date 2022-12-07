using AdventOfCode.Days;
using Xunit;

namespace AdventOfCodeTests.Days;

public class DaySixTests
{
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_One(string dataStream, int answer)
    {
        var actual = DaySix.ReportStartOfPacketMarker(dataStream);
        
        Assert.Equal(answer, actual);
    }
    
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Given_Example_When_Processed_Gives_Correct_Answer_For_Part_Two(string dataStream, int answer)
    {
        var actual = DaySix.ReportStartOfMessageMarker(dataStream);
        
        Assert.Equal(answer, actual);
    }

}