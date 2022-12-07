﻿using AdventOfCode.Common;
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