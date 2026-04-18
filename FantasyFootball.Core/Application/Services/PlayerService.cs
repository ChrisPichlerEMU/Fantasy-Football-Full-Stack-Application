using FantasyFootball.Core.Application.Services;
using FantasyFootball.Core.Infrastructure.Clients;
using FantasyFootball.Core.Infrastructure.Dto;
using FantasyFootball.Models.Dto;
using FantasyFootball.Models.Interfaces;

namespace FantasyFootball.Core.Application.Services;

public sealed class PlayerService(ISportsDataClient sportsDataClient) : IPlayerService
{
    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        return await sportsDataClient.GetAllPlayers().ConfigureAwait(false);
    }
}
