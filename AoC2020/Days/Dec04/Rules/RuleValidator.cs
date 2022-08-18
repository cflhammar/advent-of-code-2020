using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec04.Rules;

public class RuleValidator
{
    public int ValidateAllPassports(List<IRule> rules,List<List<string>> passports)
    {
        var counter = 0;
        foreach (var passport in passports)
        {
            if (Validate(rules, passport)) counter++;
        }
        
        return counter;
    }
    
    public bool Validate(List<IRule> rules, List<String> passport)
    {
        var counter = 0;
        foreach (var field in passport)
        {
            if (rules.Any(x => x.Validate(field))) counter++;
        }

        return counter == rules.Count;
    }
    
    
}