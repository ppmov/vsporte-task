using Microsoft.EntityFrameworkCore;
using SportEventApi.Data;
using SportEventApi.Models;

namespace SportEventApi.Services;

public class ClubService : ServiceBase<Club>
{
    public ClubService(GameContext context) : base(context) {}

    protected override DbSet<Club> DataTable => _context.Clubs;
    public override string NavigationPropertyPath => "Players";

    public Player? GetPlayer(Guid playerId) => 
        _context.Players.SingleOrDefault(x => x.Id == playerId);

    public Player? GetAttachedPlayer(Club club, Guid playerId)
    {
        if (club.Players is null)
            return null;

        return club.Players.SingleOrDefault(x => x.Id == playerId);
    }

    public void Attach(Club club, Player player)
    {
        if (club.Players is null)
            club.Players = new List<Player>();

        club.Players.Add(player);

        _context.Clubs.Update(club);
        _context.SaveChanges();
    }

    public void Unattach(Club club, Player player)
    {   
        if (club.Players is null)
            return;

        club.Players.Remove(player);
        _context.Clubs.Update(club);

        _context.SaveChanges();
    }
}