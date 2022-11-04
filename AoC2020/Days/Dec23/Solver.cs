using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec23;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec23";

    public void PartOne()
    {
        var testInput = "389125467";
        var input = "871369452";

        var cupGame = new CupsGameLinked(testInput);
        Console.WriteLine("Part 1: Test 1: " + cupGame.Play(10) + " (92658374)");
        cupGame = new CupsGameLinked(testInput);
        Console.WriteLine("Part 1: Test 2: " + cupGame.Play(100) + " (67384529)");
        cupGame = new CupsGameLinked(input);
        Console.WriteLine("Part 1: " + cupGame.Play(100));
    }

    public void PartTwo()
    {
        var testInput = "389125467";
        var input = "871369452";

        var cupGame = new CupsGameLinked(testInput,1000000);
        Console.WriteLine( cupGame.Play(10000000));
        
        cupGame = new CupsGameLinked(input,1000000);
        Console.WriteLine( cupGame.Play(10000000));
    }

    private dynamic ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        
        return true;
    }
}