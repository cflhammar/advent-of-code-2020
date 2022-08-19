using System;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec06;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec06";

    public void PartOne()
    {
        var reader = new InputToStringMatrixEmptyRowAsDelimiter();
        var testInput =  reader.ReadToStringMatrix(Date, "part1test1", " ");
        var input = reader.ReadToStringMatrix(Date, "part1", " ");

        var customsCounter = new CustomsDeclarationsCounter();
        
        Console.WriteLine("Part 1: Test 1: " + customsCounter.GetSumOfAllGroups(testInput) + "  (11)");
        Console.WriteLine("Part 1: " + customsCounter.GetSumOfAllGroups(input));

    }

    public void PartTwo()
    {
        var reader = new InputToStringMatrixEmptyRowAsDelimiter();
        var testInput =  reader.ReadToStringMatrix(Date, "part1test1", " ");
        var input = reader.ReadToStringMatrix(Date, "part1", " ");

        var customsCounter = new CustomsDeclarationsCounter();
        
        Console.WriteLine("Part 2: Test 1: " + customsCounter.GetConsensusSumOfAllGroups(testInput) + "  (6)");
        Console.WriteLine("Part 2: " + customsCounter.GetConsensusSumOfAllGroups(input));
        
        
    }
}