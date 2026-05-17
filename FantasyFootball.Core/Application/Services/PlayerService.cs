using FantasyFootball.Models.DTOs.Players;
using FantasyFootball.Models.Interfaces.Clients;
using FantasyFootball.Models.Interfaces.Services;
using FantasyFootball.Models.QueryParameters.ApiSports;

namespace FantasyFootball.Core.Application.Services;

public sealed class PlayerService(IApiSportsClient apiSportsClient, IApiSportsMediaClient apiSportsMediaClient) : IPlayerService
{
    public async Task<IEnumerable<PlayerResponse>> GetAllPlayers()
    {
        List<PlayerResponse> listOfAllNflPlayers = [];

        var allNflTeams = ApiSportsTeam.GetValues();

        foreach (var team in allNflTeams)
        {
            var getAllPlayersFromSpecificTeamResponse = await apiSportsClient.GetAllPlayersFromSpecificTeam(team).ConfigureAwait(false);

            listOfAllNflPlayers.AddRange(getAllPlayersFromSpecificTeamResponse.Response);
        }

        // The API returns a few null objects that shouldn't be included in the application and should be removed
        listOfAllNflPlayers.RemoveAll(player => player.Position is null);

        return listOfAllNflPlayers;
    }

    public async Task<byte[]> GetPlayerPhoto(int id)
    {
        return await apiSportsMediaClient.GetPlayerPhoto(id).ConfigureAwait(false);
    }
}
