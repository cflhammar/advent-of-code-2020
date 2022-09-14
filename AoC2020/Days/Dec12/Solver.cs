using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec12;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec12";

    public void PartOne()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");

        var boat = new Boat();
        Console.WriteLine("Part 1: Test 1: " +  boat.GetManhattanDistance(testInput) + " (25)");
        Console.WriteLine("Part 1: " +  boat.GetManhattanDistance(input) );
    }

    public void PartTwo()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");

        var boat = new BoatAndWaypoint();
        Console.WriteLine("Part 2: Test 1: " +  boat.GetManhattanDistance(testInput) + " (286)");
        Console.WriteLine("Part 2: " +  boat.GetManhattanDistance(input) );
    }
}