namespace VSporte.Task.Solution.Models;

public class ClubItem : INamedItem, ICloneable
{
    public Guid ClubId { get; set; }
    public string FullName { get; set; }
    public string? City { get; set; }

    public string GetFullName() => $"{FullName}";

    public object Clone() => new ClubItem()
    {
        ClubId = Guid.NewGuid(),
        FullName = this.FullName,
        City = this.City
    };
}