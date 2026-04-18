using FantasyFootball.Models.Dto;

namespace FantasyFootball.Core.Infrastructure.Clients;

public interface ISportsDataClient
{
    Task<IEnumerable<Player>> GetAllPlayers();
}
