using System.Diagnostics.CodeAnalysis;

namespace VSporte.Task.Solution.Models;

public class PlayerClubItem
{
    public Guid PlayerId { get; set; }
    public Guid ClubId { get; set; }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as PlayerClubItem);
    }
    
    public override int GetHashCode() =>
        this.ClubId.GetHashCode() ^ this.PlayerId.GetHashCode();

    private bool Equals(PlayerClubItem other)
    {
        if (other is null)
            return false;

        return this.ClubId == other.ClubId && this.PlayerId == other.PlayerId;
    }
}