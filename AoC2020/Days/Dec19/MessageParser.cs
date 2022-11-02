using System.Text.RegularExpressions;

namespace AoC2020.Days.Dec19;

public class MessageParser
{
    private Dictionary<int, List<string>> _rules;
    private string _pattern = "";

    public MessageParser(Dictionary<int,List<string>> rules)
    {
        _rules = rules;
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