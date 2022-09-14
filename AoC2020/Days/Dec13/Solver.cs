using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec13;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec13";

    public void PartOne()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");

        var bs = new BusSchedule();
        Console.WriteLine("Part 1: Test 1: " + bs.FindEarliestBus(testInput.First(), testInput.Last()) + ",  (295)" );
        Console.WriteLine("Part 1: " + bs.FindEarliestBus(input.First(), input.Last()));
    }

    public void PartTwo()
    {
        var reader = new InputToStringArray();
        var exampleInput = reader.ReadToStringArray(Date, "part2example");
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var testInput1 = reader.ReadToStringArray(Date, "part2test1");
        var testInput2 = reader.ReadToStringArray(Date, "part2test2");
        var testInput3 = reader.ReadToStringArray(Date, "part2test3");
        var testInput4 = reader.ReadToStringArray(Date, "part2test4");
        var testInput5 = reader.ReadToStringArray(Date, "part2test5");
        var input = reader.ReadToStringArray(Date, "part1");

        var bs = new BusSchedule();
        
        Console.WriteLine("Part 2: YT example: " + bs.FindTimeOfAlignedBuses(exampleInput.Last()) + ",  (867)" );
        Console.WriteLine("Part 2: Test 1: " + bs.FindTimeOfAlignedBuses(testInput.Last()) + ",  (1068781)" );
        Console.WriteLine("Part 2: Example 1: " + bs.FindTimeOfAlignedBuses(testInput1.Last()) + ",  (3417)" );
        Console.WriteLine("Part 2: Example 2: " + bs.FindTimeOfAlignedBuses(testInput2.Last()) + ",  (754018)" );
        Console.WriteLine("Part 2: Example 3: " + bs.FindTimeOfAlignedBuses(testInput3.Last()) + ",  (779210)" );
        Console.WriteLine("Part 2: Example 4: " + bs.FindTimeOfAlignedBuses(testInput4.Last()) + ",  (1261476)" );
        Console.WriteLine("Part 2: Example 5: " + bs.FindTimeOfAlignedBuses(testInput5.Last()) + ",  (1202161486)" );
        Console.WriteLine("Part 2: " + bs.FindTimeOfAlignedBuses(input.Last()));
       
        
    }
}