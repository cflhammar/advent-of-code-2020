using System;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec03;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec03";
    public void PartOne()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");
        
        var toboggan = new Toboggan();
        Console.WriteLine("Part1: Test1: " +  toboggan.Travel(testInput, 3, 1 ));
        Console.WriteLine("Part1:" +  toboggan.Travel(input, 3, 1 ));
    }

    public void PartTwo()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");
        
        var toboggan = new Toboggan();
        Console.WriteLine("Part2: Test1: " +  toboggan.Travel(testInput, 1, 1)
            * toboggan.Travel(testInput, 3, 1)
            * toboggan.Travel(testInput, 5, 1)
            * toboggan.Travel(testInput, 7, 1)
            * toboggan.Travel(testInput, 1, 2));

        Console.WriteLine("Part2: " + toboggan.Travel(input, 1, 1) 
            * toboggan.Travel(input, 3, 1) 
            * toboggan.Travel(input, 5, 1) 
            * toboggan.Travel(input, 7, 1) 
            * toboggan.Travel(input, 1, 2));
    }
}