using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec20;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec20";

    public void PartOne()
    {
        /*
        var testInput = ParseInput("part1test1");
        var img = new ImageAnalyzer(testInput);
        img.PlaceTiles();
        Console.WriteLine("Part 1: Test 1: " + img.GetSumOfCorners() + " (20899048083289)");
        img.CombineTilesInBoardToResult();
        Console.WriteLine("Part 2: Test 1: " + img.GetHabitatRoughness() + " (273)");
        */

        var input = ParseInput("part1");
        var img = new ImageAnalyzer(input); 
        img.PlaceTiles();
        Console.WriteLine("Part 1: " + img.GetSumOfCorners() );
        img.CombineTilesInBoardToResult();
        Console.WriteLine("Part 2: " + img.GetHabitatRoughness() );


    }

    public void PartTwo()
    {
        
    }

    private dynamic ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        return reader.SplitByEmptyRow(Date, filename);
    }
}