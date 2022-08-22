using System;
using System.Collections.Generic;

namespace AoC2020.Days.Dec07;

public class BagCalculator
{
    public List<Bag?> Rules { get; set; }

    public BagCalculator(List<Bag?> rules)
    {
        Rules = rules;
    }
   
    
    public int FindNumberOfOuterBagsFor(string color)
    {
        var sum = 0;
        foreach (var rule in Rules)
        {
            if (rule?.BagColor != color)
            {
                sum += ContainsBagOfColor(color, rule);
            }
        }

        return sum;
    }

    public int ContainsBagOfColor(string color, Bag? bag)
    {
        if (bag?.BagColor == color) return 1;
        if (bag?.Contains == null) return 0;
        
        var sum = 0;
        foreach (var bagInside in bag.Contains)
        {
            var bagInRuleSet = Rules.Find(x => x?.BagColor == bagInside.Key.BagColor);
            sum += ContainsBagOfColor(color, bagInRuleSet);

            if (sum > 0) break;
        }
            
        return Math.Min(1, sum);

    }
    
     
    public int FindNumberOfInnerBagsIn(string color)
    {
        var sum = 0;
        foreach (var bag in Rules)
        {
            if (bag?.BagColor == color)
            {
                sum += ContainNumberOfBags(bag);
            }
        }
        
        return sum - 1;
    }

    private int ContainNumberOfBags(Bag? bag)
    {
        if (bag?.Contains == null) return 1;
        
        var sum = 1;
        
        foreach (var (bagColor, qty) in bag.Contains)
        {
            var bagInRuleSet = Rules.Find(x => x?.BagColor == bagColor.BagColor);
            sum += qty * ContainNumberOfBags(bagInRuleSet);
        }

        return sum;

    }
}