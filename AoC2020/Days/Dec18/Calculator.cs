namespace AoC2020.Days.Dec18;

public class Calculator
{
    private int _index;

    public long SummarizeEquations(List<List<char>> equations)
    {
        long sum = 0;
        foreach (var equation in equations)
        {
            sum += SolveEquation(equation);
        }

        return sum;
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
}