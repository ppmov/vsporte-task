namespace VSporte.Task.Solution.Models;

public class PlayerItem : INamedItem, ICloneable
{
    public Guid PlayerId { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }

    public string GetFullName() => $"{Surname} {Name} {Number}";

    public object Clone() => new PlayerItem()
    {
        PlayerId = Guid.NewGuid(),
        Surname = this.Surname,
        Name = this.Name,
        Number = this.Number
    };
}