namespace FantasyFootball.Models.DTOs.Players;

public sealed class Player
{
    public required int PlayerId { get; init; }

    public string? Team { get; init; }

    public int? Number { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Position { get; init; }

    public required string Status { get; init; }

    public required string Height { get; init; }

    public required int Weight { get; init; }

    public DateTime? BirthDate { get; init; }

    public required string College { get; init; }

    public int? Experience { get; init; }

    public required string FantasyPosition { get; init; }

    public required string PositionCategory { get; init; }

    public required string PhotoUrl { get; init; }

    public int? ByeWeek { get; init; }

    public string? CollegeDraftTeam { get; init; }

    public int? CollegeDraftYear { get; init; }

    public int? CollegeDraftRound { get; init; }

    public int? CollegeDraftPick { get; init; }

    public string? InjuryStatus { get; init; }

    public int? TeamId { get; init; }
}
