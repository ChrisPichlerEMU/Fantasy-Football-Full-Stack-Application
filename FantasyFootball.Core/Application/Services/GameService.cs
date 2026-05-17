using FantasyFootball.Models.DTOs.Games;
using FantasyFootball.Models.Interfaces.Clients;
using FantasyFootball.Models.Interfaces.Services;

namespace FantasyFootball.Core.Application.Services;

public sealed class GameService(IApiSportsClient apiSportsClient) : IGameService
{
    public async Task<IEnumerable<GameResponse>> GetAllScoresFromLastSeason()
    {
        const string RegularSeasonGameStage = "Regular Season";

        var getAllGamesResponse = await apiSportsClient.GetAllGamesFromLastSeason().ConfigureAwait(false);

        // Only regular season games are relevant for this application, this filters out pre-season games and post-season games
        return getAllGamesResponse.Response.Where(game => string.Equals(game.Game.Stage, RegularSeasonGameStage, StringComparison.OrdinalIgnoreCase));
    }
}
