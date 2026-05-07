using FantasyFootball.Models.DTOs.Teams;
using FantasyFootball.Models.Responses.ApiSports;

namespace FantasyFootball.Models.Interfaces.Services;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeams();
}
