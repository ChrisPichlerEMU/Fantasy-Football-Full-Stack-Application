using FantasyFootball.Models.Dto;

namespace FantasyFootball.Models.Interfaces.Clients;

public interface ISportsDataClient
{
    Task<IEnumerable<Player>> GetAllPlayers();
}
