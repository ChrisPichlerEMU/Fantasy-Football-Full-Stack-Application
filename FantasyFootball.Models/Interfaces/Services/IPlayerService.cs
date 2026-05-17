using FantasyFootball.Models.DTOs.Players;

namespace FantasyFootball.Models.Interfaces.Services;

public interface IPlayerService
{
    Task<IEnumerable<PlayerResponse>> GetAllPlayers();

    Task<byte[]> GetPlayerPhoto(int id);
}
