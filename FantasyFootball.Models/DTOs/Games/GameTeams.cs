namespace FantasyFootball.Models.DTOs.Games;

public sealed class GameTeams
{
    public required GameTeam Home { get; init; }

    public required GameTeam Away { get; init; }
}
