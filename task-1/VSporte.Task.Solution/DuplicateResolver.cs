using VSporte.Task.Solution.Models;

namespace VSporte.Task.Solution;

public class DuplicateResolver
{
    public Fingerprint Resolve(Fingerprint fingerprint)
    {
        // схлопывание дублей по ссылкам
        HashSet<PlayerClubItem> links = new(fingerprint.PlayerClubs);

        // схлопывание дублей по клубам 
        HashSet<ClubItem> clubs = new(fingerprint.Clubs.Length, new NamesComparer()); 

        foreach (var club in fingerprint.Clubs.Where(x => x.City != null)
                      .Union(fingerprint.Clubs.Where(x => x.City == null))) // все клубы с city=null - в конец
            if (!clubs.TryGetValue(club, out var origin))
                clubs.Add(club);
            else
            {
                // если клуб оказался дублем - все ссылки на него заменяются на оригинал
                var linksToDouble = links.Where(x => x.ClubId == club.ClubId).ToList();

                foreach (var link in linksToDouble)
                {
                    links.Remove(link);
                    link.ClubId = origin.ClubId;
                    links.Add(link);
                }
            }

        // схлопывание дублей по игрокам
        HashSet<PlayerItem> players = new(fingerprint.Players.Length, new NamesComparer());

        foreach (var player in fingerprint.Players)
            if (!players.TryGetValue(player, out var origin))
                players.Add(player);
            else
            {
                // если игрок оказался дублем - все ссылки на него заменяются на оригинал
                var linksToDouble = links.Where(x => x.PlayerId == player.PlayerId).ToList();

                foreach (var link in linksToDouble)
                {
                    links.Remove(link);
                    link.PlayerId = origin.PlayerId;
                    links.Add(link);
                }
            }

        // схлопывание дублей по парам клуб+игрок
        HashSet<(ClubItem, PlayerItem)> pairs = new(links.Count, new PlayerLinksComparer());

        foreach (var link in links)
        {
            // поиск клуба и игрока по ссылкам на них\
            var club = clubs.SingleOrDefault(x => x.ClubId == link.ClubId);
            var player = players.SingleOrDefault(x => x.PlayerId == link.PlayerId);

            if (player == null || club == null)
                continue;

            if (!pairs.Add((club, player)))
                // если связь клуб+игрок дублируется - лишний игрок удаляется
                players.Remove(player);
        }

        // все связи определяются по результатам схлопывания
        links.Clear();

        foreach (var pair in pairs)
            links.Add(new() { ClubId = pair.Item1.ClubId, PlayerId = pair.Item2.PlayerId });

        return new Fingerprint()
        {
            Clubs = clubs.ToArray(),
            Players = players.ToArray(),
            PlayerClubs = links.ToArray()
        };
    }
}