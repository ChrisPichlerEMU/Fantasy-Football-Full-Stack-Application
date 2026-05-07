using FantasyFootball.Models.DTOs.Players;
using FantasyFootball.Models.Interfaces.Clients;
using FantasyFootball.Models.Interfaces.Services;

namespace FantasyFootball.Core.Application.Services;

public sealed class PlayerService(ISportsDataClient sportsDataClient, IApiSportsMediaClient apiSportsMediaClient) : IPlayerService
{
    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        return await sportsDataClient.GetAllPlayers().ConfigureAwait(false);
    }

    public async Task<byte[]> GetPlayerPhoto(int id)
    {
        return await apiSportsMediaClient.GetPlayerPhoto(id).ConfigureAwait(false);
    }
}
