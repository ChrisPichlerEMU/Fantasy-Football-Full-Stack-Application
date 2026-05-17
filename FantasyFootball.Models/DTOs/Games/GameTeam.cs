namespace FantasyFootball.Models.DTOs.Games;

public sealed class GameTeam
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public required string Logo { get; init; }
}
