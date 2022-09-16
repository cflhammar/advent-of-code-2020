using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec16;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec16";
    
    public void PartOne()
    {
        var testInput = ParseInput("part1test1");
        var input = ParseInput("part1");
        
        var ruleValidator = new RuleValidator();

        Console.WriteLine("Part 1: Test 1: "+ ruleValidator.CalculateErrorScore(testInput.Item1, testInput.Item2).Item1 + "  (71)");
        Console.WriteLine("Part 1: "+ ruleValidator.CalculateErrorScore(input.Item1, input.Item2).Item1 );

    }

    public void PartTwo()
    {
        var testInput = ParseInput("part2test1");
        var input = ParseInput("part1");
        var ruleValidator = new RuleValidator();
        
        Console.WriteLine("Part 2: Test 1: "+ ruleValidator.FindCorrectDefinition(testInput.Item1, testInput.Item2, testInput.Item3) + "  (1)");
        Console.WriteLine("Part 2: "+ ruleValidator.FindCorrectDefinition(input.Item1, input.Item2, input.Item3) );
    }

    private (List<Rule>, List<List<int>>, List<int>) ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        var a = reader.SplitByEmptyRow(Date, filename);
        var b = reader.SplitListOfStringToListListOfStringByRow(a);

        var rules = b.First().Select(x =>  new Rule(x)).ToList();

        var nta = b.ToList().ElementAt(2).Skip(1).ToList();
        var ntb = nta.Select(x => x.Split(",").ToList()).ToList();
        var nearbyTickets = ntb.Select(x=> x.Select(x => int.Parse(x)).ToList()).ToList();
        // plz send help

        var myTicket = b.ToList().ElementAt(1).Skip(1).ElementAt(0).Split(",").Select(x => Int32.Parse(x)).ToList();

        return (rules, nearbyTickets, myTicket);
    }
}