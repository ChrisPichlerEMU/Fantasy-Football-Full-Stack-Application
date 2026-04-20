using FantasyFootball.Models.Dto;

namespace FantasyFootball.Models.Interfaces.Services;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetAllPlayers();
}
