using FantasyFootball.Core.Domain.Services.Implementations;
using FantasyFootball.Core.Web.Clients;

namespace FantasyFootball.Core;

public sealed class Program
{
    public static void Main()
    {
        // Git repo!
    }

    private static PlayerService BuildPlayerService()
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new("https://api.sportsdata.io/api")
        };

        var sportsDataClient = new SportsDataClient(httpClient);

        return new PlayerService(sportsDataClient);
    }
}