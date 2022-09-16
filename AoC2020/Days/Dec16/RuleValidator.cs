namespace AoC2020.Days.Dec16;

public class RuleValidator
{
    public long FindCorrectDefinition(List<Rule> rules, List<List<int>> nearbyTickets, List<int> myTicket)
    {
        var validTickets = CalculateErrorScore(rules, nearbyTickets).Item2;

        var memory = new Dictionary<int, List<string>>();
        
        for (int i = 0; i < validTickets.First().Count; i++)
        {
            var valuesAtPosition = validTickets.Select(x => x[i]);
            var matchingRules = rules.Where(rule => valuesAtPosition.All(value => rule.IsValid(value)));

            memory[i] = new List<string>(matchingRules.Select(x => x.Name));
        }

        var result = MapRuleToOrderOfValues(memory);
        
        return GetSumOfDestionationRules(result, myTicket);
    }

    private long GetSumOfDestionationRules(Dictionary<int, string> mappedRules, List<int> myTicket)
    {
        long prod = 1;

        for (int i = 0; i < mappedRules.Count; i++)
        {
            var type = mappedRules[i];
            if (type.StartsWith("departure")) prod *= myTicket[i];
        }

        return prod;
    }
    
    private Dictionary<int, string> MapRuleToOrderOfValues(Dictionary<int, List<string>> memory)
    {
        var result = new Dictionary<int, string>();
        
        while (memory.Count > 0)
        {
            var assignableRule = memory.First(x => x.Value.Count == 1);
            result.Add(assignableRule.Key, assignableRule.Value.First());
            memory.Remove(assignableRule.Key);
            
            foreach (var (key, value) in memory)
            {
                if (value.Contains(assignableRule.Value.First())) memory[key].Remove(assignableRule.Value.First());
            }
        }

        return result;
    }
    
    
    public (int, List<List<int>>) CalculateErrorScore(IEnumerable<Rule> rules, List<List<int>> nearbyTickets)
    {
        var errorSum = 0;
        var validTickets = new List<List<int>>();

        foreach (var ticket in nearbyTickets)
        {
            var ticketIsValid = true;
            foreach (var value in ticket)
            {
                if (!CheckRules(rules, value))
                {
                    errorSum += value;
                    ticketIsValid = false;
                };
            }
            
            if (ticketIsValid) validTickets.Add(ticket);
        }

        return (errorSum, validTickets);
    }

    public bool CheckRules(IEnumerable<Rule> rules, int value)
    {
        return rules.Any(rule => rule.IsValid(value));
    }
}