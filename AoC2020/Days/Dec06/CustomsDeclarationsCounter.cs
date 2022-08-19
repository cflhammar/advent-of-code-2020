using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec06;

public class CustomsDeclarationsCounter
{
    public int GetSumOfAllGroups(List<List<String>> allGroups)
    {
        var sum = 0;
        foreach (var groupAnswers in allGroups)
        {
           sum += GetSum(groupAnswers);
        }

        return sum;
    }
    
    public int GetConsensusSumOfAllGroups(List<List<String>> allGroups)
    {
        var sum = 0;
        foreach (var groupAnswers in allGroups)
        {
            sum += GetConsensusSum(groupAnswers);
        }

        return sum;
    }

    public int GetSum(List<String> groupAnswers)
    {
        var allAnsers = "";
        foreach (var personAnswers in groupAnswers)
        {
            allAnsers += personAnswers;
        }

        var distinctAnswers = allAnsers.Distinct();

        return distinctAnswers.Count();
    }
    
    public int GetConsensusSum(List<String> groupAnswers)
    {
        var allAnsers = "";
        var numberPersons = groupAnswers.Count;
        var sum = 0;
        
        foreach (var personAnswers in groupAnswers)
        {
            allAnsers += personAnswers;
        }
        
        var distinctAnswers = allAnsers.Distinct();
        
        foreach (var answer in distinctAnswers)
        {
            var count = allAnsers.Count(c => c == answer);
            if (count == numberPersons) sum++;
        }

        return sum;
    }
}