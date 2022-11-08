using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec24;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec24";

    public void PartOne()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        
        var tiles = new Tiles();
        Console.WriteLine("Part 1: Test 1: " + tiles.FlipTiles(testInput).Item1);
        Console.WriteLine("Part 1: " + tiles.FlipTiles(input).Item1);
    }

    public void PartTwo()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        
        var tiles = new Tiles();
        Console.WriteLine("Part 2: Test: "  + tiles.CountTilesAfterDays(testInput, 100) + " (2208)");
        Console.WriteLine("Part 2: "  + tiles.CountTilesAfterDays(input, 100));
    }

    private dynamic ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        var input = reader.SplitByRow(Date, filename);

        return input;
    }
}