using SportEventApi.Services;
using SportEventApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportEventApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClubController : IdentifiedControllerBase<Club>
{
    public ClubController(ClubService service) : base(service) {}

    private ClubService Service => ((ClubService)_service);

    [HttpGet("{id}/players")]
    public IEnumerable<Player> GetAll(Guid id)
    {
        var club = Service.Get(id);

        if (club is null)
            return new List<Player>();

        return club.Players.ToList();
    }

    [HttpPost("{id}/players")]
    public IActionResult Add(Guid id, Guid playerId)
    {
        var club = Service.Get(id);
        if (club is null)
            return NotFound();
        
        var player = Service.GetPlayer(playerId);
        if (player is null)
            return NotFound();
        
        Service.Attach(club, player);
        return NoContent();
    }

    [HttpDelete("{id}/players")]
    public IActionResult Remove(Guid id, Guid playerId)
    {
        var club = Service.Get(id);
        if (club is null)
            return NotFound();
        
        var player = Service.GetAttachedPlayer(club, playerId);
        if (player is null)
            return NotFound();
        
        Service.Unattach(club, player);
        return NoContent();
    }
}