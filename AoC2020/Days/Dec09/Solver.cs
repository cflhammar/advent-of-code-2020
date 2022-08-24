using System;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec09;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec09";

    public void PartOne()
    {
        var reader = new InputToIntegerArray();
        var testInput = reader.ReadToLongArray(Date, "part1test1");
        var input = reader.ReadToLongArray(Date, "part1");

        var xmas = new XMAS();
        Console.WriteLine("Part 1: Test 1: " + xmas.FindInvalidNumber(testInput,5) , " (127)");
        Console.WriteLine("Part 1: " + xmas.FindInvalidNumber(input,25));
    }

    public void PartTwo()
    {
        var reader = new InputToIntegerArray();
        var testInput = reader.ReadToLongArray(Date, "part1test1");
        var input = reader.ReadToLongArray(Date, "part1");
        
        var xmas = new XMAS();
        
        Console.WriteLine("Part 2: Test 1: " + xmas.FindContagiousSet(testInput, xmas.FindInvalidNumber(testInput, 5)) + " (62)");
        Console.WriteLine("Part 2: " + xmas.FindContagiousSet(input, xmas.FindInvalidNumber(input, 25)));
    }
}