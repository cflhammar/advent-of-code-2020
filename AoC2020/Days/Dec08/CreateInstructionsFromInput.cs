using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec08;

public class CreateInstructionsFromInput
{
    public List<Instruction> ConvertInput(List<List<string>> input)
    {
        List<Instruction> instructions = new List<Instruction>();
        
        foreach (var inputInstruction in input)
        {
            instructions.Add(new Instruction()
            {
                Operation = inputInstruction.First(),
                Steps = int.Parse(inputInstruction.ElementAt(1))
            });
        }

        return instructions;
    }
}