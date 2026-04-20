namespace FantasyFootball.Models.Interfaces.Clients;

public interface IApiSportsMediaClient
{
    Task<byte[]> GetPlayerPhoto(int id);
}
