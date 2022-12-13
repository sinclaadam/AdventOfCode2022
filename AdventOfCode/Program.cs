using AdventOfCode.Common;
using AdventOfCode.Days;

var dayOnePartOne = DayOne.CalculateElfCarryingMostCalories(FileInput.GetAllInputLinesForDay(1));
var dayOnePartTwo = DayOne.CalculateTopThreeElfCarryingMostCalories(FileInput.GetAllInputLinesForDay(1));
Console.WriteLine($"Day One. Part One: {dayOnePartOne}. Part Two: {dayOnePartTwo}.");

var dayTwoPartOne = DayTwo.CalculateRockPaperScissorsPartOne(FileInput.GetAllInputLinesForDay(2));
var dayTwoPartTwo = DayTwo.CalculateRockPaperScissorsPartTwo(FileInput.GetAllInputLinesForDay(2));
Console.WriteLine($"Day Two. Part One: {dayTwoPartOne}. Part Two: {dayTwoPartTwo}.");

var dayThreePartOne = DayThree.CalculatePrioritySum(FileInput.GetAllInputLinesForDay(3));
var dayThreePartTwo = DayThree.CalculateBadgePrioritySum(FileInput.GetAllInputLinesForDay(3));
Console.WriteLine($"Day Three. Part One: {dayThreePartOne}. Part Two: {dayThreePartTwo}.");

var dayFourPartOne = DayFour.CalculateFullyContainedPairs(FileInput.GetAllInputLinesForDay(4));
var dayFourPartTwo = DayFour.CalculateOverlappingPairs(FileInput.GetAllInputLinesForDay(4));
Console.WriteLine($"Day Four. Part One: {dayFourPartOne}. Part Two: {dayFourPartTwo}.");

var dayFivePartOne = DayFive.CalculateCrateOnTopPartOne(FileInput.GetAllInputLinesForDay(5));
var dayFivePartTwo = DayFive.CalculateCrateOnTopPartTwo(FileInput.GetAllInputLinesForDay(5));
Console.WriteLine($"Day Five. Part One: {dayFivePartOne}. Part Two: {dayFivePartTwo}.");

var daySixPartOne = DaySix.ReportStartOfPacketMarker(FileInput.GetSingleLineInput(6));
var daySixPartTwo = DaySix.ReportStartOfMessageMarker(FileInput.GetSingleLineInput(6));
Console.WriteLine($"Day Six. Part One: {daySixPartOne}. Part Two: {daySixPartTwo}.");

var daySevenPartOne = DaySeven.SumDirectoriesUnderThreshold(FileInput.GetAllInputLinesForDay(7));
var daySevenPartTwo = DaySeven.FindClosestSizeDirectoryOverThreshold(FileInput.GetAllInputLinesForDay(7));
Console.WriteLine($"Day Seven. Part One: {daySevenPartOne}. Part Two: {daySevenPartTwo}.");

var dayEightPartOne = DayEight.CountVisibleTrees(FileInput.GetAllInputLinesForDay(8));
var dayEightPartTwo = DayEight.GetBestScenicScore(FileInput.GetAllInputLinesForDay(8));
Console.WriteLine($"Day Eight. Part One: {dayEightPartOne}. Part Two: {dayEightPartTwo}.");

var dayNinePartOne = DayNine.FindUniquePositionsVisitedByTail(FileInput.GetAllInputLinesForDay(9), 1);
var dayNinePartTwo = DayNine.FindUniquePositionsVisitedByTail(FileInput.GetAllInputLinesForDay(9), 9);
Console.WriteLine($"Day Nine. Part One: {dayNinePartOne}. Part Two: {dayNinePartTwo}.");

var dayTenPartOne = DayTen.SumSignalStrengths(FileInput.GetAllInputLinesForDay(10));
var dayTenPartTwo = DayTen.DrawPicture(FileInput.GetAllInputLinesForDay(10));
Console.WriteLine($"Day Ten. Part One: {dayTenPartOne}. Part Two:{Environment.NewLine}{dayTenPartTwo}");

var dayElevenPartOne = DayEleven.CalculateMonkeyBusiness(FileInput.GetAllInputLinesForDay(11));
var dayElevenPartTwo = DayEleven.CalculateMonkeyBusinessPartTwo(FileInput.GetAllInputLinesForDay(11));
Console.WriteLine($"Day Eleven. Part One: {dayElevenPartOne}. Part Two: {dayElevenPartTwo}.");

var dayTwelvePartOne = DayTwelve.FindSmallestPathNumber(FileInput.GetAllInputLinesForDay(12));
var dayTwelvePartTwo = DayTwelve.FindSmallestPathNumberFromAllLowElevations(FileInput.GetAllInputLinesForDay(12));
Console.WriteLine($"Day Twelve. Part One: {dayTwelvePartOne}. Part Two: {dayTwelvePartTwo}.");