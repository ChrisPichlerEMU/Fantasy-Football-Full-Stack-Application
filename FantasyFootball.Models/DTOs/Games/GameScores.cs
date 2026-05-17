namespace FantasyFootball.Models.DTOs.Games;

public sealed class GameScores
{
    public required TeamScore Home { get; init; }

    public required TeamScore Away { get; init; }
}
