using System;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec01;

public class Solver
{
    public void PartOne()
    {
        InputToIntegerArray reader = new InputToIntegerArray();
        var testInput1 = reader.ReadToIntArray("Dec01","part1test1");
        var input = reader.ReadToIntArray("Dec01","part1");
        
        ExpenseReport er = new ExpenseReport();

        Console.WriteLine("Part 1: Test 1 (514579):" + er.FindProductOfTwo(2020, testInput1));
        Console.WriteLine("Part 1: "+ er.FindProductOfTwo(2020, input));
    }

    public void PartTwo()
    {
        InputToIntegerArray reader = new InputToIntegerArray();
        var testInput1 = reader.ReadToIntArray("Dec01","part1test1");
        var input = reader.ReadToIntArray("Dec01","part1");
        
        ExpenseReport er = new ExpenseReport();

        Console.WriteLine("Part 1: Test 1 (241861950):" + er.FindProductOfThree(2020, testInput1));
        Console.WriteLine("Part 1: "+ er.FindProductOfThree(2020, input));
    }
}