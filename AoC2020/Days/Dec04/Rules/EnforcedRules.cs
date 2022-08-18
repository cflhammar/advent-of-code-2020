namespace AoC2020.Days.Dec04.Rules;

public class EnforcedBirth : IRule
{
    public bool Validate(string s)
    {
        var values = s.Split(":");
        return values[0].StartsWith("byr") 
               && int.Parse(values[1]) >= 1920 &&  int.Parse(values[1]) <= 2002;
    }
}

public class EnforcedIssue : IRule
{
    public bool Validate(string s)
    {
        var values = s.Split(":");
        return values[0].StartsWith("iyr") 
               && int.Parse(values[1]) >= 2010 &&  int.Parse(values[1]) <= 2020;
    }
}

public class EnforcedExpire : IRule
{
    public bool Validate(string s)
    {
        var values = s.Split(":");
        return values[0].StartsWith("eyr") 
               && int.Parse(values[1]) >= 2020 &&  int.Parse(values[1]) <= 2030;
    }
}

public class EnforcedHeight : IRule
{
    public bool Validate(string s)
    {
        var values = s.Split(":");
        if (values[0].StartsWith("hgt"))
        {
            if (values[1].Contains("cm"))
            {
                var height = int.Parse(values[1].Replace("cm","")) ;
                return height is >= 150 and <= 193;
            } 
            
            if (values[1].Contains("in"))
            {
                var height = int.Parse(values[1].Replace("in",""));
                return height is >= 59 and <= 76;
            }
        }
        return false;
    }
}

public class EnforcedHair : IRule
{
    public bool Validate(string s)
    {
        var values = s.Split(":");
        
        return values[0].StartsWith("hcl") 
               && values[1].StartsWith("#") &&  values[1].Length == 7;
    }
}

public class EnforcedEye : IRule
{
    public bool Validate(string s)
    {
        var values = s.Split(":");

        return values[0].StartsWith("ecl") 
               && values[1] is "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth";
    }
}

public class EnforcedPassport : IRule
{
    public bool Validate(string s)
    {
        var values = s.Split(":");

        return values[0].StartsWith("pid")
               && values[1].Length == 9;
    }
}
