using Microsoft.EntityFrameworkCore;
using SportEventApi.Models;

namespace SportEventApi.Data;

public class GameContext : DbContext
{
    public GameContext (DbContextOptions<GameContext> options)
        : base(options)
    {

    }

    public DbSet<Club> Clubs => Set<Club>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<GameEvent> GameEvents => Set<GameEvent>();
}