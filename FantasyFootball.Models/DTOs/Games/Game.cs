namespace FantasyFootball.Models.DTOs.Games;

public sealed class Game
{
    public required int Id { get; init; }

    public required string Stage { get; init; }

    public required string Week { get; init; }

    public required GameDate Date { get; init; }

    public required GameVenue Venue { get; init; }
}
