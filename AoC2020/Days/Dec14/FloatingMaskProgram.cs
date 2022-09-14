using System.Text;

namespace AoC2020.Days.Dec14;

public class FloatingMaskProgram
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
                var address = long.Parse(instruction.Substring(instruction.IndexOf("[") + 1,
                    instruction.IndexOf("]") - (instruction.IndexOf("[") + 1)));
                var binaryAddress = Convert.ToString(address, 2).PadLeft(36, '0');
                var maskedValue = ApplyMask(binaryAddress, mask);

                var addresses = GetFloatingAddresses(maskedValue);

                foreach (var floatingAddress in addresses)
                {
                    var decimalAddress = Convert.ToInt64(floatingAddress, 2);
                    memory[decimalAddress] = long.Parse(value);
                }

            }
        }

        return SumMemory(memory);
    }

    public List<string> GetFloatingAddresses(string address)
    {
        List<string> allAddresses = new List<string>();

        allAddresses.AddRange(GetCombinations(address));

        return allAddresses;
    }

    private List<string> GetCombinations(string address)
    {
        if (!address.Contains("X")) return new List<string>() {address};

        var index = address.IndexOf("X");
        StringBuilder a = new StringBuilder(address);
        StringBuilder b = new StringBuilder(address);
        a[index] = '1';
        b[index] = '0';

        List<string> addresses = new List<string>();
        addresses.AddRange(GetCombinations(a.ToString()));
        addresses.AddRange(GetCombinations(b.ToString()));

        return addresses;
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
                newValue += 'X';
            }
            else if (mask.ElementAt(i) == '0')
            {
                newValue += value.ElementAt(i);
            }
            else
            {
                newValue += '1';
            }
        }

        return newValue;
    }
}