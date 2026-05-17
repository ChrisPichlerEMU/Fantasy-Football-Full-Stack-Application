namespace FantasyFootball.Models.DTOs.Games;

public sealed class GameResponse
{
    public required Game Game { get; init; }

    public required GameTeams Teams { get; init; }

    public string HomeTeam => Teams.Home.Name;

    public string AwayTeam => Teams.Away.Name;

    public required GameScores Scores { get; init; }

    // Final scores will never be null, but ApiSports returns one game with null scores so they all must be marked as null, that game can be ignored
    public int HomeTeamFinalScore => Scores.Home.Total ?? 0;

    public int AwayTeamFinalScore => Scores.Away.Total ?? 0;
}
