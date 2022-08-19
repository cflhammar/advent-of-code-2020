using System;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec05;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec05";

    public void PartOne()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");
        
        var bsp = new BinarySpacePartitioner();
        Console.WriteLine("Part 1: Test 1: " + bsp.FindHighestSeatValue(testInput) + " (820)");
        Console.WriteLine("Part 1: " + bsp.FindHighestSeatValue(input));
    }

    public void PartTwo()
    {
        var reader = new InputToStringArray();
        var input = reader.ReadToStringArray(Date, "part1");
        
        var bsp = new BinarySpacePartitioner();
        bsp.FindMissingSeat(input);
    }
}