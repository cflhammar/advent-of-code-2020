namespace AoC2020.Days.Dec23;

public class CupsGame
{

    public string Play(string input, int rounds)
    {
        var cups = input.ToList().Select(e => Int32.Parse(e.ToString())).ToList();
        var currentValue = cups[0];

        for (int i = 1; i <= rounds; i++)
        {
            cups = NextRound(cups, currentValue);
            var currentPos = cups.IndexOf(currentValue);
            var nextValue = cups[(currentPos + 1) % cups.Count];
            currentValue = nextValue;
        }

        return GetSequence(cups);

    }

    private List<int> NextRound(List<int> cups, int currentValue)
    {

        var currentPos = cups.IndexOf(currentValue);
        var takeThree = TakeThreeCups(cups, currentPos);

        var three = takeThree.Item1;
        cups = takeThree.Item2;

        var destinationPos = -1;
        var destinationValue = currentValue - 1;
        
        while (destinationPos < 0)
        {
            if (destinationValue < 1) destinationValue = cups.Max();
            destinationPos = cups.IndexOf(destinationValue);
            if (destinationPos < 0) destinationValue--;
        }

        three.Reverse();
        three.ForEach(e => cups.Insert(destinationPos + 1, e));
        
        
        return cups;
    }


    public (List<int>, List<int>) TakeThreeCups(List<int> cups, int currentPos)
    {
        var threeCups = new List<int>();

        for (var i = 0; i < 3; i++)
        {
            threeCups.Add(cups[(currentPos + i + 1) % cups.Count]);
        }
        
        threeCups.ForEach(e => cups.Remove(e));

        return (threeCups, cups);
    }
    
    private string GetSequence(List<int> cups)
    {
        var start = cups.IndexOf(1);
        var sequence = "";
        
        for (int i = 0; i < cups.Count; i++)
        {
            sequence += cups[(start + i) % cups.Count].ToString();
        }

        return sequence.Replace("1","");
    }
}

