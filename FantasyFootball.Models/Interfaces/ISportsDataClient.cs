using FantasyFootball.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyFootball.Core.Infrastructure.Clients;

public interface ISportsDataClient
{
    Task<IEnumerable<Player>> GetAllPlayers();
}
