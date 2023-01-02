using SportEventApi.Services;
using SportEventApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportEventApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GameEventController : IdentifiedControllerBase<GameEvent>
{
    public GameEventController(GameEventService service) : base(service) {}
}
