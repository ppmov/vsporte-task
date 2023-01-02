public static class NameStringExtension
{
    public static string GetProperNoun(this string name)
    {
        name = name.Replace("   ", " ");
        name = name.Replace("  ", " ");
        name = name.Replace("ё", "е");
        name = name.Replace("й", "и");
        
        var names = name.Split(' ');
        name = string.Empty;

        foreach (var n in names)
        {
            if (name != string.Empty)
                name += " ";

            name += FixCase(n);
        }

        if (name.First() == ' ')
            name = name.Remove(0, 1);
        
        if (name.Last() == ' ')
            name = name.Remove(name.Length - 1, 1);
        
        return name;

        string FixCase(string name)
        {
            if (name.Length == 0)
                return name;
        
            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }
    }
}