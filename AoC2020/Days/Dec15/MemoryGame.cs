namespace AoC2020.Days.Dec15;

public class MemoryGame
{
    
        
    public int GetValueOfPosition(int position, int[] startingNumber)
    {
        var memory = new Dictionary<int, List<int>>();
        var turn = 1;
        var spoken = 0;

        foreach (var number in startingNumber)
        {
            spoken = number;
            memory.Add(spoken,new List<int>(){turn});
            turn++;
        }

        while (turn <= position)
        {
            if (!memory.ContainsKey(spoken) || memory[spoken].Count == 1) spoken = 0;
            else spoken = Math.Abs(memory[spoken].First() - memory[spoken].Last());
            
            if (!memory.ContainsKey(spoken)) memory.Add(spoken, new List<int>(){turn});
            else
            {
                memory[spoken].Add(turn);
                if (memory[spoken].Count > 2) memory[spoken].Remove(memory[spoken].Min());
            }
            
            turn++;
        }

        return spoken;
    }
}