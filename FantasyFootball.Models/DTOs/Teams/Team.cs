namespace FantasyFootball.Models.DTOs.Teams;

public sealed class Team
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public string? Code { get; init; }

    public string? City { get; init; }

    public string? Coach { get; init; }

    public bool IsInterimCoach => Coach?.Contains("(interim)") ?? false;

    public string? Owner { get; init; }

    public string? Stadium { get; init; }

    public int? Established { get; init; }

    public required string Logo { get; init; }
}
