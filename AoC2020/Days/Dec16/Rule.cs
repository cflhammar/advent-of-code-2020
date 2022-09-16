namespace AoC2020.Days.Dec16;

public class Rule
{
    public int[] Range1;
    public int[] Range2;
    public string Name;

    public Rule(string input)
    {
        var temp = input.Split(": ");
        Name = temp[0];
        var ranges = temp[1].Split(" or ");

        Range1 = ranges[0].Split("-").Select(x => Int32.Parse(x)).ToArray();
        Range2 = ranges[1].Split("-").Select(x => Int32.Parse(x)).ToArray();
    }

    public bool IsValid(int value)
    {
        return (value >= Range1[0] && value <= Range1[1]) || (value >= Range2[0] && value <= Range2[1]);
    }

}