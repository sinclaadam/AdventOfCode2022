using System.Text;

namespace AdventOfCode.Days;

public static class DayTen
{
    private const int CrtPixelsPerRow = 40;
    public static int SumSignalStrengths(IEnumerable<string> input)
    {
        var instructionQueue = ParseInstructions(input);
        var sum = RunInstructionSet(instructionQueue);
        
        return sum;
    }
    
    public static string DrawPicture(IEnumerable<string> input)
    {
        var instructionQueue = ParseInstructions(input);
        var picture = DrawInstructionSet(instructionQueue);
        return picture;
    }
    
    private static string DrawInstructionSet(Queue<(Instruction instruction, int value)> instructionQueue)
    {
        var registerX = 1;
        var picture = new StringBuilder();
        var instructionCompleteOnCycle = -1;
        
        (Instruction instruction, int value)? currentInstruction = null;
        
        for (var cycle = 1;  cycle <= 240; cycle++)
        {
            if (currentInstruction is null)
            {
                currentInstruction = instructionQueue.Dequeue();
                instructionCompleteOnCycle = cycle + GetCyclesToComplete(currentInstruction.Value.instruction) - 1;
            }
            
            picture.Append(CheckPixelDrawn(registerX, cycle));
            if (cycle % CrtPixelsPerRow == 0) picture.AppendLine();

            if (cycle == instructionCompleteOnCycle)
            {
                CompleteInstruction(ref registerX, ref currentInstruction);
            }
        }

        return picture.ToString();
    }

    private static string CheckPixelDrawn(int register, int cycle)
    {
        var pixel = cycle - 1;
        pixel %= CrtPixelsPerRow;
        
        if (register <= pixel + 1 && register >= pixel - 1) return "#";
        return ".";
    }

    private static int RunInstructionSet(Queue<(Instruction instruction, int value)> instructionQueue)
    {
        var sum = 0;
        var registerX = 1;
        var instructionCompleteOnCycle = -1;
        (Instruction, int)? currentInstruction = null;
        
        for (var cycle = 1; cycle <= 240; cycle++)
        {
            if (currentInstruction is null)
            {
                currentInstruction = instructionQueue.Dequeue();
                instructionCompleteOnCycle = cycle + GetCyclesToComplete(currentInstruction.Value.Item1) - 1;
            }
            
            sum += CheckCycleToSum(cycle, registerX);

            if (cycle == instructionCompleteOnCycle)
            {
                CompleteInstruction(ref registerX, ref currentInstruction);
            }
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

    private static void CompleteInstruction(ref int register, ref (Instruction instruction, int value)? instruction)
    {
        if (instruction == null) return;
        
        if (instruction.Value.instruction == Instruction.Addx)
        {
            register += instruction.Value.value;
        }

        instruction = null;
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
