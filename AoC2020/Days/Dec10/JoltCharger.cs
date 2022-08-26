namespace AoC2020.Days.Dec10;

public class JoltCharger
{

    public List<int> Input;
    private Dictionary<long, long> Memory;

    public JoltCharger(List<int> input)
    {
        Input = input;
    }

    private void SortAndArrangeInput()
    {
        Input.Sort();
        Input.Insert(0,0);
        Input.Add(Input.Max() + 3);
        Memory = new Dictionary<long, long>();
    }

    public long GetDistributionOfOneAndThreeDifferences()
    {
        SortAndArrangeInput();
        int[] distribuition = new int[4];

        for (int index = 0; index < Input.Count - 1; index++)
        {
            var diff = Input.ElementAt(index + 1 ) - Input.ElementAt(index);
            distribuition[diff]++;
        }
        
        return distribuition[1] * distribuition[3];
    }


    public long FindAllPossibleCombinations()
    { 
        SortAndArrangeInput(); 
        return FindValidWays();
    }

    private long FindValidWays(int index = 0)
    {
        if (Memory.ContainsKey(index))
        {
            return Memory[index];
        }
        
        if (index == Input.Count-1) return 1;

        long sum = 0;

        for (int i = 1; i <= 3; i++)
        {
            if ( index + i < Input.Count &&  (Input.ElementAt(index + i) - Input.ElementAt(index) <= 3))
            {
                sum +=  FindValidWays(index + i);
            }     
        }

        Memory[index] = sum;
        return sum;
    }
}

