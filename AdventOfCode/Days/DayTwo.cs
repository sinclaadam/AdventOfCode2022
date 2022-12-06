namespace AdventOfCode.Days;

public static class DayTwo
{
    private const int LostGameScore = 0;
    private const int DrawGameScore = 3;
    private const int WinGameScore = 6;
    
    public static int CalculateRockPaperScissorsPartOne(IEnumerable<string> inputs)
    {
        return inputs.Sum(CalculateRoundScore);
    }

    public static int CalculateRockPaperScissorsPartTwo(IEnumerable<string> inputs)
    {
        return inputs.Sum(CalculateRoundScorePartTwo);
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

    private static int CalculateRoundScorePartTwo(string game)
    {
        var gameInputs = game.Split(' ');
        
        var opponent = ParsePartOnePlay(gameInputs[0]);

        var gameResult = ParseGameResult(gameInputs[1]);

        return GetPointsForGamePartTwo(opponent, gameResult);

    }

    private static GameResult ParseGameResult(string letter)
    {
        return letter switch
        {
            "X" => GameResult.Lose,
            "Y" => GameResult.Draw,
            "Z" => GameResult.Win,
            _ => throw new Exception()
        };
    }

    private static int GetPointsForGamePartTwo(RockPaperScissors opponent, GameResult gameResult)
    {
        return gameResult switch
        {
            GameResult.Draw => Convert.ToInt32(GameResult.Draw) + Convert.ToInt32(opponent),
            GameResult.Win when opponent == RockPaperScissors.Rock => Convert.ToInt32(GameResult.Win) + Convert.ToInt32(RockPaperScissors.Paper),
            GameResult.Win when opponent == RockPaperScissors.Paper => Convert.ToInt32(GameResult.Win) + Convert.ToInt32(RockPaperScissors.Scissors),
            GameResult.Win when opponent == RockPaperScissors.Scissors => Convert.ToInt32(GameResult.Win) + Convert.ToInt32(RockPaperScissors.Rock),
            GameResult.Lose when opponent == RockPaperScissors.Rock => Convert.ToInt32(GameResult.Lose) + Convert.ToInt32(RockPaperScissors.Scissors),
            GameResult.Lose when opponent == RockPaperScissors.Paper => Convert.ToInt32(GameResult.Lose) + Convert.ToInt32(RockPaperScissors.Rock),
            GameResult.Lose when opponent == RockPaperScissors.Scissors => Convert.ToInt32(GameResult.Lose) + Convert.ToInt32(RockPaperScissors.Paper),
            _ => throw new Exception()
        };
    }

    private static (RockPaperScissors opponent, RockPaperScissors you) GetHandPlayed(string game)
    {
        var hand = game.Split(' ');
        var opponent = ParsePartOnePlay(hand[0]);
        var you = ParsePartOnePlay(hand[1]);
        return (opponent, you);
    }

    private static RockPaperScissors ParsePartOnePlay(string s)
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

    private enum GameResult
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
}