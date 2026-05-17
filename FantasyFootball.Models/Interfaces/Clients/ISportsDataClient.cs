using FantasyFootball.Models.DTOs.Players;

namespace FantasyFootball.Models.Interfaces.Clients;

public interface ISportsDataClient
{
    Task<IEnumerable<PlayerResponse>> GetAllPlayers();
}
