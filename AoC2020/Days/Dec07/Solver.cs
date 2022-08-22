using System;
using System.Collections.Generic;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec07;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec07";

    public void PartOne()
    {
        var reader = new InputToStringArray();
        var testInput = reader.ReadToStringArray(Date, "part1test1");
        var input = reader.ReadToStringArray(Date, "part1");
        
        var ruleInterpreter = new BagRuleInterpreter();
        
        var rules = ruleInterpreter.ConvertRules(testInput);
        var bagCalculator = new BagCalculator(rules);
        var sum = bagCalculator.FindNumberOfOuterBagsFor("shiny gold");

        Console.WriteLine("Part 1: Test 1: " + sum + ",  (4)");
        
        
        rules = ruleInterpreter.ConvertRules(input);
        bagCalculator.Rules = rules;
        sum = bagCalculator.FindNumberOfOuterBagsFor("shiny gold");
        
        Console.WriteLine("Part 1: " + sum);
    }

    public void PartTwo()
    {
        var reader = new InputToStringArray();
        var testInput1 = reader.ReadToStringArray(Date, "part1test1");
        var testInput2 = reader.ReadToStringArray(Date, "part2test1");
        var input = reader.ReadToStringArray(Date, "part1");
        
        var ruleInterpreter = new BagRuleInterpreter();
        
        var rules = ruleInterpreter.ConvertRules(testInput1);
        var bagCalculator = new BagCalculator(rules);

        var sum = bagCalculator.FindNumberOfInnerBagsIn("shiny gold");
        Console.WriteLine("Part 2: Test 1: " + sum + ",  (32)");
        
        rules = ruleInterpreter.ConvertRules(testInput2);
        bagCalculator.Rules = rules;

        sum = bagCalculator.FindNumberOfInnerBagsIn("shiny gold");
        Console.WriteLine("Part 2: Test 2: " + sum + ",  (126)");
        
        rules = ruleInterpreter.ConvertRules(input);
        bagCalculator.Rules = rules;
        sum = bagCalculator.FindNumberOfInnerBagsIn("shiny gold");
        
        Console.WriteLine("Part 2: " + sum);
    }
}