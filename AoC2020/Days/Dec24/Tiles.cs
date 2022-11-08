namespace AoC2020.Days.Dec24;

public class Tiles
{

    public int CountTilesAfterDays(List<string> input, int days)
    {
        var tiles = FlipTiles(input).Item2;
        
        for (int i = 1; i <= days; i++)
        {
            tiles = NextDay(tiles);
        }
        
        return tiles.Count(e => e.Value);
    }

    public Dictionary<string, bool> NextDay(Dictionary<string,bool> tiles)
    {
        var neighbours = new Dictionary<string, int>();

        foreach (var (key, value) in tiles)
        {
            if (value == false) continue;

            var pos = key.Split(",");
            var x = int.Parse(pos[0]);
            var y = int.Parse(pos[1]);

            List<string> neighbourPositions;

            if (y % 2 != 0)
                neighbourPositions = new List<string>
                {
                    (x - 1) + "," + y,
                    (x - 1) + "," + (y + 1), 
                    x + "," + (y + 1), 
                    (x + 1) + "," + y, 
                    x + "," + (y - 1),
                    (x - 1) + "," + (y - 1)
                };
            else
                neighbourPositions = new List<string>
                {
                    (x - 1) + "," + y, 
                    x + "," + (y + 1), 
                    (x + 1) + "," + (y + 1), 
                    (x + 1) + "," + y,
                    (x + 1) + "," + (y - 1), 
                    x + "," + (y - 1)
                };

            foreach (var p in neighbourPositions)
            {
                if (neighbours.ContainsKey(p)) neighbours[p]++;
                else neighbours.Add(p, 1);
            }
        }

        var next = new Dictionary<string, bool>();

        foreach (var (key, value) in neighbours)
        {
            if ( tiles.ContainsKey(key) && tiles[key] && value is 1 or 2) next.Add(key, true);
            else if (value == 2) next.Add(key, true);
        }

        return next;
    }

    public (int, Dictionary<string, bool>) FlipTiles(List<string> input)
    {
        Dictionary<string, bool> flippedTiles = new Dictionary<string, bool>();

        foreach (var instruction in input)
        {
            var pos = GetPosition(instruction);
            if (!flippedTiles.ContainsKey(pos)) flippedTiles.Add(pos,true);
            else flippedTiles[pos] =  !flippedTiles[pos];
        }

        return (flippedTiles.Count(e => e.Value), flippedTiles);
    }

    public string GetPosition(string instruction)
    {
        var xPos = 0;
        var yPos = 0;

        while (instruction.Length > 0)
        {

            if (instruction.Length > 1)
            {
                var next = instruction[0..2];

                switch (next)
                {
                    case "se":
                        yPos--;
                        if (yPos % 2 != 0) xPos++;
                        instruction = instruction.Remove(0, 2);
                        continue;
                    
                    case "sw":
                        yPos--;
                        if (yPos % 2 == 0) xPos--;
                        instruction = instruction.Remove(0, 2);
                        continue;
                    
                    case "ne":
                        yPos++;
                        if (yPos % 2 != 0) xPos++;
                        instruction = instruction.Remove(0, 2);
                        continue;
                    
                    case "nw":
                        yPos++;
                        if (yPos % 2 == 0) xPos--;
                        instruction = instruction.Remove(0, 2);
                        continue;
                }
            }
            
            var nextOne = instruction[0].ToString();
            
            switch (nextOne)
            {
                case "e":
                    xPos++;
                    instruction = instruction.Remove(0, 1);
                    break;
                
                case "w":
                    xPos--;
                    instruction = instruction.Remove(0, 1);
                    break;
            }
        }
        
        return xPos + "," + yPos;
    }

}