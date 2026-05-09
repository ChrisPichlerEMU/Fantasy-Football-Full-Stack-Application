namespace FantasyFootball.Models.DTOs.Players;

public sealed class Player
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public string FirstName => ParsedName.First;

    public string LastName => ParsedName.Last;

    public required int Age { get; init; }

    public required string Height { get; init; }

    public required string Weight { get; init; }

    public string? College { get; init; }

    public required string Group { get; init; }

    public required string Position { get; init; }

    public required int Number { get; init; }

    public required string Salary { get; init; }

    public required int Experience { get; init; }

    public required string Image { get; init; }

    private (string First, string Last)? _parsedName;

    private (string First, string Last) ParsedName
    {
        get
        {
            if (_parsedName is null)
            {
                var firstAndLastName = Name.Split(' ', 2);
                _parsedName = (firstAndLastName[0], firstAndLastName[1]);
            }

            return _parsedName.Value;
        }
    }
}
