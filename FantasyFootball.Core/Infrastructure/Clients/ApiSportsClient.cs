using FantasyFootball.Models.DTOs.Teams;
using FantasyFootball.Models.Interfaces.Clients;
using FantasyFootball.Models.QueryParameters.ApiSports;
using FantasyFootball.Models.Responses.ApiSports;

namespace FantasyFootball.Core.Infrastructure.Clients;

public sealed class ApiSportsClient(HttpClient httpClient) : BaseHttpClient(httpClient), IApiSportsClient
{
    public async Task<GetAllTeamsResponse> GetAllTeams()
    {
        var httpResult = await ExecuteGet<GetAllTeamsResponse>(HttpClientConstants.ApiSportsGetAllTeamsPath, queryParameters: [ApiSportsLeague.NFL, ApiSportsSeason.Season2024]).ConfigureAwait(false);

        if (!httpResult.IsSuccess)
        {
            throw new HttpRequestException(BuildErrorMessage(HttpClientConstants.ApiSportsGetAllTeamsPath, httpResult.ErrorMessage));
        }

        return httpResult.Data ?? throw new InvalidOperationException($"The {HttpClientConstants.ApiSportsGetAllTeamsPath} endpoint returned a null response body.");
    }
}
