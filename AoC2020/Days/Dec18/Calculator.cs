namespace AoC2020.Days.Dec18;

public class Calculator
{
    private int _index;

    public long SummarizeEquations(List<List<char>> equations, bool part2)
    {
        long sum = 0;
        foreach (var equation in equations)
        {
            if (part2) sum += SolveEquation(FixPredesence(equation));
            else sum += SolveEquation(equation);
        }

        return sum;
    }

    public List<char> FixPredesence(List<char> eq)
    {
        var newEq = new List<char>();
        newEq.Add('(');
        
        foreach (var c in eq)
        {
            if (c == '*')
            {
                newEq.AddRange(new List<char>{')','*','('});
            }
            else if (c == '(' || c == ')')
            {
                newEq.AddRange(new List<char>{c,c});
            }
            else
            {
                newEq.Add(c);
            }
        }
        
        newEq.Add(')');

      //  PrintEquation(newEq);

        return newEq;
    }

    public long SolveEquation(List<char> equation)
    {
        long total = 0;
        string operation = "na";

        while (_index < equation.Count)
        {
            switch (equation[_index])
            {
                case '+':
                    operation = "add";
                    break;
                
                case '*':
                    operation = "mul";
                    break;
                
                case '(':
                {
                    _index++;
                    switch (operation)
                    {
                        case "add":
                            total += SolveEquation(equation);
                            break;
                        case "mul":
                            total *= SolveEquation(equation);
                            break;
                        default:
                            total = SolveEquation(equation);
                            break;
                    }
                    break;
                }
                
                case ')':
                    return total;
                
                default:
                {
                    switch (operation)
                    {
                        case "add":
                            total += long.Parse(equation[_index].ToString());
                            break;
                        
                        case "mul":
                            total *= long.Parse(equation[_index].ToString());
                            break;
                        
                        default:
                            total = long.Parse(equation[_index].ToString());
                            break;
                    }
                    break;
                }
            }
            _index++;
        }

        _index = 0;
        return total;
    }


    private void PrintEquation(List<char> eq)
    {
        
        Console.WriteLine(eq.ToArray());
    }
}