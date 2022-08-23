using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec08;

public class BootSequencer
{

    public int TrialAndErrorInstructionFixer(List<List<string>> input)
    {
        var instructions = ConvertInputToInstructions(input);

        for (int index = 0; index < instructions.Count; index++)
        {
            switch (instructions.ElementAt(index).Operation)
            {
                case "jmp":
                    instructions.ElementAt(index).Operation =  "nop";
                    var (acc, finished) = FindRepeatedInstruction(instructions);

                    if (finished) return acc;

                    instructions.ElementAt(index).Operation = "jmp";
                    instructions = ResetVisited(instructions);
                    break;
                
                case "nop":
                    instructions.ElementAt(index).Operation =  "jmp";
                    (acc, finished) = FindRepeatedInstruction(instructions);

                    if (finished) return acc;

                    instructions.ElementAt(index).Operation = "nop";
                    instructions = ResetVisited(instructions);
                    break;
            }
        }

        return 0;
    }


    public (int acc, bool finished) FindRepeatedInstruction(List<Instruction> instructions)
    {
        bool finished = true;
        int accumulator = 0;
        for (int index = 0; index < instructions.Count; index++)
        {

            instructions.ElementAt(index).Visited++;
            var instruction = instructions.ElementAt(index);

            if (instruction.Visited > 1)
            {
                finished = false;
                break;
            }
            
            switch (instruction.Operation)
            {
                case "acc":
                    accumulator += instruction.Steps;
                    break;
                case "jmp":
                    index += instruction.Steps - 1;
                    break;
                case "nop":
                    break;
            }
        }
        return (accumulator, finished);
    }
    
    
    public (int acc, bool finished) FindRepeatedInstruction(List<List<string>> input)
    {
        var instructions = ConvertInputToInstructions(input);
        return FindRepeatedInstruction(instructions);
    }

    private List<Instruction> ConvertInputToInstructions(List<List<string>> input)
    {
        var converter = new CreateInstructionsFromInput();
        var instructions = converter.ConvertInput(input);

        return instructions;
    }
    
    private List<Instruction> ResetVisited(List<Instruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            instruction.Visited = 0;
        }

        return instructions;
    }
}