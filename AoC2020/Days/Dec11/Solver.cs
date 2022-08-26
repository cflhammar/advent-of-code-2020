using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec11;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec11";

    public void PartOne()
    {
        var reader = new InputToStringArray();
        var testinput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");
        
        var waitingArea = new WaitingArea(testinput);
        Console.WriteLine("Part 1: Test 1: "+ waitingArea.FindEquilibrium()+  " (37)");
        
        waitingArea = new WaitingArea(input);
        Console.WriteLine("Part 1: " + waitingArea.FindEquilibrium());
        
    }

    public void PartTwo()
    {
        var reader = new InputToStringArray();
        var testinput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");
        
        var waitingArea = new WaitingArea(testinput);
        waitingArea.PartTwo = true;
        Console.WriteLine("Part 2: Test 1: "+ waitingArea.FindEquilibrium()+  " (26)");
        
        waitingArea = new WaitingArea(input);
        waitingArea.PartTwo = true;
        Console.WriteLine("Part 2: " + waitingArea.FindEquilibrium());
        
    }
}