namespace AoC2020.Days.Dec21;

public class AllergenHandler
{
    private Dictionary<string, List<string>> _allergens = new();
    private List<List<List<string>>> _dishes = new();

    public AllergenHandler(List<List<string>> input)
    {

        foreach (var dish in input)
        {
            var ingreds = dish[0].Split(" ").ToList();
            var allergens = dish[1].Replace(")", "").Split(", ").ToList();
            
            _dishes.Add(new List<List<string>>{ingreds, allergens});
        }
    }


    public void AssignPossibleCombinations()
    {
        var allergens = GetUniqueAllergens();

        foreach (var allergen in allergens)
        {
            var linkedIngredients = new List<List<string>>();

            foreach (var dish in _dishes)
            {
                if (dish[1].Contains(allergen)) linkedIngredients.Add(dish[0]);
            }

            var possibleIngredients = linkedIngredients.Aggregate<IEnumerable<string>>(
                (previousList, nextList) => previousList.Intersect(nextList)
            ).ToList();
            
            _allergens.Add(allergen,possibleIngredients);
        }
    }

    public void AssignAllergenToIngredient()
    {
        while (_allergens.Any(e => e.Value.Count > 1))
        {
            foreach (var allergen in _allergens)
            {
                if (allergen.Value.Count == 1)
                {
                    var knownIngredient = allergen.Value[0];
                    
                    foreach (var otherAllergen in _allergens)
                    {
                        if (otherAllergen.Value.Contains(knownIngredient) && otherAllergen.Key != allergen.Key) otherAllergen.Value.Remove(knownIngredient);
                    }
                }
            }
        }
    }

    public void GenerateCanonicalDangerList()
    {
        var allergens = GetUniqueAllergens();
        allergens.Sort();

        var dangerList = "";
        

        foreach (var allergen in allergens)
        {
            dangerList += _allergens[allergen][0] + ",";
        }

        Console.WriteLine(dangerList.Remove(dangerList.Length-1));
    }

    private List<string> GetUniqueAllergens()
    {
        var allergens = new List<string>();
        foreach (var dish in _dishes)           
        {
            allergens.AddRange(dish[1]);
        }

        return allergens.Distinct().ToList();
    }


    public int GetNumberOfSafeIngredients()
    {
        var dangerIngredients = new List<string>();
        foreach (var combination in _allergens)
        {
            dangerIngredients.AddRange(combination.Value);
        }

        dangerIngredients = dangerIngredients.Distinct().ToList();

        var sum = 0;
        foreach (var dish in _dishes)
        {
            foreach (var ingredient in dish[0])
            {
                if (!dangerIngredients.Contains(ingredient)) sum++;
            }
        }

        return sum;
    }
}