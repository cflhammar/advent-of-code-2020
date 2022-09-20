namespace AoC2020.Days.Dec17;

public class FourDimPocketSpace
{
    private HashSet<Lantern> _activeLanterns;

    public FourDimPocketSpace(List<List<char>> input)
    {
        _activeLanterns = GetInitialLanterns(input);
    }
    
    
    public int SimulateSteps(int i)
    {
        for (int step = 0; step < i; step++)
        {
            Next();
        }

        return _activeLanterns.Count;
    }

    public void Next()
    {
        var newActiveLanterns = new HashSet<Lantern>();
        var inactiveLanternsNeighbourCounter = new Dictionary<Lantern, int>();

        foreach (var activeLantern in _activeLanterns)
        {
            var numberActiveNeighbours = 0;
            var neighbours = GetNeighbours(activeLantern);

            foreach (var neighbour in neighbours)
            {
                if (_activeLanterns.Any(l =>
                        l.X == neighbour.X &&
                        l.Y == neighbour.Y &&
                        l.Z == neighbour.Z &&
                        l.W == neighbour.W))
                    numberActiveNeighbours++;
                else
                {
                    if (!inactiveLanternsNeighbourCounter.Any(l =>
                            l.Key.X == neighbour.X && l.Key.Y == neighbour.Y &&
                            l.Key.Z == neighbour.Z && l.Key.W == neighbour.W )) inactiveLanternsNeighbourCounter.Add(neighbour,0);
                    
                    var inactiveLantern = inactiveLanternsNeighbourCounter.First(l => 
                        l.Key.X == neighbour.X && l.Key.Y == neighbour.Y && 
                        l.Key.Z == neighbour.Z && l.Key.W == neighbour.W); 
                    inactiveLanternsNeighbourCounter[inactiveLantern.Key]++;
                }
            }
            
            if (numberActiveNeighbours is 2 or 3) newActiveLanterns.Add(activeLantern);
        }


        foreach (var toBeActivatedLantern in inactiveLanternsNeighbourCounter.Where(l => l.Value == 3))
        {
            newActiveLanterns.Add(toBeActivatedLantern.Key);
        }

        _activeLanterns = newActiveLanterns;
    }

    public HashSet<Lantern> GetNeighbours(Lantern lantern)
    {
        var neighbours = new HashSet<Lantern>();
        for (int deX = lantern.X -1; deX <= lantern.X + 1; deX++)
        {
            for (int deY = lantern.Y -1; deY <= lantern.Y + 1; deY++)
            {
                for (int deZ = lantern.Z -1; deZ <= lantern.Z + 1 ; deZ++)
                {
                    for (int deW = lantern.W -1; deW <= lantern.W + 1 ; deW++)
                    {
                        neighbours.Add(new Lantern(deX, deY, deZ, deW));
                    }
                }
            }
        }

        neighbours.RemoveWhere(l => l.X == lantern.X && l.Y == lantern.Y && l.Z == lantern.Z && l.W == lantern.W);

        return neighbours;
    }

    private HashSet<Lantern> GetInitialLanterns(List<List<char>> input)
    {
        var grid = new HashSet<Lantern>();

        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 0; x < input[0].Count; x++)
            {
                if (input[y][x] == '#')
                {
                 grid.Add(new Lantern(x,y));   
                }
            }
        }

        return grid;
    }

}