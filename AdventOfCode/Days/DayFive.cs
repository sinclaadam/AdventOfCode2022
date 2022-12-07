using System.Text;

namespace AdventOfCode.Days;

public class DayFive
{
    public static string CalculateCrateOnTopPartOne(IEnumerable<string> input)
    {
        var stacksOfCrates = ParseStartingState(input);
        var instructions = ParseInstructions(input);
        CompleteAllInstructionsCrane5000(stacksOfCrates, instructions);

        return GetAnswerStringFromFinishState(stacksOfCrates);
    }
    
    public static string CalculateCrateOnTopPartTwo(IEnumerable<string> input)
    {
        var stacksOfCrates = ParseStartingState(input);
        var instructions = ParseInstructions(input);
        CompleteAllInstructionsCrane5001(stacksOfCrates, instructions);

        return GetAnswerStringFromFinishState(stacksOfCrates);
    }
    

    private static IEnumerable<MoveInstruction> ParseInstructions(IEnumerable<string> input)
    {
        var isInstructions = false;
        var instructions = new List<MoveInstruction>();
        
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                isInstructions = true;
                continue;
            }

            if (!isInstructions) continue;
            
            var instructionSplit = line.Split(' ');
            instructions.Add(new MoveInstruction
            {
                StacksToMove = Convert.ToInt32(instructionSplit[1]),
                From = Convert.ToInt32(instructionSplit[3])-1, // Indexed from 0
                To = Convert.ToInt32(instructionSplit[5])-1 // Indexed from 0
            });
        }

        return instructions;
    }

    private static List<Stack<string>> ParseStartingState(IEnumerable<string> input)
    {
        var items = new List<List<string>>();
        for (var i = 0; i < 9; i++)
        {
            items.Add(new List<string>());
        }

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line)) break;
            var stackNumber = 0;
            for (var i = 1; i < line.Length; i += 4)
            {
                var item = line[i].ToString();
                if (!(string.IsNullOrWhiteSpace(item) || int.TryParse(item, out _)))
                {
                    items[stackNumber].Add(item);
                }
                stackNumber++;
            }
        }
        
        items.ForEach(x => x.Reverse());
        var startingState = items.Select(x => new Stack<string>(x));
        return startingState.ToList();
    }
    
    private static string GetAnswerStringFromFinishState(List<Stack<string>> stacksOfCrates)
    {
        var sb = new StringBuilder();
        
        stacksOfCrates.ForEach(x => sb.Append(x.Pop()));

        return sb.ToString();
    }

    private static void CompleteAllInstructionsCrane5000(List<Stack<string>> crates, IEnumerable<MoveInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            for (var i = 0; i < instruction.StacksToMove; i++)
            {
                var crate = crates[instruction.From].Pop();
                
                crates[instruction.To].Push(crate);
            }
        }
    }
    
    private static void CompleteAllInstructionsCrane5001(List<Stack<string>> crates, IEnumerable<MoveInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            var cratesToMove = new List<string>();
            for (var i = 0; i < instruction.StacksToMove; i++)
            {
                cratesToMove.Add(crates[instruction.From].Pop());
            }

            cratesToMove.Reverse();
            cratesToMove.ForEach(x => crates[instruction.To].Push(x));
        }
    }

    private class MoveInstruction
    {
        public int From { get; set; }
        public int To { get; set; }
        public int StacksToMove { get; set; }
    }
}