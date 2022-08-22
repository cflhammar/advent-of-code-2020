using System;
using System.Collections.Generic;

namespace AoC2020.Days.Dec07;

public class BagRuleInterpreter
{
    public List<Bag?> ConvertRules(List<String> rules)
    {
        var bagRules = new List<Bag?>();
        
        foreach (var rule in rules)
        {
            var convertedRule = ConvertRule(rule);

            var bag = new Bag()
            {
                BagColor = convertedRule.bag
            };
            
            var temp = new Dictionary<Bag, int>();

            foreach (var containedBag in convertedRule.contains)
            {
                if (containedBag[0] != "no")
                {
                    var bagInside = new Bag()
                    {
                        BagColor = containedBag[1]
                    };
                    var number = int.Parse(containedBag[0]);
                
                    temp.Add(bagInside,number);

                    bag.Contains = temp;

                }
            }
            bagRules.Add(bag);
        }

        return bagRules;
    }
    
    
    public (string bag, List<List<String>> contains) ConvertRule(string rule)
    {
        var splitRule = rule.Split(" bags contain ");
        var containsTemp = splitRule[1].Split(", ");

        var contains = new List<List<String>>();
        foreach (var containRule in containsTemp)
        {
            var words = containRule.Split(" ");
            
            

            contains.Add(new List<string>()
            {
                words[0], 
                words[1] + " " + words[2]
            });
            
        }

        return (splitRule[0], contains);
    }
}