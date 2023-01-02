using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SportEventApi.Models;

public class Player : IIdentifiedModel
{
    public Guid Id { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Number { get; set; }

    [JsonIgnore]
    public ICollection<Club>? Clubs { get; set; }
}