using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec19;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec19";

    public void PartOne()
    {
     //   var (testRules1, testMessages1) = ParseInput("part1test1");
     //   var (testRules2, testMessages2) = ParseInput("part1test2"); 
        var (rules, messages) = ParseInput("part1");

        var msgParser = new MessageParser(rules);
        msgParser.FindPattern(0);
        Console.WriteLine( msgParser.TestMessages(messages));
        
    }

    public void PartTwo()
    {
        
    }

    private (Dictionary<int,List<string>>, List<string>) ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        var input  = reader.SplitByEmptyRow(Date, filename);

        var rules = new Dictionary<int,List<string>>();
        
        var tempRules = reader.SplitStringByDelimeterToListOfString(input[0], "\n");
        var messages = reader.SplitStringByDelimeterToListOfString(input[1], "\n");

        for (int i = 0; i < tempRules.Count; i++)
        {
            var rule = new List<string>();
            var j = tempRules[i].IndexOf(":");
            var index = int.Parse(tempRules[i].Substring(0, j));
            
            var ruleString = tempRules[i].Remove(0, j + 2);

            if (tempRules[i].Contains("a") || tempRules[i].Contains("b"))
            {
                if (tempRules[i].Contains("a")) rule.Add("a");
                if (tempRules[i].Contains("b")) rule.Add("b");
            }
            else if (!tempRules[i].Contains("|"))
            {
                rule.Add(ruleString);
            }
            else
            {
                var split = ruleString.Split("|").ToList();

                var rule1 = split[0].Remove(split[0].Length - 1,1);
                var rule2 = split[1].Remove(0, 1);
                rule.Add(rule1);
                rule.Add(rule2);
            }
            rules.Add(index, rule);
        }
        
        return (rules, messages);
    }
}