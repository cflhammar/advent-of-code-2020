using System.Collections.Generic;

namespace AoC2020.Days.Dec07;

public class Bag
{
    public string BagColor { get; set; } = "";
    public Dictionary<Bag, int>? Contains {get; set; }

}