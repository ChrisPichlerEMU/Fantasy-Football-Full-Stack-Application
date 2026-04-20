using FantasyFootball.Core.Infrastructure.Dto;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace FantasyFootball.Core.Infrastructure.Clients;

public abstract class BaseHttpClient(HttpClient httpClient)
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web);

    public async Task<HttpResult<T>> ExecuteGet<T>(string path, string[]? args = null, Dictionary<string, string>? queryParamters = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var fullPathWithQueryParameters = BuildPathWithQueryParameters(path, args, queryParamters);

            var response = await httpClient.GetAsync(fullPathWithQueryParameters, cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request to endpoint with path = {path} failed with status code {response.StatusCode}", inner: null, statusCode: response.StatusCode);
            }

            var responseObject = await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

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

    public async Task<HttpResult<byte[]>> ExecuteGetByteArray(string path, string[]? args, Dictionary<string, string>? queryParamters = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var fullPathWithQueryParameters = BuildPathWithQueryParameters(path, args, queryParamters);

            var imageByteArray = await httpClient.GetByteArrayAsync(fullPathWithQueryParameters, cancellationToken).ConfigureAwait(false);

            return HttpResult<byte[]>.Success(imageByteArray);
        }
        catch (HttpRequestException ex)
        {
            return HttpResult<byte[]>.Failure(ex.StatusCode ?? HttpStatusCode.InternalServerError, ex.Message);
        }
        catch (TaskCanceledException ex)
        {
            return HttpResult<byte[]>.Failure(HttpStatusCode.RequestTimeout, ex.Message);
        }
    }

    private static string BuildPathWithQueryParameters(string path, string[]? args, Dictionary<string, string>? queryParameters)
    {
        var formattedPath = args is not null && args.Length > 0 ? string.Format(path, (object[])args) : path;

        if (queryParameters is null || queryParameters.Count == 0)
        {
            return formattedPath;
        }

        var query = string.Join("&", queryParameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

        return $"{formattedPath}?{query}";
    }

    protected static string BuildErrorMessage(string path, string? errorMessage) => $"There was an error when attempting to access the {path} endpoint. Message = {errorMessage}";
}
