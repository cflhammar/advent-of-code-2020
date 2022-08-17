using System;
using System.Linq;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec02;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec02";

    public void PartOne()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringMatrix(Date, "part1test1", " ");
        var input = reader.ReadToStringMatrix(Date, "part1", " ");
        
        var pwValidator = new PasswordValidator();

        var testResults = pwValidator.Validate(testInput);
        Console.WriteLine("Part 1: Test 1: " + testResults.ElementAt(0) + " (2)");
        Console.WriteLine("Part 2: Test 1: " + testResults.ElementAt(1) + " (1)");
        
        var results = pwValidator.Validate(input);
        Console.WriteLine("Part 1: " + results.ElementAt(0));
        Console.WriteLine("Part 2: " + results.ElementAt(1));
    }

    public void PartTwo()
    {
        Console.WriteLine("Part 2:...");
    }
}