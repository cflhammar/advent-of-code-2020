using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec21;

public class Solver : IDaySolver
{
    public string Date { get; } = "Dec21";

    public void PartOne()
    {
        var testInput = ParseInput("part1test1");
        var allergenHandler = new AllergenHandler(testInput);
        allergenHandler.AssignPossibleCombinations();
        Console.WriteLine( allergenHandler.GetNumberOfSafeIngredients());;
        allergenHandler.AssignAllergenToIngredient();
        allergenHandler.GenerateCanonicalDangerList();
        
        
        var input = ParseInput("part1");
        allergenHandler = new AllergenHandler(input);
        allergenHandler.AssignPossibleCombinations();
        Console.WriteLine( allergenHandler.GetNumberOfSafeIngredients());
        allergenHandler.AssignAllergenToIngredient();
        allergenHandler.GenerateCanonicalDangerList();

    }

    public void PartTwo()
    {
        
    }

    private List<List<string>> ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        var temp = reader.SplitByRow(Date, filename);
        var temp2 = temp.Select(e => e.Split(" (contains ").ToList()).ToList();
        
        return temp2;
    }
}