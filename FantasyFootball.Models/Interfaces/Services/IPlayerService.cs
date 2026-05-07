using FantasyFootball.Models.DTOs.Players;

namespace FantasyFootball.Models.Interfaces.Services;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetAllPlayers();

    Task<byte[]> GetPlayerPhoto(int id);
}
