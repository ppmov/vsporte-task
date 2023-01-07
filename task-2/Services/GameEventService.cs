using Microsoft.EntityFrameworkCore;
using SportEventApi.Data;
using SportEventApi.Models;

namespace SportEventApi.Services;

public class GameEventService : ServiceBase<GameEvent>
{
    public GameEventService(GameContext context) : base(context) {}

    protected override DbSet<GameEvent> DataTable => _context.GameEvents;
    public override string NavigationPropertyPath => string.Empty;

    public Club? GetClub(Guid id) => _context.Clubs.SingleOrDefault(x => x.Id == id);
    public Player? GetPlayer(Guid id) => _context.Players.SingleOrDefault(x => x.Id == id);

    public override void Create(GameEvent item)
    {
        item.Club = GetClub(item.ClubId);
        item.Player = item.PlayerId is null ? null : GetPlayer(item.PlayerId ?? Guid.Empty);
        
        base.Create(item);
    }

    public override void Update(GameEvent item)
    {
        item.Club = GetClub(item.ClubId);
        item.Player = item.PlayerId is null ? null : GetPlayer(item.PlayerId ?? Guid.Empty);
        
        base.Update(item);
    }
}