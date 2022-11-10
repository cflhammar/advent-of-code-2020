using System.Text.RegularExpressions;

namespace AoC2020.Days.Dec19;

public class LoopedMessageParser
{
    private Dictionary<int, List<string>> _rules;
    private string _pattern = "";

    public LoopedMessageParser(Dictionary<int,List<string>> rules)
    {
        _rules = rules;
    }

    public int PartTwo(List<string> messages)
    {
        FindPattern(42);
        var fourTwo = "(?<fourTwo>" + _pattern+ ")+";
        _pattern = "";
        FindPattern(31);
        var threeOne = "(?<threeOne>" + _pattern + ")+";

        var pattern = "^" + fourTwo + threeOne + "$";
        // 42 (1+x) + 42 (n) + 31 (n)     (n > 0)

        var sum = 0;

        foreach (var message in messages)
        {
            var result = Regex.Match(message, pattern);
            if (result.Success)
            {
                var fourTwoMatches = result.Groups["fourTwo"].Captures.Count;
                var threeOneMatches = result.Groups["threeOne"].Captures.Count;

                if (fourTwoMatches > threeOneMatches && threeOneMatches > 0) sum++;

            }
        }

        return sum;
    }
    
    
    public void FindPattern(int pos)
    {
        var rule = _rules[pos];

        if (rule.Count == 1)
        {
            if (rule[0].Contains("a")) _pattern += "a";
            else if (rule[0].Contains("b")) _pattern += "b";
            else
            {
                var paths = rule[0].Split(" ").ToList();

                foreach (var path in paths)
                {
                    FindPattern(int.Parse(path.ToString()));
                }
            }
        }
        else
        {
            _pattern += "(";
            var paths1 = rule[0].Split(" ").ToList();
            var paths2 = rule[1].Split(" ").ToList();
            
            foreach (var path in paths1)
            {
                FindPattern(int.Parse(path.ToString()));
            }
            _pattern += "|";
            
            foreach (var path in paths2)
            {
                FindPattern(int.Parse(path.ToString()));
            }
            
            _pattern += ")";
        }
    }

    public long TestMessages(List<string> messages)
    {
        _pattern = "^" + _pattern + "$";
        long sum = 0;
        foreach (var message in messages)
        {
            if (Regex.Match(message,_pattern).Success)
            {
                sum++;
            };
        }

        return sum;
    }
}