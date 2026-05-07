namespace FantasyFootball.Models.QueryParameters;

public interface IQueryParameter
{
    string QueryKey { get; }

    string QueryValue { get; }
}
