using AdventOfCode.Common;
using AdventOfCode.Days;

var dayOne = DayOne.CalculateElfCarryingMostCalories(FileInput.GetAllInputLinesForDay(1));
Console.WriteLine($"Day One: {dayOne}");

var dayTwoPartOne = DayTwo.CalculateRockPaperScissorsPartOne(FileInput.GetAllInputLinesForDay(2));
var dayTwoPartTwo = DayTwo.CalculateRockPaperScissorsPartTwo(FileInput.GetAllInputLinesForDay(2));
Console.WriteLine($"Day Two. Part One: {dayTwoPartOne}. Part Two: {dayTwoPartTwo}");