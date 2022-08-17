using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec02;

public class PasswordValidator
{
    public List<int> Validate(List<List<String>> combinations)
    {
        int numberValidMinMax = 0;
        int numberValidPosition = 0;
        
        foreach (var combination in combinations)
        {
            var minMax = combination.ElementAt(0).Split("-").ToList();
            var min = int.Parse(minMax.ElementAt(0));
            var max = int.Parse(minMax.ElementAt(1));
            var c = combination.ElementAt(1).ElementAt(0);
            var pw = combination.ElementAt(2);

            if (CheckPasswordIsValidMinMax(min, max, c, pw)) numberValidMinMax++;
            if (CheckPasswordIsValidPosition(min, max, c, pw)) numberValidPosition++;
        }

        return new List<int>(){numberValidMinMax, numberValidPosition};
    }

    private bool CheckPasswordIsValidMinMax(int min, int max, char c, string password)
    {
        var counter = 0;
        foreach (var pwChar in password)
        {
            if (pwChar == c) counter++;
        }

        if (counter >= min && counter <= max) return true;
        return false;
    }
    
    private bool CheckPasswordIsValidPosition(int min, int max, char c, string pw)
    {
        var counter = 0;
        if (pw.ElementAt(min-1) == c) counter++;
        if (pw.ElementAt(max-1) == c) counter++;

        return counter == 1;
    }
    
}