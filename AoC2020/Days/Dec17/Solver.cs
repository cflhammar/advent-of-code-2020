using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec17;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec17";
    
    public void PartOne()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");

        var pocketSpace = new ThreeDimPocketSpace(testInput);
        Console.WriteLine("Part 1: Test 1: "+ pocketSpace.SimulateSteps(6) + " (112)");
        
        pocketSpace = new (input);
        Console.WriteLine("Part 1: "+ pocketSpace.SimulateSteps(6));

    }

    public void PartTwo()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        
        var pocketSpace = new FourDimPocketSpace(testInput);
        Console.WriteLine("Part 2: Test 1: "+ pocketSpace.SimulateSteps(6));
        
        pocketSpace = new (input);
        Console.WriteLine("Part 2: "+ pocketSpace.SimulateSteps(6));
        
    }

    private List<List<char>> ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        var temp = reader.SplitByRow(Date, filename);
        return reader.SplitStringListByNoDelimiterToCharListList(temp);
    }
    
}