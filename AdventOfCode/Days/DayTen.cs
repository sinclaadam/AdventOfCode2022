namespace AdventOfCode.Days;

public static class DayTen
{
    public static int SumSignalStrengths(IEnumerable<string> input)
    {
        var instructionQueue = ParseInstructions(input);
        var sum = RunInstructionSet(instructionQueue);
        
        return sum;
    }

    private static int RunInstructionSet(Queue<(Instruction instruction, int value)> instructionQueue)
    {
        var sum = 0;
        var registerX = 1;
        var instructionCompleteOnCycle = -1;
        (Instruction, int)? currentInstruction = null;
        
        for (var cycle = 0; instructionQueue.Count > 0; cycle++)
        {
            sum += CheckCycleToSum(cycle, registerX);
            if (cycle < instructionCompleteOnCycle) continue;
            
            CompleteInstruction(ref registerX, currentInstruction);
            currentInstruction = instructionQueue.Dequeue();
            instructionCompleteOnCycle = cycle + GetCyclesToComplete(currentInstruction.Value.Item1);
        }

        return sum;
    }

    private static int CheckCycleToSum(int cycle, int register)
    {
        return cycle switch
        {
            20 => cycle * register,
            60 => cycle * register,
            100 => cycle * register,
            140 => cycle * register,
            180 => cycle * register,
            220 => cycle * register,
            _ => 0
        };
    }

    private static int GetCyclesToComplete(Instruction instruction)
    {
        return instruction switch
        {
            Instruction.Addx => 2,
            Instruction.Noop => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null)
        };
    }

    private static void CompleteInstruction(ref int register, (Instruction instruction, int value)? instruction)
    {
        if (instruction == null) return;
        
        if (instruction.Value.instruction == Instruction.Addx)
        {
            register += instruction.Value.value;
        }
    }

    private static Queue<(Instruction, int)> ParseInstructions(IEnumerable<string> input)
    {
        var instructionQueue = new Queue<(Instruction, int)>();
        
        foreach (var line in input)
        {
            instructionQueue.Enqueue(ParseInstruction(line));
        }
        
        return instructionQueue;
    }

    private static (Instruction instruction, int value) ParseInstruction(string line)
    {
        if (line.StartsWith("noop")) return (Instruction.Noop, 0);

        var split = line.Split(' ');

        return (Instruction.Addx, Convert.ToInt32(split[1]));
    }
    
    private enum Instruction
    {
        Noop,
        Addx
    }
}
