using FantasyFootball.Core.Web.Dto;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace FantasyFootball.Core.Web.Clients;

public sealed class SportsDataClient(HttpClient httpClient)
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web);

    public async Task<HttpResult<T>> ExecuteGet<T>(string path, Dictionary<string, string>? queryParamters = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var fullPathWithQueryParameters = BuildPathWithQueryParameters(path, queryParamters);

            var response = await httpClient.GetAsync(fullPathWithQueryParameters, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync(cancellationToken);

                return HttpResult<T>.Failure(response.StatusCode, errorMessage);
            }

            var responseObject = await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions, cancellationToken);

            return HttpResult<T>.Success(responseObject);
        } 
        catch (HttpRequestException ex)
        {
            return HttpResult<T>.Failure(ex.StatusCode ?? HttpStatusCode.InternalServerError, ex.Message);
        }
        catch (TaskCanceledException ex)
        {
            return HttpResult<T>.Failure(HttpStatusCode.RequestTimeout, ex.Message);
        }
    }

    private static string BuildPathWithQueryParameters(string path, Dictionary<string, string>? queryParameters)
    {
        if (queryParameters is null || queryParameters.Count == 0)
        {
            return path;
        }

        var query = string.Join("&", queryParameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

        return $"{path}?{query}";
    }
}