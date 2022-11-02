using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec20;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec20";

    public void PartOne()
    {
        var testInput = ParseInput("part1test1");
        var img = new ImageAnalyzer(testInput);
        img.PlaceTiles();
        Console.WriteLine(img.GetSumOfCorners());
        img.CombineTilesInBoardToResult();
        Console.WriteLine(img.GetHabitatRoughness());

        var input = ParseInput("part1");
          img = new ImageAnalyzer(input);
         img.PlaceTiles();
      Console.WriteLine(img.GetSumOfCorners());
      img.CombineTilesInBoardToResult();
      Console.WriteLine(img.GetHabitatRoughness());


    }

    public void PartTwo()
    {
        
    }

    private dynamic ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        return reader.SplitByEmptyRow(Date, filename);
    }
}