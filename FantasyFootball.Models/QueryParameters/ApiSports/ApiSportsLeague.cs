namespace FantasyFootball.Models.QueryParameters.ApiSports;

public class ApiSportsLeague(string queryValue) : QueryParameter(ApiSportsLeagueQueryKey, queryValue)
{
    private const string ApiSportsLeagueQueryKey = "league";

    public static readonly ApiSportsLeague NFL = new("1");
}
