namespace FantasyFootball.Models.QueryParameters;

public abstract class QueryParameter : IQueryParameter
{
    public string QueryKey { get; }

    public string QueryValue { get; }

    protected QueryParameter(string queryKey, string queryValue)
    {
        QueryKey = queryKey;
        QueryValue = queryValue;
    }
}
