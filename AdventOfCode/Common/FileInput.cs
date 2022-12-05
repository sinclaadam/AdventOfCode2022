﻿namespace AdventOfCode.Common;

public static class FileInput
{
    public static IEnumerable<string> GetAllInputLinesForDay(int day)
    {
        var path = Path.Combine("Inputs", $"{day}.txt");

        return File.ReadAllLines(path);
    }
}