using FantasyFootball.Core.Domain.Services.Interfaces;
using FantasyFootball.Core.Web.Clients;

namespace FantasyFootball.Core.Domain.Services.Implementations;

public sealed class PlayerService(SportsDataClient sportsDataClient) : IPlayerService
{
}
