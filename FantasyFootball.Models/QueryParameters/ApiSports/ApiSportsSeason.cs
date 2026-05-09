namespace FantasyFootball.Models.QueryParameters.ApiSports;

public class ApiSportsSeason(string queryValue) : QueryParameter(ApiSportsSeasonQueryKey, queryValue)
{
    private const string ApiSportsSeasonQueryKey = "season";

    public static readonly ApiSportsSeason Season2024 = new("2024");
    public static readonly ApiSportsSeason Season2025 = new("2025");
    public static readonly ApiSportsSeason Season2026 = new("2026");
}
