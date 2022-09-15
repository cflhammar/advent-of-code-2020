namespace AoC2020.Days.Dec15;

public class Solver : IDaySolver
{
    public string Date { get; } = "";

    public void PartOne()
    {
        var memGame = new MemoryGame();
        Console.WriteLine("Part 1: Test 1: "+ memGame.GetValueOfPosition(2020, new int[]{0,3,6}) + "(436)");
       Console.WriteLine("Part 1: "+ memGame.GetValueOfPosition(2020, new int[]{0,14,1,3,7,9}));
    }

    public void PartTwo()
    {
        var memGame = new MemoryGame();
        Console.WriteLine("Part 2: Test 1: "+ memGame.GetValueOfPosition(30000000, new int[]{0,3,6}) + "(175594)");
        Console.WriteLine("Part 2: "+ memGame.GetValueOfPosition(30000000, new int[]{0,14,1,3,7,9}));
        
    }
}