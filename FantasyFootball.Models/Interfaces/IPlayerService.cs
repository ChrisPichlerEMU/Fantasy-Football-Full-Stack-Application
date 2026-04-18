using FantasyFootball.Models.Dto;

namespace FantasyFootball.Models.Interfaces;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetAllPlayers();
}
