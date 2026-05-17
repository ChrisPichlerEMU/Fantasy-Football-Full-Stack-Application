using FantasyFootball.Models.DTOs.Games;

namespace FantasyFootball.Models.Interfaces.Services;

public interface IGameService
{
    Task<IEnumerable<GameResponse>> GetAllScoresFromLastSeason();
}
