using System.Reflection;

namespace FantasyFootball.Models.QueryParameters;

public abstract class QueryParameter<T>(string queryKey, string queryValue) : IQueryParameter where T : QueryParameter<T>
{
    public string QueryKey { get; } = queryKey;

    public string QueryValue { get; } = queryValue;

    public static IReadOnlyList<T> GetValues() => [.. typeof(T)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(field => field.FieldType == typeof(T))
        .Select(field => (T)field.GetValue(null)!)];
}
