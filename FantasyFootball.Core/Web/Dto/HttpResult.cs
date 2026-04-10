using System.Net;

namespace FantasyFootball.Core.Web.Dto;

public sealed class HttpResult<T>
{
    public T? Data { get; private set; }

    public int StatusCode { get; private set; }

    public string? ErrorMessage { get; private set; }

    public static HttpResult<T> Success(T? data) => new() { Data = data, StatusCode = (int)HttpStatusCode.OK };

    public static HttpResult<T> Failure(HttpStatusCode statusCode, string? errorMessage) => new() { StatusCode = (int)statusCode, ErrorMessage = errorMessage };
}
