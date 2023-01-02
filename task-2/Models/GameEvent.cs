using System.Text.Json.Serialization;

namespace SportEventApi.Models;

public class GameEvent : IIdentifiedModel
{
    public Guid Id { get; set; }
    public Guid ClubId { get; set; }
    public Guid? PlayerId { get; set; }
    public string Action { get; set; }
    public DateTime MatchTime { get; set; }

    [JsonIgnore]
    public Club? Club { get; set; }
    [JsonIgnore]
    public Player? Player { get; set; }
}