using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec18;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec18";

    public void PartOne()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        var calc = new Calculator();

        int index = 0;
        List<int> testResults = new List<int>{71,51,26,437,12240,13632 };
        foreach (var result in testResults)
        {
            Console.WriteLine($"Part 1: Test {index+1}: " + calc.SolveEquation(testInput[index]) + $" ({result})");
            index++;
        }
        
        Console.WriteLine("Part 1: " + calc.SummarizeEquations(input, false));
        
    }

    public void PartTwo()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        
        var calc = new Calculator();
        
        int index = 0;
        List<int> testResults = new List<int>{231,51,46,1445,669060,23340 };
        foreach (var result in testResults)
        {
            Console.WriteLine($"Part 2: Test {index + 1}: " + calc.SolveEquation( calc.FixPredesence(testInput[index])) + $" ({result})");
            index++;
        }
        
        Console.WriteLine("Part 2: " + calc.SummarizeEquations(input, true));
        
    }
    
    private List<List<char>> ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        var rows = reader.SplitByRow(Date, filename);
        rows = reader.RemoveAllInstancesOfChar(rows, " ");
        var input = reader.SplitStringListByNoDelimiterToCharListList(rows);

        return input;
    }
}