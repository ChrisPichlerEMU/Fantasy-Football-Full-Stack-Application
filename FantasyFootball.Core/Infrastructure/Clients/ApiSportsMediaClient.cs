using FantasyFootball.Models.Interfaces.Clients;

namespace FantasyFootball.Core.Infrastructure.Clients;

public sealed class ApiSportsMediaClient(HttpClient httpClient) : BaseHttpClient(httpClient), IApiSportsMediaClient
{
    public async Task<byte[]> GetPlayerPhoto(int id)
    {
        var httpResult = await ExecuteGetByteArray(HttpClientConstants.ApiSportsMediaGetPlayerPicturesPath, [id.ToString()]).ConfigureAwait(false);

        if (!httpResult.IsSuccess)
        {
            throw new HttpRequestException(BuildErrorMessage(HttpClientConstants.ApiSportsMediaGetPlayerPicturesPath, httpResult.ErrorMessage));
        }

        return httpResult.Data ?? throw new InvalidOperationException($"The {HttpClientConstants.ApiSportsMediaGetPlayerPicturesPath} endpoint returned a null response body.");
    }
}
