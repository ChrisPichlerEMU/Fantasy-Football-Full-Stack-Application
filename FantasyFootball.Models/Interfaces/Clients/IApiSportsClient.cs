using FantasyFootball.Models.QueryParameters.ApiSports;
using FantasyFootball.Models.Responses.ApiSports;

namespace FantasyFootball.Models.Interfaces.Clients;

public interface IApiSportsClient
{
    Task<GetAllTeamsResponse> GetAllTeams();

    Task<GetAllPlayersFromSpecificTeamResponse> GetAllPlayersFromSpecificTeam(ApiSportsTeam team);

    Task<GetAllGamesFromLastSeasonResponse> GetAllGamesFromLastSeason();
}
