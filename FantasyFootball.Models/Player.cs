namespace FantasyFootball.Models;

public sealed class Player
{
    public required int PlayerId { get; init; }

    public required string Team { get; init; }

    public required int Number { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Position { get; init; }

    public required string Status { get; init; }

    public required string Height { get; init; }

    public required int Weight { get; init; }

    public required DateTime BirthDate { get; init; }

    public required string College { get; init; }

    public required int Experience { get; init; }

    public required string FantasyPosition { get; init; }

    public required string PositionCategory { get; init; }

    public required string PhotoUrl { get; init; }

    public required int ByeWeek { get; init; }

    public required decimal AverageDraftPosition { get; init; }

    public required string CollegeDraftTeam { get; init; }

    public required int CollegeDraftYear { get; init; }

    public required int CollegeDraftRound { get; init; }

    public required int CollegeDraftPick { get; init; }

    public required bool IsUndraftedFreeAgent { get; init; }

    public required int FanDuelPlayerId { get; init; }

    public required int DraftKingsPlayerId { get; init; }

    public string? InjuryStatus { get; init; }

    public required string FanDuelName { get; init; }

    public required string DraftKingsName { get; init; }

    public required int TeamId { get; init; }
}
