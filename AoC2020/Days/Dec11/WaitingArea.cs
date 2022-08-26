namespace AoC2020.Days.Dec11;

public class WaitingArea
{
    private List<string> _input; 
    public List<List<Seat>> WaitingAreaSeats = new ();
    public bool PartTwo = false;


    public WaitingArea(List<string> input)
    {
        _input = input;
        CreateWaitingAreaFromInput();
    }
    
    
    public int FindEquilibrium()
    {
        var current = -1;
        var next = 100;
        
       while (current != next)
       {
           
           current = CountOccupiedSeats();
           NextGeneration();
           next = CountOccupiedSeats();

       }
       return next;
    }

    public int CountOccupiedSeats()
    {
        var counter = 0;
        foreach (var row in WaitingAreaSeats)
        {
            foreach (var seat in row)
            {
                if (seat.Occupied) counter++;
            }
        }

        return counter;
    }
    
    public void NextGeneration()
    {
        var newGeneration = new List<List<Seat>>();
        
        for (int row = 0; row < WaitingAreaSeats.Count; row++)
        {
            var newRow = new List<Seat>();
            
            for (int col = 0; col <WaitingAreaSeats.First().Count; col++)
            {
                var seat = WaitingAreaSeats.ElementAt(row).ElementAt(col);
                seat.Neighbours = PartTwo ? CountVisibleNeighbours(row, col) :CountAdjacentNeighboursOfSeat(row, col);
                int neighbourThreshold = PartTwo ? 5 : 4;
                newRow.Add(seat.Next(neighbourThreshold));
            }
            newGeneration.Add(newRow);
        }

        WaitingAreaSeats = newGeneration;
    }

    private int CountVisibleNeighbours(int row, int col)
    {
        var counter = 0;
        counter += CountNeighbourAbove(row, col);
        counter += CountNeighbourBelow(row, col);
        counter += CountNeighbourRight(row, col);
        counter += CountNeighbourLeft(row, col);

        counter += CountNeighbourBelowRight(row, col);
        counter += CountNeighbourBelowLeft(row, col);
        counter += CountNeighbourAboveRight(row, col);
        counter += CountNeighbourAboveLeft(row, col);
        
        return counter;
    }

    private int CountNeighbourBelow(int row, int col)
    {
        for (int r = row + 1; r < WaitingAreaSeats.Count; r++)
        {
            if (!WaitingAreaSeats.ElementAt(r).ElementAt(col).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(r).ElementAt(col).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(r).ElementAt(col).Occupied) return 0;
            }
        }

        return 0;
    }
    
    private int CountNeighbourAbove(int row, int col)
    {
        for (int r = row - 1; r >= 0; r--)
        {
            if (!WaitingAreaSeats.ElementAt(r).ElementAt(col).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(r).ElementAt(col).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(r).ElementAt(col).Occupied) return 0;
            } 
        }

        return 0;
    }
    
    private int CountNeighbourRight(int row, int col)
    {
        for (int c = col + 1; c < WaitingAreaSeats.Count; c++)
        {
            if (!WaitingAreaSeats.ElementAt(row).ElementAt(c).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(row).ElementAt(c).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(row).ElementAt(c).Occupied) return 0;
            }
        }

        return 0;
    }
    
    private int CountNeighbourLeft(int row, int col)
    {
        for (int c = col - 1; c >= 0; c--)
        {
            if (!WaitingAreaSeats.ElementAt(row).ElementAt(c).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(row).ElementAt(c).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(row).ElementAt(c).Occupied) return 0;
            }
        }

        return 0;
    }

    private int CountNeighbourBelowRight(int row, int col)
    {
        int i = 1;
        while (row + i < WaitingAreaSeats.Count && col + i < WaitingAreaSeats.First().Count)
        {
            if (!WaitingAreaSeats.ElementAt(row + i).ElementAt(col + i).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(row + i).ElementAt(col + i).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(row + i).ElementAt(col + i).Occupied) return 0;
            }
            
            i++;
        }

        return 0;
    }
    
    private int CountNeighbourBelowLeft(int row, int col)
    {
        int i = 1;
        while (row + i < WaitingAreaSeats.Count && col - i >= 0)
        {
            if (!WaitingAreaSeats.ElementAt(row + i).ElementAt(col - i).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(row + i).ElementAt(col - i).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(row + i).ElementAt(col - i).Occupied) return 0;
            }
            
            i++;
        }

        return 0;
    }
    
    private int CountNeighbourAboveRight(int row, int col)
    {
        int i = 1;
        while (row - i >= 0 && col + i < WaitingAreaSeats.First().Count)
        {
            if (!WaitingAreaSeats.ElementAt(row - i).ElementAt(col + i).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(row - i).ElementAt(col + i).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(row - i).ElementAt(col + i).Occupied) return 0;
            }
            
            i++;
        }

        return 0;
    }
    
    private int CountNeighbourAboveLeft(int row, int col)
    {
        int i = 1;
        while (row - i >= 0 && col - i >= 0)
        {
            if (!WaitingAreaSeats.ElementAt(row - i).ElementAt(col - i).IsFloor)
            {
                if (WaitingAreaSeats.ElementAt(row - i).ElementAt(col - i).Occupied) return 1;
                if (!WaitingAreaSeats.ElementAt(row - i).ElementAt(col - i).Occupied) return 0;
            }
            i++;
        }

        return 0;
    }
    
    

    private int CountAdjacentNeighboursOfSeat(int row, int col)
    {
        var counter = 0;
        for (int r = row - 1; r <= row + 1; r++)
        {
            for (int c = col - 1; c <= col + 1; c++)
            {
                if (r >= 0 && r < WaitingAreaSeats.Count && c >= 0 && c < WaitingAreaSeats.First().Count)
                {
                    if (WaitingAreaSeats.ElementAt(r).ElementAt(c).Occupied) counter++;
                }
            }
        }

        if (WaitingAreaSeats.ElementAt(row).ElementAt(col).Occupied) counter--;

        return counter;
    }

    private void CreateWaitingAreaFromInput()
    {
        foreach (var row in _input)
        {
            var rowOfSeats = new List<Seat>();
            foreach (var seat in row)
            {
                rowOfSeats.Add(new Seat(seat));
            }
            WaitingAreaSeats.Add(rowOfSeats);
        }
    }

    public void PrintArea()
    {
        foreach (var row in WaitingAreaSeats)
        {
            var s = "";
            foreach (var seat in row)
            {
                if (seat.IsFloor) s += ".";
                else {
                   if (seat.Occupied) s += "#";
                  else s += "L";
                }
                
            }
            Console.WriteLine(s);
        }
        Console.WriteLine("     ");
    }
}