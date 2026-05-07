using FantasyFootball.Models.DTOs.Teams;
using FantasyFootball.Models.Responses.ApiSports;

namespace FantasyFootball.Models.Interfaces.Clients;

public interface IApiSportsClient
{
    Task<GetAllTeamsResponse> GetAllTeams();
}
