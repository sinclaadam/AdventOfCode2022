namespace AdventOfCode.Days;

public static class DayTwo
{
    private const int LostGameScore = 0;
    private const int DrawGameScore = 3;
    private const int WinGameScore = 6;

    public static int CalculateRockPaperScissorsScore(IEnumerable<string> inputs)
    {
        return inputs.Sum(CalculateRoundScore);
    }

    private static int CalculateRoundScore(string game)
    {
        var (opponent, you) = GetHandPlayed(game);

        var score = GetScoreFromOutcome(opponent, you);
        score += GetScoreFromShape(you);
        
        return score;
    }

    private static int GetScoreFromShape(RockPaperScissors shape)
    {
        return Convert.ToInt32(shape);
    }

    private static int GetScoreFromOutcome(RockPaperScissors opponent, RockPaperScissors you)
    {
        if (you == opponent) return DrawGameScore;

        return you switch
        {
            RockPaperScissors.Rock when opponent == RockPaperScissors.Paper => LostGameScore,
            RockPaperScissors.Rock when opponent == RockPaperScissors.Scissors => WinGameScore,
            RockPaperScissors.Paper when opponent == RockPaperScissors.Rock => WinGameScore,
            RockPaperScissors.Paper when opponent == RockPaperScissors.Scissors => LostGameScore,
            RockPaperScissors.Scissors when opponent == RockPaperScissors.Rock => LostGameScore,
            RockPaperScissors.Scissors when opponent == RockPaperScissors.Paper => WinGameScore,
            _ => throw new Exception()
        };
    }

    private static (RockPaperScissors opponent, RockPaperScissors you) GetHandPlayed(string game)
    {
        var hand = game.Split(' ');
        var opponent = ParsePlay(hand[0]);
        var you = ParsePlay(hand[1]);
        return (opponent, you);
    }

    private static RockPaperScissors ParsePlay(string s)
    {
        switch (s)
        {
            case "A":
            case "X": return RockPaperScissors.Rock;
            case "B":
            case "Y": return RockPaperScissors.Paper;
            case "C":
            case "Z": return RockPaperScissors.Scissors;
            default: throw new ArgumentException(s);
        }
    }

    private enum RockPaperScissors
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}