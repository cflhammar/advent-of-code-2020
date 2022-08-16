using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec01;

public class ExpenseReport
{
    public int FindProductOfTwo(int sum, List<int> input )
    {
        for (int i = 0; i < input.Count; i++)
        {
            for (int k = i + 1; k < input.Count; k++)
            {
                if (input.ElementAt(i) + input.ElementAt(k) == sum)
                {
                    return input.ElementAt(i) * input.ElementAt(k);
                }
            }
        }

        return 0;
    }
    
    public int FindProductOfThree(int sum, List<int> input )
    {
        for (int i = 0; i < input.Count; i++)
        {
            for (int k = i + 1; k < input.Count; k++)
            {
                for (int j = k + 1; j < input.Count; j++)
                {
                    if (input.ElementAt(i) + input.ElementAt(k) + input.ElementAt(j) == sum)
                    {
                        return input.ElementAt(i) * input.ElementAt(k) * input.ElementAt(j);
                    }
                }
            }
        }

        return 0;
    }

    
}