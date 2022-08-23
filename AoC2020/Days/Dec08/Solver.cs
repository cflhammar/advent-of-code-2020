using System;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec08;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec08";

    public void PartOne()
    {
        var reader = new InputToStringMatrix();
        var testInput = reader.ReadToStringMatrix(Date, "part1test1", " ");
        var input = reader.ReadToStringMatrix(Date, "part1", " ");
        
        var boot = new BootSequencer();
        
        Console.WriteLine("Part 1: Test 1: " + boot.FindRepeatedInstruction(testInput).acc + ", (5)");
        Console.WriteLine("Part 1: " + boot.FindRepeatedInstruction(input).acc);
    }

    public void PartTwo()
    {
        var reader = new InputToStringMatrix();
        var testInput = reader.ReadToStringMatrix(Date, "part1test1", " ");
        var input = reader.ReadToStringMatrix(Date, "part1", " ");
        
        var boot = new BootSequencer();
        
        Console.WriteLine("Part 2: Test 1: " + boot.TrialAndErrorInstructionFixer(testInput) + ", (8)");
        Console.WriteLine("Part 2: " + boot.TrialAndErrorInstructionFixer(input));
    }
}