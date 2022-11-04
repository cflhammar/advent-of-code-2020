namespace AoC2020.Days.Dec23;

public class CupsGameLinked
{
    private Dictionary<int, Cup> _dict = new();


    public CupsGameLinked(string input, int size = 0)
    {
        BuildList(input, size);
    }

    private void BuildList(string input, int size)
    {
        var cups = input.ToList().Select(e => Int32.Parse(e.ToString())).ToList();

        var first = new Cup()
        {
            Value = cups[0]
        };
        
        var current = first;
        _dict.Add(current.Value, current);

        for (int i = 1; i < cups.Count; i++)
        {
            var next = new Cup()
            {
                Value = cups[i],
            };

            current.Next = next;
            current = next;
            _dict.Add(current.Value,current);
        }

        if (size > 0)
        {
            var startingSize = _dict.Count;
            for (int i = startingSize + 1; i <= size; i++)
            {
                var next = new Cup()
                {
                    Value = i
                };

                current.Next = next;
                current = next;
                _dict.Add(current.Value, current);
            }
        }

        current.Next = first;
    }


    public string Play(int rounds)
    {
        var currentValue = _dict.First().Value.Value;

        for (int i = 1; i <= rounds; i++)
        {
            currentValue = NextRound(currentValue);
        }
        
        return GetSequence(); 
    }

    private int NextRound(int currentValue)
    {
        var current = _dict[currentValue];
        var pickedValues = new List<int>() {current.Next.Value, current.Next.Next.Value, current.Next.Next.Next.Value};
            
            
        var destinationValue = currentValue - 1;
        while (true)
        {
            if (destinationValue < 1) destinationValue = _dict.Count;
            if (!pickedValues.Contains(destinationValue)) break;
                
            destinationValue--;
        }

        current.Next = _dict[pickedValues.Last()].Next;
            
        var before = _dict[destinationValue];
        var after = _dict[destinationValue].Next;

        before.Next = _dict[pickedValues.First()];
        _dict[pickedValues.Last()].Next = after;

        return current.Next.Value;
    }

    private void Print(int currentValue)
    {
        var current = _dict[1];
        for (int i = 0; i <= _dict.Count; i++)
        {
            if (current.Value == currentValue) Console.WriteLine("( " + current.Value + " )");
            else Console.WriteLine(current.Value);

            current = current.Next;
        }
        Console.WriteLine("----------");
    }
    
    private string GetSequence()
    {
        var cup = _dict[1];
        var sequence = "";

        if (_dict.Count < 20)
        {
            for (int i = 0; i < _dict.Count; i++)
            {
                sequence += cup.Value + ",";
                cup = cup.Next;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                sequence += cup.Value + ",";
                cup = cup.Next;
            }

            var elements = sequence.Split(",");
            sequence += ":" + long.Parse(elements[1]) * long.Parse(elements[2]) ;

        }

        return sequence;
    }
}

