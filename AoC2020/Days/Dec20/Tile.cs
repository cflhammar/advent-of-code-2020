using AoC2020.Helpers;

namespace AoC2020.Days.Dec20;

public class Tile
{
    public long Id;
    public List<List<bool>> Content;

    public Tile(string input)
    {
        var rows = input.Split("\n");

        var id = long.Parse(rows[0].Replace("Tile ", "").Replace(":", ""));
        Id = id;

        Content = AssignContent(rows.Skip(1).ToList());

    }

    public void Rotate90()
    { 
        var helper = new RotateAndFlipListList(); 
        Content = helper.Rotate90(Content);
    }

    public void Flip()
    {
        var helper = new RotateAndFlipListList(); 
        Content = helper.Flip(Content);
    }

    public void RemoveBorder()
    {
        Content.RemoveAt(0);
        Content.RemoveAt(Content.Count-1);
        
        foreach (var row in Content)
        {
            row.RemoveAt(row.Count-1);
            row.RemoveAt(0);
        }
    }

    private List<List<bool>> AssignContent(List<string> input)
    {
        var result = new List<List<bool>>();

        foreach (var row in input)
        {
            var resultRow = new List<bool>();
            foreach (var element in row)
            {
                if (element == '#') resultRow.Add(true);
                else resultRow.Add(false);
            }
            result.Add(resultRow);
        }
        
        return result;
    }
}