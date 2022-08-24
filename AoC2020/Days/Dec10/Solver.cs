using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec10;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec10";

    public void PartOne()
    {
        var reader = new InputToNumberList();
        var testInput1 = reader.ReadToIntArray(Date, "part1test1");
        var testInput2 = reader.ReadToIntArray(Date, "part1test2");
        var input = reader.ReadToIntArray(Date, "part1");

        var jolt = new JoltCharger(testInput1);
        
        Console.WriteLine("Part 1: Test 1: "  + jolt.GetDistributionOfOneAndThreeDifferences() + " (35)");
        jolt.Input = testInput2;
        Console.WriteLine("Part 1: Test 2: "  + jolt.GetDistributionOfOneAndThreeDifferences() + " (220)");
        jolt.Input = input;
        Console.WriteLine("Part 1: "  + jolt.GetDistributionOfOneAndThreeDifferences() );
    }

    public void PartTwo()
    {
        var reader = new InputToNumberList();
        var testInput1 = reader.ReadToIntArray(Date, "part1test1");
        var testInput2 = reader.ReadToIntArray(Date, "part1test2");
        var input = reader.ReadToIntArray(Date, "part1");

        var jolt = new JoltCharger(testInput1);
        
        Console.WriteLine("Part 2: Test 1: "  + jolt.FindAllPossibleCombinations() + " (8)");
        jolt.Input = testInput2;
        Console.WriteLine("Part 2: Test 2: "  + jolt.FindAllPossibleCombinations() + " (19208)");
        jolt.Input = input;
        Console.WriteLine("Part 2: "  + jolt.FindAllPossibleCombinations() );
    }
}