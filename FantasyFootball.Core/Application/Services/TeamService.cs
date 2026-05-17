using FantasyFootball.Models.DTOs.Teams;
using FantasyFootball.Models.Interfaces.Clients;
using FantasyFootball.Models.Interfaces.Services;
using FantasyFootball.Models.Responses.ApiSports;

namespace FantasyFootball.Core.Application.Services;

public sealed class TeamService(IApiSportsClient apiSportsClient) : ITeamService
{
    public async Task<IEnumerable<TeamResponse>> GetAllTeams()
    {
        var allTeams = await apiSportsClient.GetAllTeams().ConfigureAwait(false);

        // The API returns all 32 teams and the 2 pro bowl "teams" which are really conferences which aren't necessary for this project, so this where clause filters those 2 "teams" out
        return allTeams.Response.Where(team => team.City is not null);
    }
}
