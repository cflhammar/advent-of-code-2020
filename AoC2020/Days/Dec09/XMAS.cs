using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec09;

public class XMAS
{
    public long FindContagiousSet(List<long> input, long value)
    {
        for (int index = 0; index < input.Count; index++)
        {
            long sum = 0;
            for (int i = index; i < input.Count; i++)
            {
                sum += input.ElementAt(i);
                if (sum > value) break;
                if (sum == value)
                {
                    var contagiousSet = input.GetRange(index, i - index);
                    return GetEncryptionWeakness(contagiousSet);
                }
            }
        }

        return 0;
    }

    private long GetEncryptionWeakness(List<long> contagiousSet)
    {
        return contagiousSet.AsQueryable().Min() + contagiousSet.AsQueryable().Max();
    }


    public long FindInvalidNumber(List<long> input, int preamble)
    {
        for (int index = preamble; index < input.Count; index++)
        {
            var preambleList = input.GetRange(index - preamble, preamble);
            if (!NumberIsValid(preambleList, input.ElementAt(index)))
            {
                return input.ElementAt(index);
            }
        }

        return 0;
    }

    private bool NumberIsValid(List<long> preambleList, long value)
    {
        for (int i = 0; i < preambleList.Count; i++)
        {
            for (int j = 0; j < preambleList.Count; j++)
            {
                if (i != j)
                {
                    if (preambleList.ElementAt(i) + preambleList.ElementAt(j) == value)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}

