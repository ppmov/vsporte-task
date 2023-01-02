using System.Diagnostics.CodeAnalysis;

namespace VSporte.Task.Solution;

public class NamesComparer : IEqualityComparer<INamedItem>
{
    public bool Equals(INamedItem? x, INamedItem? y)
    {
        if (x == null || y == null)
            return false;

        return x.GetProperNoun() == y.GetProperNoun();
    }

    public int GetHashCode([DisallowNull] INamedItem obj)
    {
        return obj.GetProperNoun().GetHashCode();
    }
}
