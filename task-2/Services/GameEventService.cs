using Microsoft.EntityFrameworkCore;
using SportEventApi.Data;
using SportEventApi.Models;

namespace SportEventApi.Services;

public class GameEventService : ServiceBase<GameEvent>
{
    public GameEventService(GameContext context) : base(context) {}

    protected override DbSet<GameEvent> DataTable => _context.GameEvents;
    public override string NavigationPropertyPath => string.Empty;
}
