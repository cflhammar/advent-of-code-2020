namespace AoC2020.Days.Dec12;

public class Boat
{
    public int NorthSouth;
    public int EastWest;
    public int Direction;


    public int GetManhattanDistance(List<string> directions)
    {
        Navigate(directions);

        return Math.Abs(NorthSouth) + Math.Abs(EastWest);

    }

    private void Navigate(List<string> directions)
    {
        NorthSouth = 0;
        EastWest = 0;
        Direction = 0;

        foreach (var direction in directions)
        {
            var operation = direction.Substring(0, 1);
            var value = int.Parse( direction.Substring(1, direction.Length - 1));

            Step(operation, value);
        }
    }

    private void Step(string operation, int value)
    {
        switch (operation)
        {
            case "N":
                NorthSouth += value;
                break;
            case "S":
                NorthSouth -= value;
                break;
            case "E":
                EastWest += value;
                break;
            case "W":
                EastWest -= value;
                break;
            case "L":
                Direction -= value;
                if (Direction < 0) Direction += 360;
                break;
            case "R":
                Direction = (Direction + value) % 360;
                break;
            case "F":
                switch (Direction)
                {
                    case 0:
                        EastWest += value;
                        break;
                    case 90:
                        NorthSouth -= value;
                        break;
                    case 180:
                        EastWest -= value;
                        break;
                    case 270:
                        NorthSouth += value;
                        break;
                }
                break;
        }
    }
}