using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020.Days.Dec04.Rules;
using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec04;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec04";
    public void PartOne()
    {
        var reader = new InputToStringMatrixEmptyRowAsDelimiter();
        var testInput = reader.ReadToStringMatrix(Date, "part1test1", " ");
        var input = reader.ReadToStringMatrix(Date, "part1", " ");

        var validator = new RuleValidator();
        var rules = new List<IRule>() {new Birth(), new Issue(), new Expire(), new Height(), new Hair(), new Eye(), new Passport()};
        
        Console.WriteLine("Part 1: Test 1 :" + validator.ValidateAllPassports(rules, testInput) + "  (2)");
        Console.WriteLine("Part 1: " + validator.ValidateAllPassports(rules, input));
    }

    public void PartTwo()
    {
        var reader = new InputToStringMatrixEmptyRowAsDelimiter();
        var testInput1 = reader.ReadToStringMatrix(Date, "part2test1", " ");
        var testInput2 = reader.ReadToStringMatrix(Date, "part2test2", " ");
        var input = reader.ReadToStringMatrix(Date, "part1", " ");

        var validator = new RuleValidator();
        var enforcedRules = new List<IRule>() {new EnforcedBirth(), new EnforcedIssue(), new EnforcedExpire(), new EnforcedHeight(), new EnforcedHair(), new EnforcedEye(), new EnforcedPassport()};
        
        Console.WriteLine("Part 2: Test 1 :" + validator.ValidateAllPassports(enforcedRules, testInput1) + "  (4)");
        Console.WriteLine("Part 2: Test 2 :" + validator.ValidateAllPassports(enforcedRules, testInput2) + "  (0)");
        Console.WriteLine("Part 2: " + validator.ValidateAllPassports(enforcedRules, input));

    }
}