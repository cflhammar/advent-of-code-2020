using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec14;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec14";

    public void PartOne()
    {
        var reader = new InputToStringMatrix();
        var testInput = reader.ReadToStringMatrix(Date, "part1test1", " = ");
        var input = reader.ReadToStringMatrix(Date, "part1", " = ");

        var maskProg = new MaskProgram(); 
        
        Console.WriteLine("Part 1: Test 1: " +  maskProg.CaluluateMemorySum(testInput));
        Console.WriteLine("Part 1: " +  maskProg.CaluluateMemorySum(input));
    }

    public void PartTwo()
    {
        var reader = new InputToStringMatrix();
        var testInput = reader.ReadToStringMatrix(Date, "part2test1", " = ");
        var input = reader.ReadToStringMatrix(Date, "part1", " = ");
        
        var maskProg = new FloatingMaskProgram();
        
        Console.WriteLine("Part 2: Test 1: " +  maskProg.CaluluateMemorySum(testInput));
        Console.WriteLine("Part 2: " +  maskProg.CaluluateMemorySum(input));
    }
}