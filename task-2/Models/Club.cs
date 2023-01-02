using System.Text.Json.Serialization;

namespace SportEventApi.Models;

public class Club : IIdentifiedModel
{   
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }

    [JsonIgnore]
    public ICollection<Player>? Players { get; set; }
}