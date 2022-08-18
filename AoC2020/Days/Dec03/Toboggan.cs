using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Dec03;

public class Toboggan
{
    public long Travel(List<string> map, int horizontal, int vertical)
    {
        var length = map.ElementAt(0).Length;
        var row = 0;
        var col = 0;
        var trees = 0;
        
        while (row < map.Count)
        {
            if (map.ElementAt(row).ElementAt(col) == '#') trees++;

            row += vertical;
            col = (col + horizontal) % length;
        }
        
        return trees;
    }
}