using FantasyFootball.Models.Dto;
using FantasyFootball.Models.Interfaces.Clients;

namespace FantasyFootball.Core.Infrastructure.Clients;

public sealed class SportsDataClient(HttpClient httpClient) : BaseHttpClient(httpClient), ISportsDataClient
{
    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        var httpResult = await ExecuteGet<IEnumerable<Player>>(HttpClientConstants.SportsDataGetAllPlayersPath).ConfigureAwait(false);

        if (!httpResult.IsSuccess)
        {
            throw new HttpRequestException(BuildErrorMessage(HttpClientConstants.SportsDataGetAllPlayersPath, httpResult.ErrorMessage));
        }

        return httpResult.Data ?? throw new InvalidOperationException($"The {HttpClientConstants.SportsDataGetAllPlayersPath} endpoint returned a null response body.");
    }
}