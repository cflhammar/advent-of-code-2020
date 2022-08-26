namespace AoC2020.Days.Dec12;

public class BoatAndWaypoint
{
    private int _y;
    private int _x;
    private int _xWaypoint;
    private int _yWaypoint;


    public int GetManhattanDistance(List<string> directions)
    {
        Navigate(directions);

        return Math.Abs(_y) + Math.Abs(_x);
    }

    private void Navigate(List<string> directions)
    {
        _y = 0;
        _x = 0;
        _xWaypoint = 10;
        _yWaypoint = 1;

        Console.WriteLine(_y + ", " + _x);
        Console.WriteLine("wp: " + _xWaypoint + ", " +_yWaypoint);
        
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
                _yWaypoint += value;
                break;
            case "S":
                _yWaypoint -= value;
                break;
            case "E":
                _xWaypoint += value;
                break;
            case "W":
                _xWaypoint -= value;
                break;
            case "L":
                var newXwp = 0;
                var newYwp = 0;
                
                switch (value)
                {
                    case 90:
                        newXwp = _yWaypoint * -1;
                        newYwp = _xWaypoint;
                        break;
                    case 180:
                        newXwp = _xWaypoint * -1;
                        newYwp = _yWaypoint * -1;
                        break;
                    case 270:
                        newXwp = _yWaypoint;
                        newYwp = _xWaypoint  * -1;
                        break;
                }
                _xWaypoint = newXwp;
                _yWaypoint = newYwp;
                break;
            
            case "R":
                newXwp = 0;
                newYwp = 0;
                
                switch (value)
                {
                    case 90:
                        newXwp = _yWaypoint;
                        newYwp = _xWaypoint * -1;
                        break;
                    case 180:
                        newXwp = _xWaypoint * -1;
                        newYwp = _yWaypoint * -1;
                        break;
                    case 270:
                        newXwp = _yWaypoint * -1;
                        newYwp = _xWaypoint;
                        break;
                }
                _xWaypoint = newXwp;
                _yWaypoint = newYwp;
                break;
            
            case "F":
                _y += _xWaypoint * value;
                _x += _yWaypoint * value;
                break;
        }
    }
}