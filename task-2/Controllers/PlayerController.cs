using SportEventApi.Services;
using SportEventApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportEventApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : IdentifiedControllerBase<Player>
{
    public PlayerController(PlayerService service) : base(service) {}
    
    private PlayerService Service => ((PlayerService)_service);

    [HttpGet("{id}/clubs")]
    public IEnumerable<Club> GetAll(Guid id)
    {
        var player = Service.Get(id);

        if (player is null)
            return new List<Club>();

        return player.Clubs.ToList();
    }

    [HttpPost("{id}/clubs")]
    public IActionResult Add(Guid id, Guid clubId)
    {
        var player = Service.Get(id);
        if (player is null)
            return NotFound();
        
        var club = Service.GetClub(clubId);
        if (club is null)
            return NotFound();
        
        Service.Attach(player, club);
        return NoContent();
    }

    [HttpDelete("{id}/clubs")]
    public IActionResult Remove(Guid id, Guid clubId)
    {
        var player = Service.Get(id);
        if (player is null)
            return NotFound();
        
        var club = Service.GetAttachedClub(player, clubId);
        if (club is null)
            return NotFound();
        
        Service.Unattach(player, club);
        return NoContent();
    }
}