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
            client.BaseAddress = new Uri("https://v1.american-football.api-sports.io");
            client.DefaultRequestHeaders.Add("x-apisports-key", config["API Sports Key"]);
        });

        services.AddHttpClient<IApiSportsMediaClient, ApiSportsMediaClient>(client =>
        {
            client.BaseAddress = new Uri("https://media.api-sports.io");
            client.DefaultRequestHeaders.Add("x-apisports-key", config["API Sports Media Key"]);
        });

        services.AddSingleton<IPlayerService, PlayerService>();
        services.AddSingleton<ITeamService, TeamService>();
        services.AddSingleton<IGameService, GameService>();

        var provider = services.BuildServiceProvider();

        var playerService = provider.GetService<IPlayerService>();
        var teamService = provider.GetService<ITeamService>();
        var gameService = provider.GetService<IGameService>();

        // Get all teams
        var allTeams = await teamService.GetAllTeams().ConfigureAwait(false);

        // Get all players from all teams

        // Get all scores from previous season

        // Get upcoming schedules for all teams

        // Get all player photos

        // Get all team logos

        // Get all player stats from last season

        // Get all games from last season

        // Get defensive stats by week

        // Get scores from all weeks of last season

        // Get all stadiums

        // Get game-specific stats

        // Get player photos
        var patrickMahomesPhoto = await playerService.GetPlayerPhoto(1197).ConfigureAwait(false);

        //var players = await playerService.GetAllPlayers().ConfigureAwait(false);
    }
}