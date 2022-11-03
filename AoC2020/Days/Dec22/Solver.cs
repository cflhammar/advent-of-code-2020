using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec22;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec22";

    public void PartOne()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        
       var game = new CombatGame();
       var result = game.PlayGame(testInput.Item1, testInput.Item2);
       Console.WriteLine("Part 1: Test 1: " + game.CalculateScore(result)+ " (306)");

       result = game.PlayGame(input.Item1, input.Item2); 
       Console.WriteLine("Part 1: " + game.CalculateScore(result));
    }

    public void PartTwo()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        
        var game = new RecursiveCombatGame();
        var result = game.PlayGame(testInput.Item1, testInput.Item2);
        Console.WriteLine("Part 2: Test 1: " + game.CalculateScore(result) + " (291)");

        game = new RecursiveCombatGame(); 
        result = game.PlayGame(input.Item1, input.Item2);
        Console.WriteLine("Part 2: " + game.CalculateScore(result));
    }

    private (Queue<int>, Queue<int>) ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        var temp = reader.SplitByEmptyRow(Date, filename).Select(e => e.Split("\n").ToList()).ToList();

        var player1 = new Queue<int>();
        var player2 = new Queue<int>();
        
        for (int i = 1; i < temp[0].Count; i++)
        {
            player1.Enqueue(Int32.Parse(temp[0][i]));
            player2.Enqueue(Int32.Parse(temp[1][i]));
        }
        
        
        return (player1, player2);

    }
}