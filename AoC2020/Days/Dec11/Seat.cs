namespace AoC2020.Days.Dec11;

public class Seat
{
    public bool IsFloor = false;
    public bool Occupied = false;
    public int Neighbours = 0;

    public Seat(char c)
    {
        switch (c)
        {
            case 'L':
                Occupied = false;
                break;
            case '#':
                Occupied = true;
                break;
            case '.':
                IsFloor = true;
                break;
        }
    }

    public Seat()
    {
        
    }

    public Seat Next(int threshold)
    {
        var seat = new Seat();
        
        if (!IsFloor)
        {
            if (!Occupied && Neighbours == 0)
            {
                seat.Occupied = true;
            } 
            else if (Occupied && Neighbours >= threshold)
            {
                seat.Occupied = false;
            }
            else
            {
                seat.Occupied = Occupied;
            }
        }
        else
        {
            seat.IsFloor = true;
            seat.Occupied = false;
            seat.Neighbours = 0;
        }

        return seat;
    }
}