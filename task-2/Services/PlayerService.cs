using Microsoft.EntityFrameworkCore;
using SportEventApi.Data;
using SportEventApi.Models;

namespace SportEventApi.Services;

public class PlayerService : ServiceBase<Player>
{
    public PlayerService(GameContext context) : base(context) {}

    protected override DbSet<Player> DataTable => _context.Players;
    public override string NavigationPropertyPath => "Clubs";

    public Club? GetClub(Guid ClubId) => 
        _context.Clubs.SingleOrDefault(x => x.Id == ClubId);

    public Club? GetAttachedClub(Player player, Guid clubId)
    {
        if (player.Clubs is null)
            return null;

        return player.Clubs.SingleOrDefault(x => x.Id == clubId);
    }

    public void Attach(Player player, Club club)
    {
        if (player.Clubs is null)
            player.Clubs = new List<Club>();

        player.Clubs.Add(club);

        _context.Players.Update(player);
        _context.SaveChanges();
    }

    public void Unattach(Player player, Club club)
    {   
        if (player.Clubs is null)
            return;

        player.Clubs.Remove(club);
        _context.Players.Update(player);

        _context.SaveChanges();
    }
}