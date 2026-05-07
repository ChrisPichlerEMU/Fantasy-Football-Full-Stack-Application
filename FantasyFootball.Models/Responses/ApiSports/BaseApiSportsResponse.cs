namespace FantasyFootball.Models.Responses.ApiSports;

public class BaseApiSportsResponse<T>
{
    public required int Results { get; init; }

    public required IEnumerable<T> Response { get; init; }
}
