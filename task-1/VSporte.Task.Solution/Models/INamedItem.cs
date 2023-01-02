namespace VSporte.Task.Solution;

public interface INamedItem
{
    public string GetFullName();

    public string GetProperNoun() => GetFullName().GetProperNoun();
}