using System.Diagnostics.CodeAnalysis;
using VSporte.Task.Solution.Models;

namespace VSporte.Task.Solution;

public class PlayerLinksComparer : IEqualityComparer<(ClubItem, PlayerItem)>
{
    public bool Equals((ClubItem, PlayerItem) x, (ClubItem, PlayerItem) y)
    {
        if (GetProperNoun(x.Item1) == GetProperNoun(y.Item1))
        {
            // полное совпадение - дубль
            if (GetProperNoun(x.Item2) == GetProperNoun(y.Item2))
                return true;

            // если отличаются только номера игроков - дубль
            if (GetProperNounIgnoreNumber(x.Item2) == GetProperNounIgnoreNumber(y.Item2))
                return true;
        }

        return false;
    }

    public int GetHashCode([DisallowNull] (ClubItem, PlayerItem) obj) =>
        GetProperNoun(obj.Item1).GetHashCode() ^ GetProperNounIgnoreNumber(obj.Item2).GetHashCode();

    public static string GetProperNoun(INamedItem item) => item.GetProperNoun();
    public static string GetProperNounIgnoreNumber(PlayerItem item) =>
        item.GetFullName().Replace(item.Number, string.Empty).GetProperNoun(); 
}