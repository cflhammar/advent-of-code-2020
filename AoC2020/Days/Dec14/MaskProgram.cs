using System.Text;

namespace AoC2020.Days.Dec14;

public class MaskProgram
{
    public long CaluluateMemorySum(List<List<string>> input)
    {
        var memory = new Dictionary<long, long>();
        var mask = "";
        
        foreach (var command in input)
        {
            var instruction = command.First();
            var value = command.Last();
            
            if (instruction == "mask")
            {
                mask = value;
            } 
            else 
            {
                var address = long.Parse(instruction.Substring(instruction.IndexOf("[") + 1, instruction.IndexOf("]") - (instruction.IndexOf("[") + 1 )));
                var numberValue = long.Parse(value);
                var binaryValue = Convert.ToString(numberValue, 2).PadLeft(36, '0');
                var maskedValue = ApplyMask(binaryValue, mask);

                memory[address] = Convert.ToInt64(maskedValue, 2);
            }
        }

        return SumMemory(memory);
    }

    private long SumMemory(Dictionary<long, long> memory)
    {
        long sum = 0;
        
        foreach (var m in memory)
        {
            sum += m.Value;
        }

        return sum;
    }

    private string ApplyMask(string value, string mask)
    {
        string newValue = "";

        for (int i = 0; i < mask.Length; i++)
        {
            if (mask.ElementAt(i) == 'X')
            {
                newValue += value.ElementAt(i);
            }
            else
            {
                newValue += mask.ElementAt(i);
            }
        }

        return newValue;
    }
}