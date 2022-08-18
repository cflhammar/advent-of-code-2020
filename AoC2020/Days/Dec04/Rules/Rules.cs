namespace AoC2020.Days.Dec04.Rules;

public class Birth : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("byr");
    }
}

public class Issue : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("iyr");
    }
}

public class Expire : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("eyr");
    }
}

public class Height : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("hgt");
    }
}

public class Hair : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("hcl");
    }
}

public class Eye : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("ecl");
    }
}

public class Passport : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("pid");
    }
}

public class Country : IRule
{
    public bool Validate(string s)
    {
        return s.StartsWith("cid");
    }
}