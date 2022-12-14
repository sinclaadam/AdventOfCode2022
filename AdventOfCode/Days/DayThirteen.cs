using System.Text.Json.Nodes;

namespace AdventOfCode.Days;

public static class DayThirteen
{
    public static int SumValidIndices(IEnumerable<string> input)
    {
        var pairs = ParsePairs(input.ToList());

        var sum = 0;

        for (var i = 0; i < pairs.Count; i++)
        {
            if (IsCorrectOrder(pairs[i].left, pairs[i].right)) sum += i + 1;
        }

        return sum;
    }

    private static bool IsCorrectOrder(JsonNode left, JsonNode right)
    {
        var result = CompareArrays(left.AsArray(), right.AsArray());

            switch (result)
            {
                case Result.CorrectOrder:
                    return true;
                case Result.IncorrectOrder:
                    return false;
                case Result.NoResult:
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }

    private static Result CompareArrays(JsonArray left, JsonArray right)
    {
        for (var i = 0; i < Math.Min(left.Count, right.Count); i++)
        {
            Result result;

            switch (left[i])
            {
                case JsonArray l when right[i] is JsonArray r:
                    result = CompareArrays(l, r);
                    if (result != Result.NoResult) return result;
                    break;
                case JsonValue l when right[i] is JsonValue r:
                    result = CompareValues(l, r);
                    if (result != Result.NoResult) return result;
                    break;
                default:
                    result = CompareMixedTypes(left[i]!, right[i]!);
                    if (result != Result.NoResult) return result;
                    break;
            }
        }

        if (left.Count == right.Count) return Result.NoResult;
        return left.Count > right.Count ? Result.IncorrectOrder : Result.CorrectOrder;
    }

    private static Result CompareMixedTypes(JsonNode left, JsonNode right)
    {
        var arrayWrapper = new JsonArray();
        
        if (left is JsonValue)
        {
            arrayWrapper.Add(left.GetValue<int>());
            return CompareArrays(arrayWrapper, right.AsArray());
        }
        
        arrayWrapper.Add(right.GetValue<int>());
        return CompareArrays(left.AsArray(), arrayWrapper);
    }

    private static Result CompareValues(JsonValue left, JsonValue right)
    {
        var leftNumber = left.GetValue<int>();
        var rightNumber = right.GetValue<int>();

        if (leftNumber == rightNumber) return Result.NoResult;

        return leftNumber > rightNumber ? Result.IncorrectOrder : Result.CorrectOrder;
    }


    private static List<(JsonNode left, JsonNode right)> ParsePairs(List<string> input)
    {
        var pairs = new List<(JsonNode left, JsonNode right)>();

        for (var i = 0; i < input.Count; i += 3)
        {
            var left = JsonNode.Parse(input[0 + i])!;
            var right = JsonNode.Parse(input[1 + i])!;
            pairs.Add((left, right));
        }

        return pairs;
    }

    private enum Result
    {
        CorrectOrder,
        IncorrectOrder,
        NoResult
    }
}