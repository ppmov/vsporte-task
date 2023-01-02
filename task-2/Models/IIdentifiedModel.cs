namespace SportEventApi.Models;

public interface IIdentifiedModel
{
    public Guid Id { get; set; }
}