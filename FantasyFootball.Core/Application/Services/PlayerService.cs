using FantasyFootball.Models.Dto;
using FantasyFootball.Models.Interfaces.Clients;
using FantasyFootball.Models.Interfaces.Services;

namespace FantasyFootball.Core.Application.Services;

public sealed class PlayerService(ISportsDataClient sportsDataClient) : IPlayerService
{
    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        return await sportsDataClient.GetAllPlayers().ConfigureAwait(false);
    }
}
