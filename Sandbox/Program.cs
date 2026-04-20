using FantasyFootball.Core.Application.Services;
using FantasyFootball.Core.Infrastructure.Clients;
using FantasyFootball.Models.Interfaces.Clients;
using FantasyFootball.Models.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox;

public sealed class Program
{
    public static async Task Main()
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        var services = new ServiceCollection();

        services.AddHttpClient<ISportsDataClient, SportsDataClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.sportsdata.io");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config["SportsDataIO API Key"]);
        });

        services.AddHttpClient<IApiSportsClient, ApiSportsClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.sportsdata.io");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config["SportsDataIO API Key"]);
        });

        services.AddSingleton<IPlayerService, PlayerService>();

        var provider = services.BuildServiceProvider();

        var playerService = provider.GetService<IPlayerService>();

        var players = await playerService.GetAllPlayers().ConfigureAwait(false);

        // Debug here :)
    }
}